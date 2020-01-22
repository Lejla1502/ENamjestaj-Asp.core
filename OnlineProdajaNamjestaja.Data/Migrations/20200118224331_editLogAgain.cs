using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class editLogAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Message",
                table: "Log");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Log",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "Log",
                newName: "Timestamp");

            migrationBuilder.RenameColumn(
                name: "Properties",
                table: "Log",
                newName: "IPAddress");

            migrationBuilder.RenameColumn(
                name: "MessageTemplate",
                table: "Log",
                newName: "AreaAccessed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Log",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Log",
                newName: "TimeStamp");

            migrationBuilder.RenameColumn(
                name: "IPAddress",
                table: "Log",
                newName: "Properties");

            migrationBuilder.RenameColumn(
                name: "AreaAccessed",
                table: "Log",
                newName: "MessageTemplate");

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
                name: "Message",
                table: "Log",
                nullable: true);
        }
    }
}
