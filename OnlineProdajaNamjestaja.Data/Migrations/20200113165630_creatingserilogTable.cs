using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineProdajaNamjestaja.Data.Migrations
{
    public partial class creatingserilogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Kupac_KupacId",
                table: "Log");

            migrationBuilder.DropIndex(
                name: "IX_Log_KupacId",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "KupacId",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "PropertiesXml",
                table: "Log");

            migrationBuilder.RenameColumn(
                name: "Vrijeme",
                table: "Log",
                newName: "TimeStamp");

            migrationBuilder.RenameColumn(
                name: "TemplatePoruke",
                table: "Log",
                newName: "Properties");

            migrationBuilder.RenameColumn(
                name: "Poruka",
                table: "Log",
                newName: "MessageTemplate");

            migrationBuilder.RenameColumn(
                name: "OtherData",
                table: "Log",
                newName: "Message");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "Log",
                newName: "Vrijeme");

            migrationBuilder.RenameColumn(
                name: "Properties",
                table: "Log",
                newName: "TemplatePoruke");

            migrationBuilder.RenameColumn(
                name: "MessageTemplate",
                table: "Log",
                newName: "Poruka");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Log",
                newName: "OtherData");

            migrationBuilder.AddColumn<int>(
                name: "KupacId",
                table: "Log",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PropertiesXml",
                table: "Log",
                type: "xml",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Log_KupacId",
                table: "Log",
                column: "KupacId");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Kupac_KupacId",
                table: "Log",
                column: "KupacId",
                principalTable: "Kupac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
