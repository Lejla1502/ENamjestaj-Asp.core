using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class NullableKorisnikInIzlaz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Izlaz_Korisnik_KorisnikId",
                table: "Izlaz");

            migrationBuilder.AlterColumn<int>(
                name: "KorisnikId",
                table: "Izlaz",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Izlaz_Korisnik_KorisnikId",
                table: "Izlaz",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Izlaz_Korisnik_KorisnikId",
                table: "Izlaz");

            migrationBuilder.AlterColumn<int>(
                name: "KorisnikId",
                table: "Izlaz",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Izlaz_Korisnik_KorisnikId",
                table: "Izlaz",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
