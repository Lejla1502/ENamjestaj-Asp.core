﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class addAktivanToAkcijskiKatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aktivan",
                table: "AkcijskiKatalog",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aktivan",
                table: "AkcijskiKatalog");
        }
    }
}
