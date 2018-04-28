using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmLabService.Migrations
{
    public partial class Start_lab_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Session");

            migrationBuilder.AddColumn<int>(
                name: "FK_User_ActiveSession",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FK_Session_BelongToUser",
                table: "Session",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_FK_User_ActiveSession",
                table: "User",
                column: "FK_User_ActiveSession");

            migrationBuilder.CreateIndex(
                name: "IX_Session_FK_Session_BelongToUser",
                table: "Session",
                column: "FK_Session_BelongToUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_User_FK_Session_BelongToUser",
                table: "Session",
                column: "FK_Session_BelongToUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Session_FK_User_ActiveSession",
                table: "User",
                column: "FK_User_ActiveSession",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_User_FK_Session_BelongToUser",
                table: "Session");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Session_FK_User_ActiveSession",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_FK_User_ActiveSession",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Session_FK_Session_BelongToUser",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "FK_User_ActiveSession",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FK_Session_BelongToUser",
                table: "Session");

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Session",
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
    }
}
