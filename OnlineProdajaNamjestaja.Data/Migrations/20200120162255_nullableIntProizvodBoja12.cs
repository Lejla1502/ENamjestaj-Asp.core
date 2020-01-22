using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class nullableIntProizvodBoja12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProizvodBoja",
                table: "ProizvodBoja");

            migrationBuilder.DropIndex(
                name: "IX_ProizvodBoja_BojaId",
                table: "ProizvodBoja");

            migrationBuilder.DropIndex(
                name: "IX_ProizvodBoja_ProizvodId",
                table: "ProizvodBoja");

            migrationBuilder.DropColumn(
                name: "ProizvodBojaId",
                table: "ProizvodBoja");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProizvodBoja_BojaId_ProizvodId",
                table: "ProizvodBoja",
                columns: new[] { "BojaId", "ProizvodId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProizvodBoja",
                table: "ProizvodBoja",
                columns: new[] { "ProizvodId", "BojaId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProizvodBoja_BojaId_ProizvodId",
                table: "ProizvodBoja");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProizvodBoja",
                table: "ProizvodBoja");

            migrationBuilder.AddColumn<int>(
                name: "ProizvodBojaId",
                table: "ProizvodBoja",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProizvodBoja",
                table: "ProizvodBoja",
                column: "ProizvodBojaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodBoja_BojaId",
                table: "ProizvodBoja",
                column: "BojaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodBoja_ProizvodId",
                table: "ProizvodBoja",
                column: "ProizvodId");
        }
    }
}
