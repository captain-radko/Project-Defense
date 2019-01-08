using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdeGames.Data.Migrations
{
    public partial class OrderOnEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OrderOn",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderOn",
                table: "Orders");
        }
    }
}
