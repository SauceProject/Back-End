using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI.Sauce.Models.Migrations
{
    public partial class fixmembership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "MemberShip");

            migrationBuilder.AlterColumn<DateTime>(
                name: "registerDate",
                table: "Vendor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 27, 13, 35, 23, 896, DateTimeKind.Local).AddTicks(8505),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 22, 1, 15, 869, DateTimeKind.Local).AddTicks(4919));

            migrationBuilder.AlterColumn<DateTime>(
                name: "registerDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 27, 13, 35, 23, 894, DateTimeKind.Local).AddTicks(65),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 22, 1, 15, 868, DateTimeKind.Local).AddTicks(6036));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Restaurant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 27, 13, 35, 23, 898, DateTimeKind.Local).AddTicks(1312),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 22, 1, 15, 870, DateTimeKind.Local).AddTicks(1681));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Recipe",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 27, 13, 35, 23, 892, DateTimeKind.Local).AddTicks(7466),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 22, 1, 15, 867, DateTimeKind.Local).AddTicks(5468));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "registerDate",
                table: "Vendor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 22, 1, 15, 869, DateTimeKind.Local).AddTicks(4919),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 27, 13, 35, 23, 896, DateTimeKind.Local).AddTicks(8505));

            migrationBuilder.AlterColumn<DateTime>(
                name: "registerDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 22, 1, 15, 868, DateTimeKind.Local).AddTicks(6036),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 27, 13, 35, 23, 894, DateTimeKind.Local).AddTicks(65));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Restaurant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 22, 1, 15, 870, DateTimeKind.Local).AddTicks(1681),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 27, 13, 35, 23, 898, DateTimeKind.Local).AddTicks(1312));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Recipe",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 22, 1, 15, 867, DateTimeKind.Local).AddTicks(5468),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 27, 13, 35, 23, 892, DateTimeKind.Local).AddTicks(7466));

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "MemberShip",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }
    }
}
