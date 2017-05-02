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
                    Username = table.Column<string>(nullable: false),
                    BusinessName = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    Password = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Data",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserdetailUsername = table.Column<string>(nullable: true),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Data_Users_UserdetailUsername",
                        column: x => x.UserdetailUsername,
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Data_UserdetailUsername",
                table: "Data",
                column: "UserdetailUsername");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Data");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
