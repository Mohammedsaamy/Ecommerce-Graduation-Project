using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Group_4_Intake_44.Migrations
{
    /// <inheritdoc />
    public partial class after1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stores",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<double>(
                name: "Long",
                table: "Stores",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Lat",
                table: "Stores",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Store_ProductID",
                table: "Stores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "whatsappNumber",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Store_ProductID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 1,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 2,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 3,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 4,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 5,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 6,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 7,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 8,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 9,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 10,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 11,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 12,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 13,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 14,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 15,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 16,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 17,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 18,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 19,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 20,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 21,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 22,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 23,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 24,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 25,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 26,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 27,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 28,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 29,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 30,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 31,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 32,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 33,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 34,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 35,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 36,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 37,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 38,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 39,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 40,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 41,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 42,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 43,
                column: "Store_ProductID",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_Store_ProductID",
                table: "Stores",
                column: "Store_ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Store_ProductID",
                table: "Product",
                column: "Store_ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Store Product_Store_ProductID",
                table: "Product",
                column: "Store_ProductID",
                principalTable: "Store Product",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Store Product_Store_ProductID",
                table: "Stores",
                column: "Store_ProductID",
                principalTable: "Store Product",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Store Product_Store_ProductID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Store Product_Store_ProductID",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_Store_ProductID",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Product_Store_ProductID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Store_ProductID",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "whatsappNumber",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Store_ProductID",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<int>(
                name: "Long",
                table: "Stores",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Lat",
                table: "Stores",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
