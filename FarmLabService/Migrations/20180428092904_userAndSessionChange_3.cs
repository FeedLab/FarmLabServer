using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FarmLabService.Migrations
{
    public partial class userAndSessionChange_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_User_UserId",
                table: "Session");

            migrationBuilder.DropIndex(
                name: "IX_Session_UserId",
                table: "Session");

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_SessionId",
                table: "User",
                column: "SessionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Session_SessionId",
                table: "User",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Session_SessionId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_SessionId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "User");

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
    }
}
