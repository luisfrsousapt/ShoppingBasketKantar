using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingBasketKantarAPI.Data.Entities;
using ShoppingBasketKantarAPI.Data.Repositories.Interfaces;
using ShoppingBasketKantarAPI.DTO;
using ShoppingBasketKantarAPI.Enums;
using ShoppingBasketKantarAPI.Services;

namespace ShoppingBasketKantarTests
{



    [TestClass]
    public class BasketServiceTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IMapper> _mockMapper;
        private Mock<IProductRepository> _mockProductRepository;
        private Mock<IDiscountRepository> _mockDiscountRepository;
        private BasketService _basketService;

        [TestInitialize]
        public void Setup()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _mockProductRepository = new Mock<IProductRepository>();
            _mockDiscountRepository = new Mock<IDiscountRepository>();

            _mockUnitOfWork.Setup(u => u.ProductRepository).Returns(_mockProductRepository.Object);
            _mockUnitOfWork.Setup(u => u.DiscountRepository).Returns(_mockDiscountRepository.Object);

            _basketService = new BasketService(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        //throw exception
        [TestMethod]
        public async Task GetBasketAsync_CheckBasketIsEmpty()
        {
            List<BasketProductDTO> emptyBasket = new List<BasketProductDTO>();

            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _basketService.GetBasketAsync(emptyBasket));
            Assert.AreEqual("Basket can't be empty", exception.Message);
        }


        //correct basket creation
        [TestMethod]
        public async Task GetBasketAsync_CheckWithProducts()
        {
            var productsInBasket = new List<BasketProductDTO>{
            new BasketProductDTO { ProductId = Guid.NewGuid(), ProductQuantity = 2 },
            new BasketProductDTO { ProductId = Guid.NewGuid(), ProductQuantity = 1 }
        };

            var products = new List<Product>{
            new Product { ProductId = 1, ProductExternalId = productsInBasket[0].ProductId, Price = 10, Name = "Name 1" },
            new Product { ProductId = 2, ProductExternalId = productsInBasket[1].ProductId, Price = 20, Name = "Name 2" }
        };

            var discounts = new List<Discount>();

            _mockProductRepository.Setup(r => r.GetProductsListByIdAsync(It.IsAny<List<Guid>>()))
                .ReturnsAsync(products);
            _mockDiscountRepository.Setup(r => r.GetDiscountsByProductsList(It.IsAny<List<int>>()))
                .ReturnsAsync(discounts);


            var result = await _basketService.GetBasketAsync(productsInBasket);

            Assert.IsNotNull(result);
            Assert.AreEqual(40, result.SubtotalValue);
            Assert.AreEqual(0, result.DiscountsValue);
            Assert.AreEqual(40, result.TotalValue);
        }

        [TestMethod]
        public void CalculateDiscountValue_CheckApplyPercentageDiscountCorrectly()
        {
            var product = new Product { ProductId = 1, Price = 100, Name = "Name 1" };
            var discount = new Discount { DiscountType = (short)DiscountTypeEnum.Percentage, Value = 0.1m };
            var productDiscounts = new List<Discount> { discount };
            var products = new List<Product> { product };
            var productQuantityBasket = new List<BasketProductDTO>{
            new BasketProductDTO { ProductId = product.ProductExternalId, ProductQuantity = 1 }
        };

            var discountValue = _basketService.CalculateDiscountValue(product, productDiscounts, products, 100, productQuantityBasket);

            Assert.AreEqual(10, discountValue);
        }

        [TestMethod]
        public void CalculateDiscountValue_CheckApplyFixedValueDiscountCorrectly()
        {
            var product = new Product { ProductId = 1, Price = 100, Name = "Name 1" };
            var discount = new Discount { DiscountType = (short)DiscountTypeEnum.FixedValue, Value = 10 };
            var productDiscounts = new List<Discount> { discount };
            var products = new List<Product> { product };
            var productQuantityBasket = new List<BasketProductDTO>{
            new BasketProductDTO { ProductId = product.ProductExternalId, ProductQuantity = 1 }
        };

            var discountValue = _basketService.CalculateDiscountValue(product, productDiscounts, products, 100, productQuantityBasket);

            Assert.AreEqual(10, discountValue);
        }

    }
}
