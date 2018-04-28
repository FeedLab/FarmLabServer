using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FarmLabService.Migrations
{
    public partial class userAndSessionChange_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Session_ActiveSessionId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ActiveSessionId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ActiveSessionId",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Session",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Session_UserId",
                table: "Session",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Session_User_UserId",
                table: "Session",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_User_UserId",
                table: "Session");

            migrationBuilder.DropIndex(
                name: "IX_Session_UserId",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Session");

            migrationBuilder.AddColumn<int>(
                name: "ActiveSessionId",
                table: "User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ActiveSessionId",
                table: "User",
                column: "ActiveSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Session_ActiveSessionId",
                table: "User",
                column: "ActiveSessionId",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
