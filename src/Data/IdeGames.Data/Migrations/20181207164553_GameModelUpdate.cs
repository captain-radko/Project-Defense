using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdeGames.Data.Migrations
{
    public partial class GameModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Games",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Games");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Games",
                nullable: true);
        }
    }
}
