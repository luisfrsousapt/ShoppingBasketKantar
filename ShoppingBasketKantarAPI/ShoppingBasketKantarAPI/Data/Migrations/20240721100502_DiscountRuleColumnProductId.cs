using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingBasketKantarAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class DiscountRuleColumnProductId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                schema: "spKantar",
                table: "DiscountRule",
                type: "int",
                nullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "DiscountRuleHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountRule_ProductId",
                schema: "spKantar",
                table: "DiscountRule",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountRule_Product_ProductId",
                schema: "spKantar",
                table: "DiscountRule",
                column: "ProductId",
                principalSchema: "spKantar",
                principalTable: "Product",
                principalColumn: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountRule_Product_ProductId",
                schema: "spKantar",
                table: "DiscountRule");

            migrationBuilder.DropIndex(
                name: "IX_DiscountRule_ProductId",
                schema: "spKantar",
                table: "DiscountRule");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "spKantar",
                table: "DiscountRule")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "DiscountRuleHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "spKantar")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");
        }
    }
}
