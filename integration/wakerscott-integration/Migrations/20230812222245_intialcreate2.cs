using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wakerscott_integration.Migrations
{
    /// <inheritdoc />
    public partial class intialcreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2023, 8, 11, 21, 0, 38, 169, DateTimeKind.Local).AddTicks(6206));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "NewsArticles",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 13, 3, 52, 45, 161, DateTimeKind.Local).AddTicks(3460),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 11, 21, 0, 38, 169, DateTimeKind.Local).AddTicks(464));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "NewsCategory",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 11, 21, 0, 38, 169, DateTimeKind.Local).AddTicks(6206),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 13, 3, 52, 45, 162, DateTimeKind.Local).AddTicks(1171));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "NewsArticles",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 11, 21, 0, 38, 169, DateTimeKind.Local).AddTicks(464),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 13, 3, 52, 45, 161, DateTimeKind.Local).AddTicks(3460));
        }
    }
}
