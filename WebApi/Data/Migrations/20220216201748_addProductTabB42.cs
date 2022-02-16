using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Data.Migrations
{
    public partial class addProductTabB42 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 16, 20, 17, 48, 570, DateTimeKind.Utc).AddTicks(1872),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 16, 20, 14, 17, 730, DateTimeKind.Utc).AddTicks(4359));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 16, 20, 14, 17, 730, DateTimeKind.Utc).AddTicks(4359),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 2, 16, 20, 17, 48, 570, DateTimeKind.Utc).AddTicks(1872));
        }
    }
}
