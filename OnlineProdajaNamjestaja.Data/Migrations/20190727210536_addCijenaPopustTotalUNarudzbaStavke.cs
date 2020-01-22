using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class addCijenaPopustTotalUNarudzbaStavke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CijenaProizvoda",
                table: "NarudzbaStavka",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PopustNaCijenu",
                table: "NarudzbaStavka",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalStavke",
                table: "NarudzbaStavka",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CijenaProizvoda",
                table: "NarudzbaStavka");

            migrationBuilder.DropColumn(
                name: "PopustNaCijenu",
                table: "NarudzbaStavka");

            migrationBuilder.DropColumn(
                name: "TotalStavke",
                table: "NarudzbaStavka");
        }
    }
}
