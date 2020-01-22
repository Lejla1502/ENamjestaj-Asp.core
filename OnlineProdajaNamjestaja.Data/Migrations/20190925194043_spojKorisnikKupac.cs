using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class spojKorisnikKupac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Kupac_KorisnickoIme",
                table: "Kupac");

            migrationBuilder.DropIndex(
                name: "IX_Kupac_Lozinka",
                table: "Kupac");

            migrationBuilder.DropIndex(
                name: "IX_Korisnik_Email",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "KorisnickoIme",
                table: "Kupac");

            migrationBuilder.DropColumn(
                name: "Lozinka",
                table: "Kupac");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "Ime",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Korisnik");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KorisnickoIme",
                table: "Kupac",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lozinka",
                table: "Kupac",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Korisnik",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "Korisnik",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "Korisnik",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Korisnik",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_KorisnickoIme",
                table: "Kupac",
                column: "KorisnickoIme",
                unique: true,
                filter: "[KorisnickoIme] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_Lozinka",
                table: "Kupac",
                column: "Lozinka",
                unique: true,
                filter: "[Lozinka] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_Email",
                table: "Korisnik",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }
    }
}
