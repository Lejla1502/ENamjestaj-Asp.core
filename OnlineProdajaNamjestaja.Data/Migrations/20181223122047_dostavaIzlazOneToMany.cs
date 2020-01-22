using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class dostavaIzlazOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Dostava_DostavaId",
                table: "Narudzba");

            migrationBuilder.DropIndex(
                name: "IX_Narudzba_DostavaId",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "DostavaId",
                table: "Narudzba");

            migrationBuilder.AddColumn<int>(
                name: "DostavaId",
                table: "Izlaz",
                nullable: true,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Izlaz_DostavaId",
                table: "Izlaz",
                column: "DostavaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Izlaz_Dostava_DostavaId",
                table: "Izlaz",
                column: "DostavaId",
                principalTable: "Dostava",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Izlaz_Dostava_DostavaId",
                table: "Izlaz");

            migrationBuilder.DropIndex(
                name: "IX_Izlaz_DostavaId",
                table: "Izlaz");

            migrationBuilder.DropColumn(
                name: "DostavaId",
                table: "Izlaz");

            migrationBuilder.AddColumn<int>(
                name: "DostavaId",
                table: "Narudzba",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_DostavaId",
                table: "Narudzba",
                column: "DostavaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Dostava_DostavaId",
                table: "Narudzba",
                column: "DostavaId",
                principalTable: "Dostava",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
