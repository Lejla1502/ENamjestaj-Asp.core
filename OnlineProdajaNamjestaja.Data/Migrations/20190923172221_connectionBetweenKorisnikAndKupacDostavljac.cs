using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class connectionBetweenKorisnikAndKupacDostavljac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "Kupac",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "Dostavljac",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_KorisnikId",
                table: "Kupac",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Dostavljac_KorisnikId",
                table: "Dostavljac",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dostavljac_Korisnik_KorisnikId",
                table: "Dostavljac",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kupac_Korisnik_KorisnikId",
                table: "Kupac",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dostavljac_Korisnik_KorisnikId",
                table: "Dostavljac");

            migrationBuilder.DropForeignKey(
                name: "FK_Kupac_Korisnik_KorisnikId",
                table: "Kupac");

            migrationBuilder.DropIndex(
                name: "IX_Kupac_KorisnikId",
                table: "Kupac");

            migrationBuilder.DropIndex(
                name: "IX_Dostavljac_KorisnikId",
                table: "Dostavljac");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "Kupac");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "Dostavljac");
        }
    }
}
