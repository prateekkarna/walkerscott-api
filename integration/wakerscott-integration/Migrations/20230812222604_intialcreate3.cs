using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wakerscott_integration.Migrations
{
    /// <inheritdoc />
    public partial class intialcreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "NewsCategory",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 13, 3, 56, 4, 33, DateTimeKind.Local).AddTicks(2712),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 13, 3, 52, 45, 162, DateTimeKind.Local).AddTicks(1171));

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "NewsArticles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "NewsArticles",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 13, 3, 56, 4, 31, DateTimeKind.Local).AddTicks(9135),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 13, 3, 52, 45, 161, DateTimeKind.Local).AddTicks(3460));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "NewsCategory",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 13, 3, 52, 45, 162, DateTimeKind.Local).AddTicks(1171),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 13, 3, 56, 4, 33, DateTimeKind.Local).AddTicks(2712));

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "NewsArticles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "NewsArticles",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 13, 3, 52, 45, 161, DateTimeKind.Local).AddTicks(3460),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 13, 3, 56, 4, 31, DateTimeKind.Local).AddTicks(9135));
        }
    }
}
