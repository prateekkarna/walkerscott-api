using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wakerscott_integration.Migrations
{
    /// <inheritdoc />
    public partial class intialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "NewsCategory",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 11, 20, 51, 30, 868, DateTimeKind.Local).AddTicks(4244),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "NewsArticles",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 11, 20, 51, 30, 867, DateTimeKind.Local).AddTicks(3708),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "NewsCategory",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 11, 20, 51, 30, 868, DateTimeKind.Local).AddTicks(4244));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "NewsArticles",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 11, 20, 51, 30, 867, DateTimeKind.Local).AddTicks(3708));
        }
    }
}
