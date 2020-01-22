using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class addOneToOneBetweenNarudzbaIzlaz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Izlaz_NarudzbaId",
                table: "Izlaz");

            migrationBuilder.CreateIndex(
                name: "IX_Izlaz_NarudzbaId",
                table: "Izlaz",
                column: "NarudzbaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Izlaz_NarudzbaId",
                table: "Izlaz");

            migrationBuilder.CreateIndex(
                name: "IX_Izlaz_NarudzbaId",
                table: "Izlaz",
                column: "NarudzbaId");
        }
    }
}
