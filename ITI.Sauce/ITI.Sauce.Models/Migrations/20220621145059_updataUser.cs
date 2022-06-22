using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI.Sauce.Models.Migrations
{
    public partial class updataUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "registerDate",
                table: "Vendor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 21, 16, 50, 58, 752, DateTimeKind.Local).AddTicks(1018),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 16, 40, 58, 56, DateTimeKind.Local).AddTicks(348));

            migrationBuilder.AlterColumn<DateTime>(
                name: "registerDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 21, 16, 50, 58, 751, DateTimeKind.Local).AddTicks(3136),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Restaurant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 21, 16, 50, 58, 752, DateTimeKind.Local).AddTicks(7124),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 16, 40, 58, 57, DateTimeKind.Local).AddTicks(2109));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Recipe",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 21, 16, 50, 58, 750, DateTimeKind.Local).AddTicks(3876),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 16, 40, 58, 52, DateTimeKind.Local).AddTicks(6491));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "registerDate",
                table: "Vendor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 16, 40, 58, 56, DateTimeKind.Local).AddTicks(348),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 21, 16, 50, 58, 752, DateTimeKind.Local).AddTicks(1018));

            migrationBuilder.AlterColumn<DateTime>(
                name: "registerDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 21, 16, 50, 58, 751, DateTimeKind.Local).AddTicks(3136));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Restaurant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 16, 40, 58, 57, DateTimeKind.Local).AddTicks(2109),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 21, 16, 50, 58, 752, DateTimeKind.Local).AddTicks(7124));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Recipe",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 16, 40, 58, 52, DateTimeKind.Local).AddTicks(6491),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 21, 16, 50, 58, 750, DateTimeKind.Local).AddTicks(3876));
        }
    }
}
