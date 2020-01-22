using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class putBojaIDnotnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaStavka_Boja_BojaId",
                table: "NarudzbaStavka");

            migrationBuilder.AlterColumn<int>(
                name: "BojaId",
                table: "NarudzbaStavka",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaStavka_Boja_BojaId",
                table: "NarudzbaStavka",
                column: "BojaId",
                principalTable: "Boja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaStavka_Boja_BojaId",
                table: "NarudzbaStavka");

            migrationBuilder.AlterColumn<int>(
                name: "BojaId",
                table: "NarudzbaStavka",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaStavka_Boja_BojaId",
                table: "NarudzbaStavka",
                column: "BojaId",
                principalTable: "Boja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
