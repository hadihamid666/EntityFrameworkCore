using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTeamTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Teams");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 28, 9, 42, 22, 185, DateTimeKind.Unspecified).AddTicks(4165));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 28, 9, 42, 22, 185, DateTimeKind.Unspecified).AddTicks(4171));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 28, 9, 42, 22, 185, DateTimeKind.Unspecified).AddTicks(4172));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Teams",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "TeamId" },
                values: new object[] { new DateTime(2025, 7, 23, 12, 19, 28, 374, DateTimeKind.Unspecified).AddTicks(1614), null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "TeamId" },
                values: new object[] { new DateTime(2025, 7, 23, 12, 19, 28, 374, DateTimeKind.Unspecified).AddTicks(1621), null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "TeamId" },
                values: new object[] { new DateTime(2025, 7, 23, 12, 19, 28, 374, DateTimeKind.Unspecified).AddTicks(1622), null });
        }
    }
}
