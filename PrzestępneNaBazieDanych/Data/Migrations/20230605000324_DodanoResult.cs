﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrzestępneNaBazieDanych.Data.Migrations
{
    public partial class DodanoResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Przestepne",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "Przestepne");
        }
    }
}
