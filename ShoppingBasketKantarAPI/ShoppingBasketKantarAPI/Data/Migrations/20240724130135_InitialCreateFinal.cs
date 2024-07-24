using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingBasketKantarAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "spKantar");

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "spKantar",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ProductHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    ProductExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ProductHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ProductHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ProductHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    Price = table.Column<decimal>(type: "decimal(19,4)", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ProductHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ProductHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ProductHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ProductHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreateUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ProductHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ProductHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ProductHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ProductHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ProductHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ProductHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "Discount",
                schema: "spKantar",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    DiscountExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    DiscountType = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    DiscountCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    Value = table.Column<decimal>(type: "decimal(19,4)", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreateUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.DiscountId);
                    table.ForeignKey(
                        name: "FK_Discount_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "spKantar",
                        principalTable: "Product",
                        principalColumn: "ProductId");
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "DiscountHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "DiscountRule",
                schema: "spKantar",
                columns: table => new
                {
                    DiscountRuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountRuleHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    DiscountRuleType = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountRuleHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountRuleHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountRuleHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    ProductQuantity = table.Column<int>(type: "int", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountRuleHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    BasketTotalValue = table.Column<decimal>(type: "decimal(19,4)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountRuleHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountRuleHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DiscountRuleHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountRule", x => x.DiscountRuleId);
                    table.ForeignKey(
                        name: "FK_DiscountRule_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalSchema: "spKantar",
                        principalTable: "Discount",
                        principalColumn: "DiscountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountRule_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "spKantar",
                        principalTable: "Product",
                        principalColumn: "ProductId");
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "DiscountRuleHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.InsertData(
                schema: "spKantar",
                table: "Discount",
                columns: new[] { "DiscountId", "CreateDate", "CreateUserId", "Deleted", "Description", "DiscountCode", "DiscountExternalId", "DiscountType", "ProductId", "UpdateDate", "UpdateUserId", "Value" },
                values: new object[] { 1, new DateTime(2024, 7, 24, 13, 1, 34, 764, DateTimeKind.Utc).AddTicks(9820), 1, false, "Welcome discount - 2€", "WELCOME10", new Guid("2c3bea54-0360-4ad6-916f-720e4f930ec2"), (short)2, null, null, null, 2m });

            migrationBuilder.InsertData(
                schema: "spKantar",
                table: "Product",
                columns: new[] { "ProductId", "CreateDate", "CreateUserId", "Deleted", "Description", "Name", "PhotoUrl", "Price", "ProductExternalId", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 24, 13, 1, 34, 764, DateTimeKind.Utc).AddTicks(9714), 1, false, "Apple", "Apple", "https://media.self.com/photos/5b6b0b0cbb7f036f7f5cbcfa/4:3/w_4116,h_3087,c_limit/apples.jpg", 1m, new Guid("736c8512-8915-4ebe-8cf7-3f739b9f4eda"), null, null },
                    { 2, new DateTime(2024, 7, 24, 13, 1, 34, 764, DateTimeKind.Utc).AddTicks(9720), 1, false, "Soup", "Soup", "https://www.inspiredtaste.net/wp-content/uploads/2022/01/Creamy-Chicken-Noodle-Soup-3-1200-1200x800.jpg", 0.65m, new Guid("0b753c9b-05ed-4185-9331-f03c6cb7694c"), null, null },
                    { 3, new DateTime(2024, 7, 24, 13, 1, 34, 764, DateTimeKind.Utc).AddTicks(9722), 1, false, "Loaf of bread", "Bread", "https://www.allrecipes.com/thmb/CjzJwg2pACUzGODdxJL1BJDRx9Y=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/6788-amish-white-bread-DDMFS-4x3-6faa1e552bdb4f6eabdd7791e59b3c84.jpg", 0.8m, new Guid("f69e46cf-92e6-4e1f-a61d-9a68a0973238"), null, null },
                    { 4, new DateTime(2024, 7, 24, 13, 1, 34, 764, DateTimeKind.Utc).AddTicks(9728), 1, false, "Milk", "Milk", "https://www.thefrozengarden.com/cdn/shop/articles/benefits-of-whole-milk-benefits-of-drinking-whole-milk-blog-frozen-garden_e991a019-eebb-455b-99b2-96041863f037.webp?v=1706546802", 1.3m, new Guid("e4760ccf-58b8-4521-bd7c-1f1b0339dec9"), null, null },
                    { 5, new DateTime(2024, 7, 24, 13, 1, 34, 764, DateTimeKind.Utc).AddTicks(9730), 1, false, "Watermelon", "Watermelon", "https://static.toiimg.com/thumb/msid-109165284,width-1280,height-720,resizemode-4/109165284.jpg", 0.79m, new Guid("d9bbd08a-9861-4897-b3fb-0eb2aa471832"), null, null },
                    { 6, new DateTime(2024, 7, 24, 13, 1, 34, 764, DateTimeKind.Utc).AddTicks(9736), 1, false, "Ice cream", "Ben & Jerry's Ice Cream", "https://i.ytimg.com/vi/PDHjQBQ-GDg/maxresdefault.jpg", 4.39m, new Guid("811614d0-fb26-41fa-b306-66109e0f2bf6"), null, null },
                    { 7, new DateTime(2024, 7, 24, 13, 1, 34, 764, DateTimeKind.Utc).AddTicks(9754), 1, false, "Orange", "Orange", "https://www.allrecipes.com/thmb/y_uvjwXWAuD6T0RxaS19jFvZyFU=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/GettyImages-1205638014-2000-d0fbf9170f2d43eeb046f56eec65319c.jpg", 0.99m, new Guid("9ea3f102-3dcb-48c0-a84f-397fcb4a8490"), null, null },
                    { 8, new DateTime(2024, 7, 24, 13, 1, 34, 764, DateTimeKind.Utc).AddTicks(9756), 1, false, "Redbull can", "Redbull", "https://assets.bwbx.io/images/users/iqjWHBFdfxIU/iIoVzYblObRg/v1/-1x-1.jpg", 1.5m, new Guid("adff678d-1ffb-457c-8254-249f651732b8"), null, null },
                    { 9, new DateTime(2024, 7, 24, 13, 1, 34, 764, DateTimeKind.Utc).AddTicks(9758), 1, false, "Oreo", "Oreo", "https://www.allrecipes.com/thmb/sjK0dcDQO7aQ4kQ1ixfcvZNK7mw=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/ar-oreo-adobe-2x1-3-41049067131d46cda449b40f5b3f6106.jpg", 2.39m, new Guid("1455f131-1f9d-4988-b3f2-7549593afe30"), null, null }
                });

            migrationBuilder.InsertData(
                schema: "spKantar",
                table: "Discount",
                columns: new[] { "DiscountId", "CreateDate", "CreateUserId", "Deleted", "Description", "DiscountCode", "DiscountExternalId", "DiscountType", "ProductId", "UpdateDate", "UpdateUserId", "Value" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 7, 24, 13, 1, 34, 764, DateTimeKind.Utc).AddTicks(9824), 1, false, "2 tins of soup and get a loaf of bread for half price", null, new Guid("3ee409ce-bd98-4e7a-acf9-5ee4130edd44"), (short)1, 3, null, null, 0.5m },
                    { 3, new DateTime(2024, 7, 24, 13, 1, 34, 764, DateTimeKind.Utc).AddTicks(9826), 1, false, " 10% discount off their normal price this week", null, new Guid("1b6fab27-6308-4bc2-a32c-59bd303d82fe"), (short)1, 1, null, null, 0.1m }
                });

            migrationBuilder.InsertData(
                schema: "spKantar",
                table: "DiscountRule",
                columns: new[] { "DiscountRuleId", "BasketTotalValue", "DiscountId", "DiscountRuleType", "ProductId", "ProductQuantity" },
                values: new object[] { 1, null, 2, (short)1, 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Discount_ProductId",
                schema: "spKantar",
                table: "Discount",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountRule_DiscountId",
                schema: "spKantar",
                table: "DiscountRule",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountRule_ProductId",
                schema: "spKantar",
                table: "DiscountRule",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountRule",
                schema: "spKantar")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "DiscountRuleHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "Discount",
                schema: "spKantar")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "DiscountHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "spKantar")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ProductHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");
        }
    }
}
