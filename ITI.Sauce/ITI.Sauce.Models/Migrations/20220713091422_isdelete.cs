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
                defaultValue: new DateTime(2022, 7, 13, 11, 14, 22, 358, DateTimeKind.Local).AddTicks(3768),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 21, 4, 3, 94, DateTimeKind.Local).AddTicks(4963));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Restaurant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 13, 11, 14, 22, 359, DateTimeKind.Local).AddTicks(2385),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 21, 4, 3, 95, DateTimeKind.Local).AddTicks(4354));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Recipe",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 13, 11, 14, 22, 355, DateTimeKind.Local).AddTicks(8949),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 21, 4, 3, 92, DateTimeKind.Local).AddTicks(4331));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Rating",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Rating");

            migrationBuilder.AlterColumn<DateTime>(
                name: "registerDate",
                table: "Vendor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 21, 4, 3, 94, DateTimeKind.Local).AddTicks(4963),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 13, 11, 14, 22, 358, DateTimeKind.Local).AddTicks(3768));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Restaurant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 21, 4, 3, 95, DateTimeKind.Local).AddTicks(4354),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 13, 11, 14, 22, 359, DateTimeKind.Local).AddTicks(2385));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Recipe",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 21, 4, 3, 92, DateTimeKind.Local).AddTicks(4331),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 13, 11, 14, 22, 355, DateTimeKind.Local).AddTicks(8949));
        }
    }
}
