using Microsoft.EntityFrameworkCore.Migrations;

namespace BSA2018_Hometask4.DAL.Migrations
{
    public partial class AttributesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Places",
                table: "Types",
                newName: "Seats");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Stewadresses",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pilots",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Depatures",
                newName: "DepartureDateTime");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Stewadresses",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Stewadresses",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Seats",
                table: "Types",
                newName: "Places");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Stewadresses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Pilots",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DepartureDateTime",
                table: "Depatures",
                newName: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Stewadresses",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stewadresses",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
