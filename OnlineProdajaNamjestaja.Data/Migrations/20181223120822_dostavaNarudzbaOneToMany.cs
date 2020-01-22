using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class dostavaNarudzbaOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Dostava_DostavaId",
                table: "Narudzba");

            migrationBuilder.DropTable(
                name: "NarudzbaDostava");

            migrationBuilder.AlterColumn<int>(
                name: "DostavaId",
                table: "Narudzba",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Dostava_DostavaId",
                table: "Narudzba",
                column: "DostavaId",
                principalTable: "Dostava",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Dostava_DostavaId",
                table: "Narudzba");

            migrationBuilder.AlterColumn<int>(
                name: "DostavaId",
                table: "Narudzba",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "NarudzbaDostava",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DostavaId = table.Column<int>(nullable: false),
                    NarudzbaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaDostava", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NarudzbaDostava_Dostava_DostavaId",
                        column: x => x.DostavaId,
                        principalTable: "Dostava",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NarudzbaDostava_Narudzba_NarudzbaId",
                        column: x => x.NarudzbaId,
                        principalTable: "Narudzba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaDostava_DostavaId",
                table: "NarudzbaDostava",
                column: "DostavaId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaDostava_NarudzbaId",
                table: "NarudzbaDostava",
                column: "NarudzbaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Dostava_DostavaId",
                table: "Narudzba",
                column: "DostavaId",
                principalTable: "Dostava",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
