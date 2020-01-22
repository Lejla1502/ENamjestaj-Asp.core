using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class removeIDFromProizvodBoja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProizvodBoja_Id",
                table: "ProizvodBoja");

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProizvodBoja",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProizvodBoja_Id",
                table: "ProizvodBoja",
                column: "Id");
        }
    }
}
