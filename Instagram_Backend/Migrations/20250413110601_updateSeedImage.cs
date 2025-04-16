using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Instagram_Backend.Migrations
{
    /// <inheritdoc />
    public partial class updateSeedImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Caption", "CommentCount", "CreatedAt", "LikeCount", "UserId" },
                values: new object[,]
                {
                    { new Guid("23d2825d-2036-463b-b3b8-ccd4c6bd1f21"), "New coding setup complete", 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 28, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("2d19abbd-c954-43ce-9260-5b657ac01a40"), "New coding setup complete", 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 28, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("34000535-d3e2-4dd3-84c7-1d53860c1e50"), "New coding setup complete", 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 28, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("3afa0420-8c57-41dd-b2a9-ccc7b046ec03"), "Beautiful sunset at the beach!", 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("5f6341cd-5750-4531-9c6e-1c34e279d79f"), "New coding setup complete", 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 28, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("735a7d92-1ac6-445b-ae36-4e73c1aaf87b"), "Beautiful sunset at the beach!", 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("8e28939b-cd7f-4eed-be12-fb1524facac7"), "My homemade pasta recipe 🍝", 3, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 42, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("977143a3-02d5-4e0b-a43f-7de66a1a2092"), "New coding setup complete", 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 28, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("9d86b0ad-f998-4dc6-8de9-05fc95412450"), "Beautiful sunset at the beach!", 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("bde50254-1861-4233-b4f0-7e978971bbd6"), "Beautiful sunset at the beach!", 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c203212b-fc5b-446e-a950-552498d2d1b8"), "New coding setup complete", 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 28, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("e1bc7d1b-308e-4f8c-9d4d-f92dbf22e414"), "Beautiful sunset at the beach!", 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6b810364-fd8b-45b1-b4a3-6768bb457bce", "4b92b2fb-8d85-435e-a96c-02d15870b5e2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7ad093c0-7a87-4930-b419-ba99daef425b", "63222f5e-90c3-47ef-9cb7-48d66399c1bb" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "71b590a1-a75b-4896-9c7c-4c53f5175515", "b8dd465b-c95d-4d1d-81b2-0e56da8c00e1" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Order", "PostId", "Url" },
                values: new object[,]
                {
                    { new Guid("1c321a78-d2f4-4d6d-a4a2-c41258f4a721"), 1, new Guid("9d86b0ad-f998-4dc6-8de9-05fc95412450"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("2850de1f-c4dc-417e-8d70-1a0b29fa93e4"), 1, new Guid("8e28939b-cd7f-4eed-be12-fb1524facac7"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("34ef753d-d2b4-4f3a-a981-a82ffe042b58"), 1, new Guid("34000535-d3e2-4dd3-84c7-1d53860c1e50"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("3558fc62-455d-4404-b35b-2a698859ea94"), 3, new Guid("e1bc7d1b-308e-4f8c-9d4d-f92dbf22e414"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("357c596b-e643-48d2-b984-074480a7175f"), 2, new Guid("2d19abbd-c954-43ce-9260-5b657ac01a40"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("35b5c7fc-87de-440c-87a1-ec72a25ed10e"), 2, new Guid("977143a3-02d5-4e0b-a43f-7de66a1a2092"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("3b8ed702-791e-4f62-b0e9-e747e9befa71"), 1, new Guid("735a7d92-1ac6-445b-ae36-4e73c1aaf87b"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("4ddd97a3-30ef-4103-a7f6-06ee062bc8dc"), 1, new Guid("977143a3-02d5-4e0b-a43f-7de66a1a2092"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("7e1e17a2-c58c-4276-9295-9d2fd7e27513"), 1, new Guid("bde50254-1861-4233-b4f0-7e978971bbd6"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("7e924072-271b-4afb-96ac-a09d8b457f19"), 1, new Guid("2d19abbd-c954-43ce-9260-5b657ac01a40"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("835afa55-7344-42e7-8e59-5057eb6594d2"), 1, new Guid("c203212b-fc5b-446e-a950-552498d2d1b8"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("95d4685a-55dd-4831-9725-0001d735e0a0"), 1, new Guid("23d2825d-2036-463b-b3b8-ccd4c6bd1f21"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("be5ca388-333e-42a3-860c-878a810a7069"), 1, new Guid("5f6341cd-5750-4531-9c6e-1c34e279d79f"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("c1744aea-6364-4ca6-895c-342bdfc78dbb"), 2, new Guid("e1bc7d1b-308e-4f8c-9d4d-f92dbf22e414"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("caef3abc-1c05-403a-b705-1ea8d8dc120b"), 1, new Guid("3afa0420-8c57-41dd-b2a9-ccc7b046ec03"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("fa68e757-da98-4d29-8ccf-8f93a7c76a2b"), 1, new Guid("e1bc7d1b-308e-4f8c-9d4d-f92dbf22e414"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("faebe4a8-76d2-4268-ab1c-45864491ab8b"), 4, new Guid("e1bc7d1b-308e-4f8c-9d4d-f92dbf22e414"), "https://picsum.photos/id/4/800/800" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("1c321a78-d2f4-4d6d-a4a2-c41258f4a721"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("2850de1f-c4dc-417e-8d70-1a0b29fa93e4"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("34ef753d-d2b4-4f3a-a981-a82ffe042b58"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3558fc62-455d-4404-b35b-2a698859ea94"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("357c596b-e643-48d2-b984-074480a7175f"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("35b5c7fc-87de-440c-87a1-ec72a25ed10e"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3b8ed702-791e-4f62-b0e9-e747e9befa71"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("4ddd97a3-30ef-4103-a7f6-06ee062bc8dc"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7e1e17a2-c58c-4276-9295-9d2fd7e27513"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7e924072-271b-4afb-96ac-a09d8b457f19"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("835afa55-7344-42e7-8e59-5057eb6594d2"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("95d4685a-55dd-4831-9725-0001d735e0a0"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("be5ca388-333e-42a3-860c-878a810a7069"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c1744aea-6364-4ca6-895c-342bdfc78dbb"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("caef3abc-1c05-403a-b705-1ea8d8dc120b"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("fa68e757-da98-4d29-8ccf-8f93a7c76a2b"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("faebe4a8-76d2-4268-ab1c-45864491ab8b"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("23d2825d-2036-463b-b3b8-ccd4c6bd1f21"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("2d19abbd-c954-43ce-9260-5b657ac01a40"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("34000535-d3e2-4dd3-84c7-1d53860c1e50"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("3afa0420-8c57-41dd-b2a9-ccc7b046ec03"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("5f6341cd-5750-4531-9c6e-1c34e279d79f"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("735a7d92-1ac6-445b-ae36-4e73c1aaf87b"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("8e28939b-cd7f-4eed-be12-fb1524facac7"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("977143a3-02d5-4e0b-a43f-7de66a1a2092"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("9d86b0ad-f998-4dc6-8de9-05fc95412450"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("bde50254-1861-4233-b4f0-7e978971bbd6"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("c203212b-fc5b-446e-a950-552498d2d1b8"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("e1bc7d1b-308e-4f8c-9d4d-f92dbf22e414"));

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
    }
}
