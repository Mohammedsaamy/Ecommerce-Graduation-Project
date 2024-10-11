using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Group_4_Intake_44.Migrations
{
    /// <inheritdoc />
    public partial class EditDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_Brand_ID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Brand_ID",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "BrandID",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandID",
                table: "Product",
                column: "BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand",
                table: "Product",
                column: "BrandID",
                principalTable: "Brand",
                principalColumn: "Brand_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_BrandID",
                table: "Product");

            migrationBuilder.AlterColumn<decimal>(
                name: "BrandID",
                table: "Product",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Brand_ID",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Brand_ID",
                table: "Product",
                column: "Brand_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand",
                table: "Product",
                column: "Brand_ID",
                principalTable: "Brand",
                principalColumn: "Brand_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
