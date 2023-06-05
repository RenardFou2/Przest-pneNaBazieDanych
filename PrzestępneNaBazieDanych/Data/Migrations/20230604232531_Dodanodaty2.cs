using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrzestępneNaBazieDanych.Data.Migrations
{
    public partial class Dodanodaty2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                table: "Przestepne",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Przestepne",
                newName: "date");
        }
    }
}
