using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FarmLabService.Migrations
{
    public partial class userAndSessionChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Farm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: false),
                    ExternalFarmReference = table.Column<Guid>(nullable: false),
                    TimeCreate = table.Column<DateTime>(nullable: false),
                    TimeModify = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsValid = table.Column<bool>(nullable: false),
                    LastActivity = table.Column<DateTime>(nullable: false),
                    SessionKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActiveSessionId = table.Column<int>(nullable: true),
                    DisplayName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    FarmId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    IsConfirmedByMail = table.Column<bool>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    TimeCreate = table.Column<DateTime>(nullable: false),
                    TimeModify = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Session_ActiveSessionId",
                        column: x => x.ActiveSessionId,
                        principalTable: "Session",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Farm_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_ActiveSessionId",
                table: "User",
                column: "ActiveSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_FarmId",
                table: "User",
                column: "FarmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Farm");
        }
    }
}
