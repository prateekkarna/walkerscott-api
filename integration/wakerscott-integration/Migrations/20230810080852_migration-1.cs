using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wakerscott_integration.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "NewsCategory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "NewsCategory",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "NewsCategory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "NewsCategory",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "NewsArticles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "NewsArticles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "NewsArticles",
                type: "datetime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "NewsCategory");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "NewsCategory");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "NewsCategory");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "NewsCategory");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "NewsArticles");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "NewsArticles");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "NewsArticles");
        }
    }
}
