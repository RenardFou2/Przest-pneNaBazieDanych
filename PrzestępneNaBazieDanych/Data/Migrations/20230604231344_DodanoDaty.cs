using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrzestępneNaBazieDanych.Data.Migrations
{
    public partial class DodanoDaty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "date",
                table: "Przestepne",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "Przestepne");
        }
    }
}
