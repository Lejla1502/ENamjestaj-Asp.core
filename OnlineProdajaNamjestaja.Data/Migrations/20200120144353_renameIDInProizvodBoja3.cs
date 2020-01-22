using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class renameIDInProizvodBoja3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProizvodBoja_ProizvodBojaId",
                table: "ProizvodBoja");

            migrationBuilder.RenameColumn(
                name: "ProizvodBojaId",
                table: "ProizvodBoja",
                newName: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProizvodBoja_Id",
                table: "ProizvodBoja",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProizvodBoja_Id",
                table: "ProizvodBoja");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProizvodBoja",
                newName: "ProizvodBojaId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProizvodBoja_ProizvodBojaId",
                table: "ProizvodBoja",
                column: "ProizvodBojaId");
        }
    }
}
