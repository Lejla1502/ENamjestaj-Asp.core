using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class removeBojaIDFromProizvodi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_Boja_BojaId",
                table: "Proizvod");

            migrationBuilder.DropIndex(
                name: "IX_Proizvod_BojaId",
                table: "Proizvod");

            migrationBuilder.DropColumn(
                name: "BojaId",
                table: "Proizvod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BojaId",
                table: "Proizvod",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_BojaId",
                table: "Proizvod",
                column: "BojaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_Boja_BojaId",
                table: "Proizvod",
                column: "BojaId",
                principalTable: "Boja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
