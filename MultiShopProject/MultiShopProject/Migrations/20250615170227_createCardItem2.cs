using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShopProject.Migrations
{
    public partial class createCardItem2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CardItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "CardItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CardItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CardItems");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "CardItems");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "CardItems");
        }
    }
}
