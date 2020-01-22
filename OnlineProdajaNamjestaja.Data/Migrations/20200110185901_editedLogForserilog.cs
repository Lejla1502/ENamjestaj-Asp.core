using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class editedLogForserilog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Akcija",
                table: "Log",
                newName: "TemplatePoruke");

            migrationBuilder.AddColumn<string>(
                name: "Exception",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogEvent",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Poruka",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertiesXml",
                table: "Log",
                type: "xml",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exception",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "LogEvent",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Poruka",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "PropertiesXml",
                table: "Log");

            migrationBuilder.RenameColumn(
                name: "TemplatePoruke",
                table: "Log",
                newName: "Akcija");
        }
    }
}
