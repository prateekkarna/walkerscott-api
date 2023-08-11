using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wakerscott_integration.Migrations
{
    /// <inheritdoc />
    public partial class intialcreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2023, 8, 11, 20, 51, 30, 868, DateTimeKind.Local).AddTicks(4244));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "NewsArticles",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "NewsArticles",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 11, 21, 0, 38, 169, DateTimeKind.Local).AddTicks(464),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 11, 20, 51, 30, 867, DateTimeKind.Local).AddTicks(3708));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "NewsCategory",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 11, 20, 51, 30, 868, DateTimeKind.Local).AddTicks(4244),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 11, 21, 0, 38, 169, DateTimeKind.Local).AddTicks(6206));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "NewsArticles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "NewsArticles",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 11, 20, 51, 30, 867, DateTimeKind.Local).AddTicks(3708),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 11, 21, 0, 38, 169, DateTimeKind.Local).AddTicks(464));
        }
    }
}
