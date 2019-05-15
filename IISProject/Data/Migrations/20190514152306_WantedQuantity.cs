using Microsoft.EntityFrameworkCore.Migrations;

namespace IISProject.Data.Migrations
{
    public partial class WantedQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WantedQuantity",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WantedQuantity",
                table: "Products");
        }
    }
}
