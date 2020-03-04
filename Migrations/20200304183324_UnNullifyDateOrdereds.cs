using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscInventory.Migrations
{
    public partial class UnNullifyDateOrdereds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrdered",
                table: "Discs",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrdered",
                table: "Discs",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
