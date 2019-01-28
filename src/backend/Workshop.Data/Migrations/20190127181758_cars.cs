using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workshop.Data.Migrations
{
    public partial class cars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Cars",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Cars", x => x.Id); });

            migrationBuilder.CreateTable(
                "CarImages",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarImages", x => x.Id);
                    table.ForeignKey(
                        "FK_CarImages_Cars_CarId",
                        x => x.CarId,
                        "Cars",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_CarImages_CarId",
                "CarImages",
                "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "CarImages");

            migrationBuilder.DropTable(
                "Cars");
        }
    }
}