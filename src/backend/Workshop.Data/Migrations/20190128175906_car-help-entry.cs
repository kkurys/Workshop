using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workshop.Data.Migrations
{
    public partial class carhelpentry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "CarHelpEntries",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarHelpEntries", x => x.Id);
                    table.ForeignKey(
                        "FK_CarHelpEntries_Cars_CarId",
                        x => x.CarId,
                        "Cars",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_CarHelpEntries_AspNetUsers_EmployeeId",
                        x => x.EmployeeId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_CarHelpEntries_CarId",
                "CarHelpEntries",
                "CarId");

            migrationBuilder.CreateIndex(
                "IX_CarHelpEntries_EmployeeId",
                "CarHelpEntries",
                "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "CarHelpEntries");
        }
    }
}