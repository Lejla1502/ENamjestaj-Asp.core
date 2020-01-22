using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class dodajKonacnaCijenaUIzlazStavka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Konacnacijena",
                table: "IzlaziStavka",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Konacnacijena",
                table: "IzlaziStavka");
        }
    }
}
