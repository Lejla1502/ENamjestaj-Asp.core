using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class oneToManyNarudzbaIzlazi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IzlaziStavka_Izlaz_IzlazId",
                table: "IzlaziStavka");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Izlaz",
                table: "Izlaz");

            migrationBuilder.AddColumn<int>(
                name: "IzlazId",
                table: "Izlaz",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Izlaz",
                table: "Izlaz",
                column: "IzlazId");

            migrationBuilder.CreateIndex(
                name: "IX_Izlaz_NarudzbaId",
                table: "Izlaz",
                column: "NarudzbaId");

            migrationBuilder.AddForeignKey(
                name: "FK_IzlaziStavka_Izlaz_IzlazId",
                table: "IzlaziStavka",
                column: "IzlazId",
                principalTable: "Izlaz",
                principalColumn: "IzlazId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IzlaziStavka_Izlaz_IzlazId",
                table: "IzlaziStavka");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Izlaz",
                table: "Izlaz");

            migrationBuilder.DropIndex(
                name: "IX_Izlaz_NarudzbaId",
                table: "Izlaz");

            migrationBuilder.DropColumn(
                name: "IzlazId",
                table: "Izlaz");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Izlaz",
                table: "Izlaz",
                column: "NarudzbaId");

            migrationBuilder.AddForeignKey(
                name: "FK_IzlaziStavka_Izlaz_IzlazId",
                table: "IzlaziStavka",
                column: "IzlazId",
                principalTable: "Izlaz",
                principalColumn: "NarudzbaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
