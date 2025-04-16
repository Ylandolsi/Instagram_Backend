using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Instagram_Backend.Migrations
{
    /// <inheritdoc />
    public partial class updateSeedPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("a3333333-a333-a333-a333-a33333333333"),
                columns: new[] { "Caption", "CommentCount", "LikeCount", "UserId" },
                values: new object[] { "My homemade pasta recipe 🍝", 3, 42, new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Caption", "CommentCount", "CreatedAt", "LikeCount", "UserId" },
                values: new object[,]
                {
                    { new Guid("1db23406-a17b-4dc8-bea7-2beac2933616"), "Beautiful sunset at the beach!", 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("33275ae4-f405-4f6a-983a-ad5bec64abde"), "Beautiful sunset at the beach!", 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("4410a87d-a7d8-4608-9355-6a612888d6d1"), "Beautiful sunset at the beach!", 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("4a5ba864-e9e8-42e2-b7a9-061f4c789e63"), "New coding setup complete", 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 28, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("52ad77c5-1da0-444b-b125-5f85bc231b7a"), "New coding setup complete", 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 28, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("75a6a545-2e08-4b67-a1fe-86f35d703b19"), "New coding setup complete", 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 28, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("8054e0e8-68e1-46d2-987d-4132868e3b72"), "Beautiful sunset at the beach!", 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("835d699d-9448-4340-9475-25b73b2e244a"), "New coding setup complete", 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 28, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("8764c2ac-7fc1-49ae-bd74-25d366a2fe4e"), "My homemade pasta recipe 🍝", 3, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 42, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("90b398a9-db7d-479e-88b7-d8e704a24d6e"), "New coding setup complete", 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 28, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("a6505049-5dcb-43ec-bbbc-021cad8cacb9"), "New coding setup complete", 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 28, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("e7f3533b-b28c-41da-8a19-5bb165d295ec"), "Beautiful sunset at the beach!", 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "18b61af4-63d7-4db3-9296-6c171e95303b", "38cb28e5-3f8a-45da-9a6f-51f8ef1925c4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "33a7ad33-02cc-42b1-9da2-e4113e226c8d", "13275aef-b9e8-4c26-bdda-8168aaecd01c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2219cfa2-8539-4e2f-81a1-3c9a50149dae", "9f47581a-31e0-4f9c-84f3-8ccfa0427ad0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("1db23406-a17b-4dc8-bea7-2beac2933616"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("33275ae4-f405-4f6a-983a-ad5bec64abde"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("4410a87d-a7d8-4608-9355-6a612888d6d1"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("4a5ba864-e9e8-42e2-b7a9-061f4c789e63"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("52ad77c5-1da0-444b-b125-5f85bc231b7a"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("75a6a545-2e08-4b67-a1fe-86f35d703b19"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("8054e0e8-68e1-46d2-987d-4132868e3b72"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("835d699d-9448-4340-9475-25b73b2e244a"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("8764c2ac-7fc1-49ae-bd74-25d366a2fe4e"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("90b398a9-db7d-479e-88b7-d8e704a24d6e"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("a6505049-5dcb-43ec-bbbc-021cad8cacb9"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("e7f3533b-b28c-41da-8a19-5bb165d295ec"));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("a3333333-a333-a333-a333-a33333333333"),
                columns: new[] { "Caption", "CommentCount", "LikeCount", "UserId" },
                values: new object[] { "New coding setup complete", 4, 28, new Guid("33333333-3333-3333-3333-333333333333") });

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
    }
}
