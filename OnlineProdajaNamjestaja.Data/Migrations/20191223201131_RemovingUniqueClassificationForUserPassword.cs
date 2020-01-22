using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class RemovingUniqueClassificationForUserPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Korisnik_Lozinka",
                table: "Korisnik");

            migrationBuilder.AlterColumn<string>(
                name: "Lozinka",
                table: "Korisnik",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Lozinka",
                table: "Korisnik",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_Lozinka",
                table: "Korisnik",
                column: "Lozinka",
                unique: true,
                filter: "[Lozinka] IS NOT NULL");
        }
    }
}
