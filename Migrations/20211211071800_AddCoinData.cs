using Microsoft.EntityFrameworkCore.Migrations;

namespace Salvus.Migrations
{
    public partial class AddCoinData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "Coins",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Coins",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AddColumn<float>(
                name: "DayChange",
                table: "Coins",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "High",
                table: "Coins",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<long>(
                name: "Marketcap",
                table: "Coins",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Coins",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<long>(
                name: "Volume",
                table: "Coins",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<float>(
                name: "WeekChange",
                table: "Coins",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayChange",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "High",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "Marketcap",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "WeekChange",
                table: "Coins");

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "Coins",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Coins",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
