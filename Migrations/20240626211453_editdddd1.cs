using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Group_4_Intake_44.Migrations
{
    /// <inheritdoc />
    public partial class editdddd1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreID",
                table: "OrderHeader",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoreID",
                table: "OrderHeader");
        }
    }
}
