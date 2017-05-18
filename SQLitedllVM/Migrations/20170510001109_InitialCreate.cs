using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SQLitedllVM.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UsernumberID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BusinessName = table.Column<string>(maxLength: 12, nullable: true),
                    ContactNumber = table.Column<string>(maxLength: 16, nullable: true),
                    Username = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UsernumberID);
                });

            migrationBuilder.CreateTable(
                name: "UserPoints",
                columns: table => new
                {
                    PointId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Invoicenumber = table.Column<string>(nullable: true),
                    Pointname = table.Column<string>(nullable: false),
                    Signedoff = table.Column<bool>(nullable: false),
                    UserIDFK = table.Column<int>(nullable: false),
                    UsernumberID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPoints", x => x.PointId);
                    table.ForeignKey(
                        name: "FK_UserPoints_Users_UsernumberID",
                        column: x => x.UsernumberID,
                        principalTable: "Users",
                        principalColumn: "UsernumberID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPoints_UsernumberID",
                table: "UserPoints",
                column: "UsernumberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPoints");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
