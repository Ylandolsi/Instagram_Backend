using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instagram_Backend.Migrations
{
    /// <inheritdoc />
    public partial class fixSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5e2927a4-95e8-4e4f-b65f-c6fca8c9b45f", "a63fd633-e6f9-45da-83b0-6b7b7e576a1d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e44237da-08a3-4736-b56a-ed8f8f618933", "4c46cc49-a1f8-41d0-81f9-cee7c9fad46a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "32a7d7fe-4e80-45c4-bb52-d17fce4254b8", "dba74a07-3aee-49cf-8326-12019d54efe5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "adae4445-ecf6-4fb2-a7e3-25d04cfe3fe9", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "77cbcba0-e069-4b81-aea0-5495ca4dfb99", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5bd3d7d5-a190-4ebe-890f-fb9fe4f88f07", null });
        }
    }
}
