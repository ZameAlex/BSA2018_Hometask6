using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BSA2018_Hometask4.DAL.Migrations
{
    public partial class TimeSpanToDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Expired",
                table: "Planes",
                nullable: false,
                oldClrType: typeof(TimeSpan));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Expired",
                table: "Planes",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
