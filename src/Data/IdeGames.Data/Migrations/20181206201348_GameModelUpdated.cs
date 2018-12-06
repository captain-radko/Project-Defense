using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdeGames.Data.Migrations
{
    public partial class GameModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "News");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "News",
                nullable: true);
        }
    }
}
