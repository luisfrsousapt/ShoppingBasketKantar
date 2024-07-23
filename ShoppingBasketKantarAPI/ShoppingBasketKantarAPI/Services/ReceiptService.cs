using AutoMapper;
using Microsoft.Extensions.Hosting;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using ShoppingBasketKantarAPI.Data.Entities;
using ShoppingBasketKantarAPI.Data.Repositories.Interfaces;
using ShoppingBasketKantarAPI.DTO;
using ShoppingBasketKantarAPI.Enums;
using ShoppingBasketKantarAPI.Services.Interfaces;
using static QuestPDF.Helpers.Colors;

namespace ShoppingBasketKantarAPI.Services
{
    public class ReceiptService : IReceiptService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReceiptService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public Stream GetReceiptAsync(BasketDTO basket)
        {
            var data = Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Margin(30);

                    page.Header().ShowOnce().Row(row =>
                    {
                        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                        string projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName; // Navigates up three levels
                        var logoCompany = Path.Combine(projectDirectory, "images", "logo_shopping.png");
                        byte[] imageData = System.IO.File.ReadAllBytes(logoCompany);

                       
                        row.ConstantItem(150).Image(imageData);


                        row.RelativeItem().Column(col =>
                        {
                            col.Item().AlignCenter().Text("Shopping 24/7").Bold().FontSize(14);
                            col.Item().AlignCenter().Text("R. Dom João i 627, 4450-203 Matosinhos").FontSize(9);
                            col.Item().AlignCenter().Text("91 000 00 00").FontSize(9);
                            col.Item().AlignCenter().Text("support@shopping247.com").FontSize(9);

                        });

                        Random random = new Random();
                        int randomNineDigitNumber = random.Next(100000000, 1000000000);
                        string invoiceNumber = $"INV {randomNineDigitNumber}";

                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Border(1).BorderColor("#2573B2")
                            .AlignCenter().Text("");

                            col.Item().Background("#2573B2").Border(1)
                            .BorderColor("#2573B2").AlignCenter()
                            .Text(invoiceNumber).FontColor("#fff");

                            col.Item().Border(1).BorderColor("#2573B2").
                            AlignCenter().Text("");


                        });
                    });

                    page.Content().PaddingVertical(10).Column(col1 =>
                    {
                        col1.Item().Column(col2 =>
                        {
                            col2.Item().Text("Client Data").Underline().Bold();

                            col2.Item().Text(txt =>
                            {
                                txt.Span("Name: ").SemiBold().FontSize(10);
                                txt.Span("Final Consumer").FontSize(10);
                            });

                            col2.Item().Text(txt =>
                            {
                                txt.Span("NIF: ").SemiBold().FontSize(10);
                                txt.Span("551208416").FontSize(10);
                            });
                        });

                        col1.Item().LineHorizontal(0.5f);

                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(3);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();

                            });

                            table.Header(header =>
                            {
                                header.Cell().Background("#2573B2")
                                .Padding(2).Text("Product").FontColor("#fff");

                                header.Cell().Background("#2573B2")
                               .Padding(2).Text("Unit Price").FontColor("#fff");

                                header.Cell().Background("#2573B2")
                               .Padding(2).Text("Quantity").FontColor("#fff");

                                header.Cell().Background("#2573B2")
                               .Padding(2).AlignRight().Text("Total").FontColor("#fff");
                            });

                            foreach (var item in basket.ProductDiscounts)
                            {
                                var quantity = item.ProductQuantity;
                                var price = item.Product.Price;
                                var total = quantity * price;

                                table.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                .Padding(2).Text(item.Product.Name).FontSize(10);

                                table.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                         .Padding(2).Text($"{price} €").FontSize(10);

                                table.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                         .Padding(2).Text(quantity.ToString()).FontSize(10);

                                table.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                         .Padding(2).AlignRight().Text($"{total} €").FontSize(10);

                                //DISCOUNT
                                if (item.Discounts.Count > 0)
                                {
                                    foreach(var discount in item.Discounts)
                                    {
                                        decimal totalDiscountValue = CalculateDiscountValue(
                                                item.Product,
                                                item.Discounts,
                                                basket.ProductDiscounts.Select(p => p.Product).ToList(),
                                                basket.SubtotalValue,
                                                basket.ProductDiscounts
                                            );

                                        if(totalDiscountValue != 0)
                                        {
                                            table.Cell().BorderBottom(0.5f).BorderColor("#949393")
                                     .Padding(2).PaddingLeft(10).Text($"Discount: {discount.Description}").FontSize(10).FontColor("#949393");

                                            table.Cell().BorderBottom(0.5f).BorderColor("#949393")
                                     .Padding(2).Text("").FontSize(10);

                                            table.Cell().BorderBottom(0.5f).BorderColor("#949393")
                                     .Padding(2).Text("").FontSize(10);

                                            table.Cell().BorderBottom(0.5f).BorderColor("#949393")
                                     .Padding(2).AlignRight().Text($"-{totalDiscountValue} €").FontSize(10).FontColor("#949393");
                                        }
                                    }
                                }
                                
                            }

                        });
                        col1.Item().AlignRight().Text($"Subtotal: {basket.SubtotalValue.ToString()} €").FontSize(12);
                        col1.Item().AlignRight().Text($"Discounts: -{basket.DiscountsValue.ToString()} €").FontSize(10);
                        col1.Item().AlignRight().Text($"Total: {basket.TotalValue.ToString()} €" ).FontSize(16);

                        col1.Spacing(10);
                    });


                    page.Footer()
                    .AlignRight()
                    .Text(txt =>
                    {
                        txt.Span("Page ").FontSize(10);
                        txt.CurrentPageNumber().FontSize(10);
                        txt.Span(" of ").FontSize(10);
                        txt.TotalPages().FontSize(10);
                    });
                });
            }).GeneratePdf();

            Stream stream = new MemoryStream(data);
            return stream;
        }

        private decimal CalculateDiscountValue(ProductDTO product, List<DiscountDTO> productDiscounts, List<ProductDTO> products, decimal subTotal, List<BasketProductDiscountDTO> productQuantityBasket)
        {
            decimal totalDiscountValue = 0;
            var basketProduct = productQuantityBasket.FirstOrDefault(bp => bp.Product.ProductExternalId == product.ProductExternalId);

            foreach (var discount in productDiscounts)
            {
                if (ValidateDiscountRules(discount, products, subTotal, productQuantityBasket))
                {
                    if ((DiscountTypeEnum)discount.DiscountType == DiscountTypeEnum.Percentage)
                    {
                        totalDiscountValue += discount.Value * (product.Price * (basketProduct?.ProductQuantity ?? 1));
                    }
                    else if ((DiscountTypeEnum)discount.DiscountType == DiscountTypeEnum.FixedValue)
                    {
                        totalDiscountValue += discount.Value * (basketProduct?.ProductQuantity ?? 1);
                    }
                }
            }

            return totalDiscountValue;
        }

        private bool ValidateDiscountRules(DiscountDTO discount, List<ProductDTO> products, decimal subTotal, List<BasketProductDiscountDTO> productQuantityBasket)
        {
            if (discount.Rules == null || !discount.Rules.Any())
            {
                return true;
            }

            foreach (var discountRule in discount.Rules)
            {
                if ((DiscountRuleTypeEnum)discountRule.DiscountRuleType == DiscountRuleTypeEnum.Product)
                {
                    var basketProductEntity = products.FirstOrDefault(p => p.ProductExternalId == discountRule.ProductExternalId);

                    if (basketProductEntity != null)
                    {
                        var basketProduct = productQuantityBasket.FirstOrDefault(bp => bp.Product.ProductExternalId == basketProductEntity.ProductExternalId);
                        if (basketProduct != null && basketProduct.ProductQuantity >= discountRule.ProductQuantity)
                        {
                            return true;
                        }
                    }
                }
                else if ((DiscountRuleTypeEnum)discountRule.DiscountRuleType == DiscountRuleTypeEnum.Basket)
                {
                    if (subTotal >= discountRule.BasketTotalValue)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
