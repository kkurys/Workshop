using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workshop.Data.Migrations
{
    public partial class carowner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                "OwnerId",
                "Cars",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                "IX_Cars_OwnerId",
                "Cars",
                "OwnerId");

            migrationBuilder.AddForeignKey(
                "FK_Cars_AspNetUsers_OwnerId",
                "Cars",
                "OwnerId",
                "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Cars_AspNetUsers_OwnerId",
                "Cars");

            migrationBuilder.DropIndex(
                "IX_Cars_OwnerId",
                "Cars");

            migrationBuilder.DropColumn(
                "OwnerId",
                "Cars");
        }
    }
}