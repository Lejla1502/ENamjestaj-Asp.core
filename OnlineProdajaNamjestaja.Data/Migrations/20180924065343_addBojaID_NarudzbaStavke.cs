using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class addBojaID_NarudzbaStavke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BojaId",
                table: "NarudzbaStavka",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavka_BojaId",
                table: "NarudzbaStavka",
                column: "BojaId");

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaStavka_Boja_BojaId",
                table: "NarudzbaStavka",
                column: "BojaId",
                principalTable: "Boja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaStavka_Boja_BojaId",
                table: "NarudzbaStavka");

            migrationBuilder.DropIndex(
                name: "IX_NarudzbaStavka_BojaId",
                table: "NarudzbaStavka");

            migrationBuilder.DropColumn(
                name: "BojaId",
                table: "NarudzbaStavka");
        }
    }
}
