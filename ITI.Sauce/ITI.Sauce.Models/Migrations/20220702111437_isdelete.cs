using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI.Sauce.Models.Migrations
{
    public partial class isdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "registerDate",
                table: "Vendor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 13, 14, 37, 442, DateTimeKind.Local).AddTicks(2695),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 28, 19, 31, 39, 379, DateTimeKind.Local).AddTicks(3645));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Restaurant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 13, 14, 37, 443, DateTimeKind.Local).AddTicks(387),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 28, 19, 31, 39, 380, DateTimeKind.Local).AddTicks(7457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Recipe",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 13, 14, 37, 441, DateTimeKind.Local).AddTicks(2833),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 28, 19, 31, 39, 374, DateTimeKind.Local).AddTicks(4427));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Category");

            migrationBuilder.AlterColumn<DateTime>(
                name: "registerDate",
                table: "Vendor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 28, 19, 31, 39, 379, DateTimeKind.Local).AddTicks(3645),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 13, 14, 37, 442, DateTimeKind.Local).AddTicks(2695));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Restaurant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 28, 19, 31, 39, 380, DateTimeKind.Local).AddTicks(7457),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 13, 14, 37, 443, DateTimeKind.Local).AddTicks(387));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Recipe",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 28, 19, 31, 39, 374, DateTimeKind.Local).AddTicks(4427),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 13, 14, 37, 441, DateTimeKind.Local).AddTicks(2833));
        }
    }
}
