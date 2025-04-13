using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instagram_Backend.Migrations
{
    /// <inheritdoc />
    public partial class FixConfigUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8eec890b-3f11-4f44-9a53-c1f2f53f2111", "3a70af03-98ac-4fd0-bb6f-74e3c5a118a7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c4e0281a-6494-450e-8290-9bcbc744e106", "158801a5-2d05-427d-9dae-28399cbf5679" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3532c2aa-6deb-4f07-8a34-b809edc51cba", "ad486d48-a9cc-48e3-b9be-4240cd0dd7e7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
