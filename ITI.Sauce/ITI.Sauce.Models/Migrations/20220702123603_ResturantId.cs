using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI.Sauce.Models.Migrations
{
    public partial class ResturantId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "registerDate",
                table: "Vendor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 14, 36, 2, 790, DateTimeKind.Local).AddTicks(8145),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 28, 19, 31, 39, 379, DateTimeKind.Local).AddTicks(3645));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Restaurant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 14, 36, 2, 791, DateTimeKind.Local).AddTicks(4785),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 28, 19, 31, 39, 380, DateTimeKind.Local).AddTicks(7457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Recipe",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 14, 36, 2, 788, DateTimeKind.Local).AddTicks(9247),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 28, 19, 31, 39, 374, DateTimeKind.Local).AddTicks(4427));

            migrationBuilder.AddColumn<int>(
                name: "ResturantID",
                table: "Recipe",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_ResturantID",
                table: "Recipe",
                column: "ResturantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Restaurant_ResturantID",
                table: "Recipe",
                column: "ResturantID",
                principalTable: "Restaurant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Restaurant_ResturantID",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_ResturantID",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "ResturantID",
                table: "Recipe");

            migrationBuilder.AlterColumn<DateTime>(
                name: "registerDate",
                table: "Vendor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 28, 19, 31, 39, 379, DateTimeKind.Local).AddTicks(3645),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 14, 36, 2, 790, DateTimeKind.Local).AddTicks(8145));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Restaurant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 28, 19, 31, 39, 380, DateTimeKind.Local).AddTicks(7457),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 14, 36, 2, 791, DateTimeKind.Local).AddTicks(4785));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Recipe",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 28, 19, 31, 39, 374, DateTimeKind.Local).AddTicks(4427),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 14, 36, 2, 788, DateTimeKind.Local).AddTicks(9247));
        }
    }
}
