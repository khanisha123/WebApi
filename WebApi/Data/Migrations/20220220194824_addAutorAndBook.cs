using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Data.Migrations
{
    public partial class addAutorAndBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Products",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 20, 19, 48, 23, 856, DateTimeKind.Utc).AddTicks(8734),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 16, 20, 17, 48, 570, DateTimeKind.Utc).AddTicks(1872));

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 16, 20, 17, 48, 570, DateTimeKind.Utc).AddTicks(1872),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 2, 20, 19, 48, 23, 856, DateTimeKind.Utc).AddTicks(8734));
        }
    }
}
