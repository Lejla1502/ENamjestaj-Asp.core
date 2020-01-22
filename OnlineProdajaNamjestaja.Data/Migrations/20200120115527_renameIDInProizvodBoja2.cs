using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class renameIDInProizvodBoja2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProizvodBoja",
                newName: "ProizvodBojaId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProizvodBoja_ProizvodBojaId",
                table: "ProizvodBoja",
                column: "ProizvodBojaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProizvodBoja_ProizvodBojaId",
                table: "ProizvodBoja");

            migrationBuilder.RenameColumn(
                name: "ProizvodBojaId",
                table: "ProizvodBoja",
                newName: "Id");
        }
    }
}
