using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData_Into_Teams_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 16, 10, 10, 10, 792, DateTimeKind.Unspecified).AddTicks(7620), "Tivoli Gardens F.C." },
                    { 2, new DateTime(2025, 7, 16, 10, 10, 10, 792, DateTimeKind.Unspecified).AddTicks(7627), "Waterhouse F.C." },
                    { 3, new DateTime(2025, 7, 16, 10, 10, 10, 792, DateTimeKind.Unspecified).AddTicks(7628), "Humble Lions F.C." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3);
        }
    }
}
