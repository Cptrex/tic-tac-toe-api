using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTacToe.Migrations
{
    /// <inheritdoc />
    public partial class fixesWinnerField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "winner",
                table: "rooms",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created",
                table: "rooms",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 8, 2, 11, 3, 851, DateTimeKind.Utc).AddTicks(8329),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 8, 2, 4, 40, 116, DateTimeKind.Utc).AddTicks(979));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "rooms",
                keyColumn: "winner",
                keyValue: null,
                column: "winner",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "winner",
                table: "rooms",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created",
                table: "rooms",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 8, 2, 4, 40, 116, DateTimeKind.Utc).AddTicks(979),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 3, 8, 2, 11, 3, 851, DateTimeKind.Utc).AddTicks(8329));
        }
    }
}
