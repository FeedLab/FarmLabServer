using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FarmLabService.Migrations
{
    public partial class xxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FarmId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Farm",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    FarmName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farm", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_FarmId",
                table: "Users",
                column: "FarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Farm_FarmId",
                table: "Users",
                column: "FarmId",
                principalTable: "Farm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Farm_FarmId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Farm");

            migrationBuilder.DropIndex(
                name: "IX_Users_FarmId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "Users");
        }
    }
}
