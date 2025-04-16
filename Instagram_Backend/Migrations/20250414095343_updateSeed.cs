using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Instagram_Backend.Migrations
{
    /// <inheritdoc />
    public partial class updateSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-c333-c333-c333-c33333333333"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c5555555-c555-c555-c555-c55555555555"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c7777777-c777-c777-c777-c77777777777"));

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
                keyValue: new Guid("b1111111-b111-b111-b111-b11111111111"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-b222-b222-b222-b22222222222"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b3333333-b333-b333-b333-b33333333333"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b4444444-b444-b444-b444-b44444444444"));

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
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("d1111111-d111-d111-d111-d11111111111"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("d2222222-d222-d222-d222-d22222222222"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("d3333333-d333-d333-d333-d33333333333"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("d4444444-d444-d444-d444-d44444444444"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("d5555555-d555-d555-d555-d55555555555"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("d6666666-d666-d666-d666-d66666666666"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("d7777777-d777-d777-d777-d77777777777"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("d8888888-d888-d888-d888-d88888888888"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("d9999999-d999-d999-d999-d99999999999"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("e1111111-e111-e111-e111-e11111111111"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("e2222222-e222-e222-e222-e22222222222"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("e3333333-e333-e333-e333-e33333333333"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("e4444444-e444-e444-e444-e44444444444"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("e5555555-e555-e555-e555-e55555555555"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("e6666666-e666-e666-e666-e66666666666"));

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("33333333-3333-3333-3333-333333333333"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("33333333-3333-3333-3333-333333333333"), new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-c222-c222-c222-c22222222222"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c4444444-c444-c444-c444-c44444444444"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c6666666-c666-c666-c666-c66666666666"));

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

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c1111111-c111-c111-c111-c11111111111"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-a222-a222-a222-a22222222222"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("a3333333-a333-a333-a333-a33333333333"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-a111-a111-a111-a11111111111"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "RefreshToken", "RefreshTokenExpiresAtUtc", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1be6db51-a961-4adf-8902-9f7edd2d1d4c"), 0, "Chef and food photographer", "2e9edf8f-b83d-4014-aafe-353a2e7495d3", "david@example.com", true, "David", "Wilson", false, null, "DAVID@EXAMPLE.COM", "DAVIDW", "AQAAAAIAAYagAAAAEG9Yh999XbrReKfYRF6NzknIDvSmTjBuDq4KQkfqZweYlubTSIOeVLFmxSD3tar1IA==", null, false, "https://randomuser.me/api/portraits/men/4.jpg", null, null, "83a09dfd-0569-48cf-9324-d9246f6eb057", false, "davidw" },
                    { new Guid("24005e30-4b5a-45b4-aab2-61aca02c8e7f"), 0, "Fashion designer and trend spotter", "ca67cf9f-5e46-4a26-8295-0f3ec6de65ca", "sophia@example.com", true, "Sophia", "Garcia", false, null, "SOPHIA@EXAMPLE.COM", "SOPHIAG", "AQAAAAIAAYagAAAAEG9Yh999XbrReKfYRF6NzknIDvSmTjBuDq4KQkfqZweYlubTSIOeVLFmxSD3tar1IA==", null, false, "https://randomuser.me/api/portraits/women/3.jpg", null, null, "0b8ccb92-1762-4952-9646-2d856844fee5", false, "sophiag" },
                    { new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79"), 0, "Photography enthusiast and traveler", "f9f59a15-6e52-4e0a-ae4f-103ff9108ea8", "john@example.com", true, "John", "Doe", false, null, "JOHN@EXAMPLE.COM", "JOHNDOE", "AQAAAAIAAYagAAAAEG9Yh999XbrReKfYRF6NzknIDvSmTjBuDq4KQkfqZweYlubTSIOeVLFmxSD3tar1IA==", null, false, "https://randomuser.me/api/portraits/men/1.jpg", null, null, "c04ef068-a56b-411f-8ef5-4ce1634d64db", false, "johndoe" },
                    { new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50"), 0, "Food blogger | Travel lover", "a2407ff9-0417-48f8-a310-a7612d28974e", "jane@example.com", true, "Jane", "Smith", false, null, "JANE@EXAMPLE.COM", "JANESMITH", "AQAAAAIAAYagAAAAEG9Yh999XbrReKfYRF6NzknIDvSmTjBuDq4KQkfqZweYlubTSIOeVLFmxSD3tar1IA==", null, false, "https://randomuser.me/api/portraits/women/1.jpg", null, null, "0ee12117-8112-43f1-9e10-6707910a119d", false, "janesmith" },
                    { new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5"), 0, "Software developer and coffee addict", "2d0e7e55-4e20-48b5-976a-ee019362b99a", "alex@example.com", true, "Alex", "Johnson", false, null, "ALEX@EXAMPLE.COM", "ALEXJ", "AQAAAAIAAYagAAAAEG9Yh999XbrReKfYRF6NzknIDvSmTjBuDq4KQkfqZweYlubTSIOeVLFmxSD3tar1IA==", null, false, "https://randomuser.me/api/portraits/men/2.jpg", null, null, "4d13b318-1f37-466d-9e71-a06e39b4f0e7", false, "alexj" },
                    { new Guid("c2e18fc7-6492-4081-8c19-8ba5e7c42005"), 0, "Fitness enthusiast and nutrition coach", "7c31ea13-62ba-4ac1-b205-7f54a43fa0ab", "michael@example.com", true, "Michael", "Taylor", false, null, "MICHAEL@EXAMPLE.COM", "MICHAELT", "AQAAAAIAAYagAAAAEG9Yh999XbrReKfYRF6NzknIDvSmTjBuDq4KQkfqZweYlubTSIOeVLFmxSD3tar1IA==", null, false, "https://randomuser.me/api/portraits/men/3.jpg", null, null, "91edc1c8-33ee-485b-b582-dcb6ee1d7ac2", false, "michaelt" },
                    { new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2"), 0, "Digital artist and designer", "c322bf2b-7341-4ae3-8f99-ba6c5b7dc09f", "emily@example.com", true, "Emily", "Chen", false, null, "EMILY@EXAMPLE.COM", "EMILYC", "AQAAAAIAAYagAAAAEG9Yh999XbrReKfYRF6NzknIDvSmTjBuDq4KQkfqZweYlubTSIOeVLFmxSD3tar1IA==", null, false, "https://randomuser.me/api/portraits/women/2.jpg", null, null, "9fa25bef-320e-4066-9674-27eeaae4d802", false, "emilyc" },
                    { new Guid("f10db540-8ab5-42fc-98c1-1d6670e98a68"), 0, "Travel blogger and outdoor enthusiast", "cc81b016-b98c-4356-a43d-7cbdd843e0a3", "olivia@example.com", true, "Olivia", "Martinez", false, null, "OLIVIA@EXAMPLE.COM", "OLIVIAM", "AQAAAAIAAYagAAAAEG9Yh999XbrReKfYRF6NzknIDvSmTjBuDq4KQkfqZweYlubTSIOeVLFmxSD3tar1IA==", null, false, "https://randomuser.me/api/portraits/women/4.jpg", null, null, "5d89e3f0-b985-480b-8f27-ca42310a697b", false, "oliviam" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "ActorId", "CommentId", "Content", "CreatedAt", "IsRead", "PostId", "Type", "UserId" },
                values: new object[] { new Guid("12091fd8-110b-47eb-964b-1336456db8fa"), new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79"), null, "started following you", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, null, 2, new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Caption", "CommentCount", "CreatedAt", "LikeCount", "UserId" },
                values: new object[,]
                {
                    { new Guid("13c94976-8f59-4bbe-a8b4-05d840e166ed"), "New coding setup complete", 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 28, new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5") },
                    { new Guid("20711cd8-f1b2-49d7-8e98-3c65d40c07f3"), "New coding setup complete", 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 28, new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5") },
                    { new Guid("359b2d41-56f5-4bea-95ae-9e5835b91c0b"), "Beautiful sunset at the beach!", 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") },
                    { new Guid("4c19587a-dec7-449d-b335-30013ca29423"), "New coding setup complete", 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 28, new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5") },
                    { new Guid("5c7e4574-4d60-4d7d-9b5e-eaaeb5ef391f"), "New coding setup complete", 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 28, new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5") },
                    { new Guid("5c9fc803-7ecc-4f9a-80d7-1d3dedb7fc21"), "Meal prep for the week! Healthy eating doesn't have to be boring 🥗", 6, new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Utc), 27, new Guid("c2e18fc7-6492-4081-8c19-8ba5e7c42005") },
                    { new Guid("7a628109-d587-40f3-9900-2d5a6724d216"), "My latest digital art piece - cyberpunk cityscape 🌆", 3, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 24, new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2") },
                    { new Guid("8395d1f8-9394-4da6-ac04-d7d5eb4ee47d"), "My homemade pasta recipe 🍝", 3, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 42, new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") },
                    { new Guid("8dc7e07e-71dc-4677-ad0e-875f2bd59d77"), "My homemade pasta recipe 🍝", 3, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 42, new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") },
                    { new Guid("9bfe2ca3-73ab-404f-8f8c-dd5004b84d8b"), "Beautiful sunset at the beach!", 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") },
                    { new Guid("9e460ac3-5486-4daa-a717-82ff17b09b70"), "Today's workout: 5 mile run and full-body HIIT 💪", 4, new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), 18, new Guid("c2e18fc7-6492-4081-8c19-8ba5e7c42005") },
                    { new Guid("a1580aad-5bc7-45e4-8347-232570d1579b"), "Beautiful sunset at the beach!", 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") },
                    { new Guid("a881316f-dcd2-4a49-a621-0a5d3fa66b86"), "My latest fashion collection inspired by Mediterranean summers ☀️", 7, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Utc), 45, new Guid("24005e30-4b5a-45b4-aab2-61aca02c8e7f") },
                    { new Guid("aaefe87b-e5c5-4b29-b605-ac0de1d396ae"), "Homemade sourdough pizza with fresh basil and buffalo mozzarella 🍕", 5, new DateTime(2025, 3, 13, 0, 0, 0, 0, DateTimeKind.Utc), 38, new Guid("1be6db51-a961-4adf-8902-9f7edd2d1d4c") },
                    { new Guid("bbbad0c3-9758-4508-81d2-ba0f1b068b44"), "Beautiful sunset at the beach!", 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") },
                    { new Guid("bfb2c1f0-fb02-4a79-9922-0594b29add61"), "New coding setup complete", 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 28, new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5") },
                    { new Guid("ce491c2e-6e81-48dc-877c-0375aa73f2fd"), "My homemade pasta recipe 🍝", 3, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 42, new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") },
                    { new Guid("d02c3613-2722-46e8-ba79-f971a7db3ad8"), "New plant baby added to my collection! 🌱", 5, new DateTime(2025, 3, 13, 0, 0, 0, 0, DateTimeKind.Utc), 31, new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2") },
                    { new Guid("d2e2a39d-5ede-4bbb-ad33-05d2af86f878"), "Beautiful sunset at the beach!", 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") },
                    { new Guid("e1d49a77-b7f7-4570-b2d7-5da07d7dcdda"), "New coding setup complete", 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 28, new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5") },
                    { new Guid("f24e609d-3ba1-46dc-b8ec-5fae7bd04bbf"), "Sunrise hike at Mount Rainier. Worth waking up at 4am! 🏔️", 8, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), 52, new Guid("f10db540-8ab5-42fc-98c1-1d6670e98a68") },
                    { new Guid("f3d89927-4f0d-4678-99ce-c58643e163b1"), "Beautiful sunset at the beach!", 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") }
                });

            migrationBuilder.InsertData(
                table: "UserFollowers",
                columns: new[] { "FollowerId", "FollowingId" },
                values: new object[,]
                {
                    { new Guid("1be6db51-a961-4adf-8902-9f7edd2d1d4c"), new Guid("24005e30-4b5a-45b4-aab2-61aca02c8e7f") },
                    { new Guid("1be6db51-a961-4adf-8902-9f7edd2d1d4c"), new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") },
                    { new Guid("1be6db51-a961-4adf-8902-9f7edd2d1d4c"), new Guid("f10db540-8ab5-42fc-98c1-1d6670e98a68") },
                    { new Guid("24005e30-4b5a-45b4-aab2-61aca02c8e7f"), new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") },
                    { new Guid("24005e30-4b5a-45b4-aab2-61aca02c8e7f"), new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2") },
                    { new Guid("24005e30-4b5a-45b4-aab2-61aca02c8e7f"), new Guid("f10db540-8ab5-42fc-98c1-1d6670e98a68") },
                    { new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79"), new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") },
                    { new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79"), new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5") },
                    { new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79"), new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2") },
                    { new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50"), new Guid("24005e30-4b5a-45b4-aab2-61aca02c8e7f") },
                    { new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50"), new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") },
                    { new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50"), new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5") },
                    { new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50"), new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2") },
                    { new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5"), new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") },
                    { new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5"), new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") },
                    { new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5"), new Guid("c2e18fc7-6492-4081-8c19-8ba5e7c42005") },
                    { new Guid("c2e18fc7-6492-4081-8c19-8ba5e7c42005"), new Guid("1be6db51-a961-4adf-8902-9f7edd2d1d4c") },
                    { new Guid("c2e18fc7-6492-4081-8c19-8ba5e7c42005"), new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5") },
                    { new Guid("c2e18fc7-6492-4081-8c19-8ba5e7c42005"), new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2") },
                    { new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2"), new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") },
                    { new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2"), new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") },
                    { new Guid("f10db540-8ab5-42fc-98c1-1d6670e98a68"), new Guid("1be6db51-a961-4adf-8902-9f7edd2d1d4c") },
                    { new Guid("f10db540-8ab5-42fc-98c1-1d6670e98a68"), new Guid("24005e30-4b5a-45b4-aab2-61aca02c8e7f") },
                    { new Guid("f10db540-8ab5-42fc-98c1-1d6670e98a68"), new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "LikeCount", "ParentCommentId", "PostId", "ReplyCount", "UserId" },
                values: new object[,]
                {
                    { new Guid("20d5358e-11fc-4446-8e39-ebcae0f40ad9"), "What's your favorite HIIT exercise?", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, new Guid("9e460ac3-5486-4daa-a717-82ff17b09b70"), 1, new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5") },
                    { new Guid("34fc23fe-4af7-4619-9e1a-0325e3bbf34d"), "This looks delicious!", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 4, null, new Guid("8dc7e07e-71dc-4677-ad0e-875f2bd59d77"), 1, new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5") },
                    { new Guid("6172141f-b5b1-4420-b245-5c844633a9a5"), "These designs are stunning! Will they be available in your online shop?", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 3, null, new Guid("a881316f-dcd2-4a49-a621-0a5d3fa66b86"), 1, new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") },
                    { new Guid("7c9445d5-5309-445f-bf36-3bfd32cbd1c1"), "This is incredible! Love the neon colors!", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 2, null, new Guid("7a628109-d587-40f3-9900-2d5a6724d216"), 1, new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "ParentCommentId", "PostId", "ReplyCount", "UserId" },
                values: new object[] { new Guid("b22eb11b-a224-4fc9-a6d0-ee1f3b177651"), "Can you share the recipe?", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("8dc7e07e-71dc-4677-ad0e-875f2bd59d77"), 1, new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "LikeCount", "ParentCommentId", "PostId", "ReplyCount", "UserId" },
                values: new object[,]
                {
                    { new Guid("c6df3203-8bf8-449f-aba8-f5c2e9845b93"), "That crust looks perfect! Would love to see your sourdough recipe.", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 2, null, new Guid("aaefe87b-e5c5-4b29-b605-ac0de1d396ae"), 1, new Guid("f10db540-8ab5-42fc-98c1-1d6670e98a68") },
                    { new Guid("d362cee1-39c2-4fce-a53d-43397ab6b184"), "Amazing view!", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 3, null, new Guid("a1580aad-5bc7-45e4-8347-232570d1579b"), 1, new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") },
                    { new Guid("e3e5419a-6fe7-4a5b-bb0e-6cb85723f874"), "Nice setup! What monitor is that?", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, new Guid("8395d1f8-9394-4da6-ac04-d7d5eb4ee47d"), 1, new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Order", "PostId", "Url" },
                values: new object[,]
                {
                    { new Guid("00ebb873-6396-4888-815c-a403ca9f019e"), 1, new Guid("f24e609d-3ba1-46dc-b8ec-5fae7bd04bbf"), "https://picsum.photos/id/19/800/800" },
                    { new Guid("11e56641-b4cf-4777-93c3-9dbf2048f6cd"), 1, new Guid("ce491c2e-6e81-48dc-877c-0375aa73f2fd"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("1234308d-61ea-493a-ab86-a9c0dce3175f"), 1, new Guid("8dc7e07e-71dc-4677-ad0e-875f2bd59d77"), "https://picsum.photos/id/2/800/800" },
                    { new Guid("1528e35f-181b-4655-b401-5fba6929eeb5"), 2, new Guid("8dc7e07e-71dc-4677-ad0e-875f2bd59d77"), "https://picsum.photos/id/3/800/800" },
                    { new Guid("253bba4d-b046-4e29-9076-ca1d5eeadb29"), 1, new Guid("e1d49a77-b7f7-4570-b2d7-5da07d7dcdda"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("2681d946-971e-465c-94b8-2d12d8b0bb58"), 1, new Guid("f3d89927-4f0d-4678-99ce-c58643e163b1"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("3573ffc6-bf63-4871-9e75-09ea6ad3a5e1"), 4, new Guid("d2e2a39d-5ede-4bbb-ad33-05d2af86f878"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("3dd9184c-508f-4d0b-a586-5271ff1b10f7"), 1, new Guid("bfb2c1f0-fb02-4a79-9922-0594b29add61"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("43873c2e-86fa-4f30-9871-9715a7b7ae6e"), 1, new Guid("20711cd8-f1b2-49d7-8e98-3c65d40c07f3"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("51922d1e-a26a-4f14-b412-1b81c63b4741"), 1, new Guid("d2e2a39d-5ede-4bbb-ad33-05d2af86f878"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("61cad9dc-5130-45a3-ac8f-1312ae01dc4d"), 1, new Guid("8395d1f8-9394-4da6-ac04-d7d5eb4ee47d"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("635df96f-ba20-4821-8b7d-9cba1d378304"), 3, new Guid("a881316f-dcd2-4a49-a621-0a5d3fa66b86"), "https://picsum.photos/id/17/800/800" },
                    { new Guid("6aaee03a-3e42-4a30-ba24-85200478f2ee"), 1, new Guid("a881316f-dcd2-4a49-a621-0a5d3fa66b86"), "https://picsum.photos/id/15/800/800" },
                    { new Guid("7b606428-b2cf-4250-8942-e9a58ac715a7"), 1, new Guid("d02c3613-2722-46e8-ba79-f971a7db3ad8"), "https://picsum.photos/id/11/800/800" },
                    { new Guid("8433b8ed-08c7-4d11-902e-52afe4261c91"), 1, new Guid("9bfe2ca3-73ab-404f-8f8c-dd5004b84d8b"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("855c0349-cd22-4d4f-baa7-03ee0ab0e725"), 1, new Guid("bbbad0c3-9758-4508-81d2-ba0f1b068b44"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("860e4830-81d0-48e5-b2eb-fa66bac4747b"), 1, new Guid("a1580aad-5bc7-45e4-8347-232570d1579b"), "https://picsum.photos/id/1/800/800" },
                    { new Guid("8d2d237c-409a-46fa-a214-ee99dd42425f"), 2, new Guid("5c9fc803-7ecc-4f9a-80d7-1d3dedb7fc21"), "https://picsum.photos/id/14/800/800" },
                    { new Guid("a0b79a40-7a82-4580-902a-c17f7c991dab"), 2, new Guid("4c19587a-dec7-449d-b335-30013ca29423"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("a6393363-40b4-4684-8602-5c7023cb48e0"), 2, new Guid("f24e609d-3ba1-46dc-b8ec-5fae7bd04bbf"), "https://picsum.photos/id/20/800/800" },
                    { new Guid("a8bbf75e-e451-49b7-b5c5-65c80754f7f9"), 1, new Guid("4c19587a-dec7-449d-b335-30013ca29423"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("aa62ed32-8543-4137-8427-bcb75aa8eaff"), 1, new Guid("359b2d41-56f5-4bea-95ae-9e5835b91c0b"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("ae6aa320-39e7-42d1-a86d-c1a08dd531aa"), 2, new Guid("d2e2a39d-5ede-4bbb-ad33-05d2af86f878"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("af98df1e-9c22-4b81-a4ef-2e42f0c8b82b"), 1, new Guid("5c7e4574-4d60-4d7d-9b5e-eaaeb5ef391f"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("bb2a35ec-003f-46a7-9a17-fc52dbd9da26"), 1, new Guid("aaefe87b-e5c5-4b29-b605-ac0de1d396ae"), "https://picsum.photos/id/18/800/800" },
                    { new Guid("bea6504a-11bb-4537-96b8-f223cb18e94b"), 1, new Guid("9e460ac3-5486-4daa-a717-82ff17b09b70"), "https://picsum.photos/id/12/800/800" },
                    { new Guid("c10d839b-83cf-4d30-a3ae-a22ed28ba400"), 1, new Guid("13c94976-8f59-4bbe-a8b4-05d840e166ed"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("cbd41327-087c-4fe2-862a-1f4972055c5a"), 2, new Guid("e1d49a77-b7f7-4570-b2d7-5da07d7dcdda"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("cd02ea67-e03b-4294-ba70-a9a4b50fa9ee"), 2, new Guid("a881316f-dcd2-4a49-a621-0a5d3fa66b86"), "https://picsum.photos/id/16/800/800" },
                    { new Guid("ec65fab8-9a22-4c94-9498-ea73c561e168"), 1, new Guid("5c9fc803-7ecc-4f9a-80d7-1d3dedb7fc21"), "https://picsum.photos/id/13/800/800" },
                    { new Guid("fab243f1-cb12-489e-a238-48af72670de1"), 1, new Guid("7a628109-d587-40f3-9900-2d5a6724d216"), "https://picsum.photos/id/10/800/800" },
                    { new Guid("fcc56907-c4d5-4643-8130-9798a55f5a1b"), 3, new Guid("d2e2a39d-5ede-4bbb-ad33-05d2af86f878"), "https://picsum.photos/id/4/800/800" }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "CreatedAt", "PostId", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("02b103a9-b9c1-406f-a73f-caa66cd8e7c8"), null, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("8dc7e07e-71dc-4677-ad0e-875f2bd59d77"), 0, new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") },
                    { new Guid("1685a5b1-1646-4357-bcc1-b762c284d7cd"), null, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a1580aad-5bc7-45e4-8347-232570d1579b"), 0, new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") },
                    { new Guid("37841387-91b2-47ba-9416-4014fef6fa45"), null, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("9e460ac3-5486-4daa-a717-82ff17b09b70"), 0, new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5") },
                    { new Guid("4788a956-0d2c-414f-b7c5-e94a9fa65472"), null, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a628109-d587-40f3-9900-2d5a6724d216"), 0, new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") },
                    { new Guid("480eb0d6-fc6f-4012-997b-2d9ae0b1697c"), null, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a881316f-dcd2-4a49-a621-0a5d3fa66b86"), 0, new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") },
                    { new Guid("6196b128-bc36-46f8-8312-ed1f4c1de347"), null, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a628109-d587-40f3-9900-2d5a6724d216"), 0, new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") },
                    { new Guid("803e54d6-529d-47da-9f5b-534c844990e9"), null, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("9e460ac3-5486-4daa-a717-82ff17b09b70"), 0, new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2") },
                    { new Guid("936c8eb2-69b1-456e-8c75-6818bc0a0571"), null, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a1580aad-5bc7-45e4-8347-232570d1579b"), 0, new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5") },
                    { new Guid("a21fee25-94d3-4465-be44-a0460cd55406"), null, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("8dc7e07e-71dc-4677-ad0e-875f2bd59d77"), 0, new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5") },
                    { new Guid("a4877887-05e5-4906-80a1-135d7c8dd187"), null, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("8395d1f8-9394-4da6-ac04-d7d5eb4ee47d"), 0, new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") },
                    { new Guid("be508edf-5e51-4b15-8650-7fa68b7940f5"), null, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("8395d1f8-9394-4da6-ac04-d7d5eb4ee47d"), 0, new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "ActorId", "CommentId", "Content", "CreatedAt", "IsRead", "PostId", "Type", "UserId" },
                values: new object[] { new Guid("1c19169c-063b-405e-b64b-353f017bc2e4"), new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5"), null, "liked your post", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("a1580aad-5bc7-45e4-8347-232570d1579b"), 0, new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "ActorId", "CommentId", "Content", "CreatedAt", "PostId", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("3c2acfe7-bc70-4185-a3cc-1fe0479f6890"), new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50"), null, "liked your post", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a628109-d587-40f3-9900-2d5a6724d216"), 0, new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2") },
                    { new Guid("798f53fe-aeb4-4035-8e4c-ddd199a65ca3"), new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79"), null, "liked your post", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a628109-d587-40f3-9900-2d5a6724d216"), 0, new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2") }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "ActorId", "CommentId", "Content", "CreatedAt", "IsRead", "PostId", "Type", "UserId" },
                values: new object[] { new Guid("b02cc886-16ae-469c-9320-1589bc1e068e"), new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50"), null, "liked your post", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("a1580aad-5bc7-45e4-8347-232570d1579b"), 0, new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "LikeCount", "ParentCommentId", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1b179a0f-bfa4-43d5-8a77-7fa48444d5b8"), "Definitely burpees - they're brutal but effective!", new DateTime(2025, 3, 15, 2, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("20d5358e-11fc-4446-8e39-ebcae0f40ad9"), new Guid("9e460ac3-5486-4daa-a717-82ff17b09b70"), new Guid("c2e18fc7-6492-4081-8c19-8ba5e7c42005") },
                    { new Guid("382c2432-5246-4fef-b5a0-2c5c2848ff1b"), "Yes! They'll be available next month. I'll share a discount code soon!", new DateTime(2025, 3, 15, 3, 0, 0, 0, DateTimeKind.Utc), 1, new Guid("6172141f-b5b1-4420-b245-5c844633a9a5"), new Guid("a881316f-dcd2-4a49-a621-0a5d3fa66b86"), new Guid("24005e30-4b5a-45b4-aab2-61aca02c8e7f") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "ParentCommentId", "PostId", "UserId" },
                values: new object[] { new Guid("74211123-b6d9-476d-9d09-f3806cbfbd2b"), "It's an LG 34\" ultrawide", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("e3e5419a-6fe7-4a5b-bb0e-6cb85723f874"), new Guid("8395d1f8-9394-4da6-ac04-d7d5eb4ee47d"), new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "LikeCount", "ParentCommentId", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("7a73cff3-6d43-4434-a777-133629767de7"), "I'll share it in my next post! It's all about the 24-hour fermentation.", new DateTime(2025, 3, 15, 1, 0, 0, 0, DateTimeKind.Utc), 1, new Guid("c6df3203-8bf8-449f-aba8-f5c2e9845b93"), new Guid("aaefe87b-e5c5-4b29-b605-ac0de1d396ae"), new Guid("1be6db51-a961-4adf-8902-9f7edd2d1d4c") },
                    { new Guid("8f425888-a589-444c-b274-258fa24e1561"), "Thanks! It was incredible.", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Guid("d362cee1-39c2-4fce-a53d-43397ab6b184"), new Guid("a1580aad-5bc7-45e4-8347-232570d1579b"), new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") },
                    { new Guid("af9a62c2-2291-4502-b352-2fc02aa9d8c2"), "Thank you so much! Took me almost a week to finish.", new DateTime(2025, 3, 15, 1, 0, 0, 0, DateTimeKind.Utc), 1, new Guid("7c9445d5-5309-445f-bf36-3bfd32cbd1c1"), new Guid("7a628109-d587-40f3-9900-2d5a6724d216"), new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2") },
                    { new Guid("c87ddb1f-118e-4bf0-9a76-2e5fd32600f5"), "Sure, I'll DM you!", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Guid("b22eb11b-a224-4fc9-a6d0-ee1f3b177651"), new Guid("8dc7e07e-71dc-4677-ad0e-875f2bd59d77"), new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "CreatedAt", "PostId", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("11f0875c-8046-4fd8-8c58-b8b0f7770979"), new Guid("d362cee1-39c2-4fce-a53d-43397ab6b184"), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, 1, new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") },
                    { new Guid("2cd1d1a2-0aa1-41b9-9435-d17211fad94e"), new Guid("d362cee1-39c2-4fce-a53d-43397ab6b184"), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, 1, new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5") },
                    { new Guid("a3790a15-2257-48b8-8be7-55b7632874fd"), new Guid("7c9445d5-5309-445f-bf36-3bfd32cbd1c1"), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, 1, new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2") },
                    { new Guid("b6f3b6e4-5e74-4cd7-9082-a78beed00e42"), new Guid("6172141f-b5b1-4420-b245-5c844633a9a5"), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, 1, new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5") }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "ActorId", "CommentId", "Content", "CreatedAt", "IsRead", "PostId", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("787360b1-153d-45dd-b9cf-8f0b2bce5c25"), new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79"), new Guid("7c9445d5-5309-445f-bf36-3bfd32cbd1c1"), "commented on your post", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("7a628109-d587-40f3-9900-2d5a6724d216"), 1, new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2") },
                    { new Guid("9ddc71a0-340c-41a1-90a9-0f9714cc72d6"), new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5"), new Guid("20d5358e-11fc-4446-8e39-ebcae0f40ad9"), "commented on your post", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("9e460ac3-5486-4daa-a717-82ff17b09b70"), 1, new Guid("c2e18fc7-6492-4081-8c19-8ba5e7c42005") },
                    { new Guid("bd655d3c-5f52-4d75-a4b1-98fc33600c12"), new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50"), new Guid("d362cee1-39c2-4fce-a53d-43397ab6b184"), "commented on your post", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("a1580aad-5bc7-45e4-8347-232570d1579b"), 1, new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "CreatedAt", "PostId", "Type", "UserId" },
                values: new object[] { new Guid("b3f49bb9-a629-4849-9aa2-26b93d4194a7"), new Guid("8f425888-a589-444c-b274-258fa24e1561"), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, 1, new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "ActorId", "CommentId", "Content", "CreatedAt", "IsRead", "PostId", "Type", "UserId" },
                values: new object[] { new Guid("9c571c77-23b4-4c14-8a8e-29252ccccc3c"), new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79"), new Guid("8f425888-a589-444c-b274-258fa24e1561"), "replied to your comment", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("a1580aad-5bc7-45e4-8347-232570d1579b"), 1, new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("1b179a0f-bfa4-43d5-8a77-7fa48444d5b8"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("34fc23fe-4af7-4619-9e1a-0325e3bbf34d"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("382c2432-5246-4fef-b5a0-2c5c2848ff1b"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("74211123-b6d9-476d-9d09-f3806cbfbd2b"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7a73cff3-6d43-4434-a777-133629767de7"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("af9a62c2-2291-4502-b352-2fc02aa9d8c2"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c87ddb1f-118e-4bf0-9a76-2e5fd32600f5"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("00ebb873-6396-4888-815c-a403ca9f019e"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("11e56641-b4cf-4777-93c3-9dbf2048f6cd"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("1234308d-61ea-493a-ab86-a9c0dce3175f"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("1528e35f-181b-4655-b401-5fba6929eeb5"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("253bba4d-b046-4e29-9076-ca1d5eeadb29"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("2681d946-971e-465c-94b8-2d12d8b0bb58"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3573ffc6-bf63-4871-9e75-09ea6ad3a5e1"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3dd9184c-508f-4d0b-a586-5271ff1b10f7"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("43873c2e-86fa-4f30-9871-9715a7b7ae6e"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("51922d1e-a26a-4f14-b412-1b81c63b4741"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("61cad9dc-5130-45a3-ac8f-1312ae01dc4d"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("635df96f-ba20-4821-8b7d-9cba1d378304"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("6aaee03a-3e42-4a30-ba24-85200478f2ee"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7b606428-b2cf-4250-8942-e9a58ac715a7"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8433b8ed-08c7-4d11-902e-52afe4261c91"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("855c0349-cd22-4d4f-baa7-03ee0ab0e725"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("860e4830-81d0-48e5-b2eb-fa66bac4747b"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8d2d237c-409a-46fa-a214-ee99dd42425f"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a0b79a40-7a82-4580-902a-c17f7c991dab"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a6393363-40b4-4684-8602-5c7023cb48e0"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a8bbf75e-e451-49b7-b5c5-65c80754f7f9"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("aa62ed32-8543-4137-8427-bcb75aa8eaff"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("ae6aa320-39e7-42d1-a86d-c1a08dd531aa"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("af98df1e-9c22-4b81-a4ef-2e42f0c8b82b"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("bb2a35ec-003f-46a7-9a17-fc52dbd9da26"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("bea6504a-11bb-4537-96b8-f223cb18e94b"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c10d839b-83cf-4d30-a3ae-a22ed28ba400"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cbd41327-087c-4fe2-862a-1f4972055c5a"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cd02ea67-e03b-4294-ba70-a9a4b50fa9ee"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("ec65fab8-9a22-4c94-9498-ea73c561e168"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("fab243f1-cb12-489e-a238-48af72670de1"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("fcc56907-c4d5-4643-8130-9798a55f5a1b"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("02b103a9-b9c1-406f-a73f-caa66cd8e7c8"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("11f0875c-8046-4fd8-8c58-b8b0f7770979"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("1685a5b1-1646-4357-bcc1-b762c284d7cd"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("2cd1d1a2-0aa1-41b9-9435-d17211fad94e"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("37841387-91b2-47ba-9416-4014fef6fa45"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("4788a956-0d2c-414f-b7c5-e94a9fa65472"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("480eb0d6-fc6f-4012-997b-2d9ae0b1697c"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("6196b128-bc36-46f8-8312-ed1f4c1de347"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("803e54d6-529d-47da-9f5b-534c844990e9"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("936c8eb2-69b1-456e-8c75-6818bc0a0571"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("a21fee25-94d3-4465-be44-a0460cd55406"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("a3790a15-2257-48b8-8be7-55b7632874fd"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("a4877887-05e5-4906-80a1-135d7c8dd187"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("b3f49bb9-a629-4849-9aa2-26b93d4194a7"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("b6f3b6e4-5e74-4cd7-9082-a78beed00e42"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("be508edf-5e51-4b15-8650-7fa68b7940f5"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("12091fd8-110b-47eb-964b-1336456db8fa"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("1c19169c-063b-405e-b64b-353f017bc2e4"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("3c2acfe7-bc70-4185-a3cc-1fe0479f6890"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("787360b1-153d-45dd-b9cf-8f0b2bce5c25"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("798f53fe-aeb4-4035-8e4c-ddd199a65ca3"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("9c571c77-23b4-4c14-8a8e-29252ccccc3c"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("9ddc71a0-340c-41a1-90a9-0f9714cc72d6"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("b02cc886-16ae-469c-9320-1589bc1e068e"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("bd655d3c-5f52-4d75-a4b1-98fc33600c12"));

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("1be6db51-a961-4adf-8902-9f7edd2d1d4c"), new Guid("24005e30-4b5a-45b4-aab2-61aca02c8e7f") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("1be6db51-a961-4adf-8902-9f7edd2d1d4c"), new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("1be6db51-a961-4adf-8902-9f7edd2d1d4c"), new Guid("f10db540-8ab5-42fc-98c1-1d6670e98a68") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("24005e30-4b5a-45b4-aab2-61aca02c8e7f"), new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("24005e30-4b5a-45b4-aab2-61aca02c8e7f"), new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("24005e30-4b5a-45b4-aab2-61aca02c8e7f"), new Guid("f10db540-8ab5-42fc-98c1-1d6670e98a68") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79"), new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79"), new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79"), new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50"), new Guid("24005e30-4b5a-45b4-aab2-61aca02c8e7f") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50"), new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50"), new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50"), new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5"), new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5"), new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5"), new Guid("c2e18fc7-6492-4081-8c19-8ba5e7c42005") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("c2e18fc7-6492-4081-8c19-8ba5e7c42005"), new Guid("1be6db51-a961-4adf-8902-9f7edd2d1d4c") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("c2e18fc7-6492-4081-8c19-8ba5e7c42005"), new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("c2e18fc7-6492-4081-8c19-8ba5e7c42005"), new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2"), new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2"), new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("f10db540-8ab5-42fc-98c1-1d6670e98a68"), new Guid("1be6db51-a961-4adf-8902-9f7edd2d1d4c") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("f10db540-8ab5-42fc-98c1-1d6670e98a68"), new Guid("24005e30-4b5a-45b4-aab2-61aca02c8e7f") });

            migrationBuilder.DeleteData(
                table: "UserFollowers",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { new Guid("f10db540-8ab5-42fc-98c1-1d6670e98a68"), new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2") });

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("20d5358e-11fc-4446-8e39-ebcae0f40ad9"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("6172141f-b5b1-4420-b245-5c844633a9a5"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7c9445d5-5309-445f-bf36-3bfd32cbd1c1"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("8f425888-a589-444c-b274-258fa24e1561"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("b22eb11b-a224-4fc9-a6d0-ee1f3b177651"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c6df3203-8bf8-449f-aba8-f5c2e9845b93"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("e3e5419a-6fe7-4a5b-bb0e-6cb85723f874"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("13c94976-8f59-4bbe-a8b4-05d840e166ed"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("20711cd8-f1b2-49d7-8e98-3c65d40c07f3"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("359b2d41-56f5-4bea-95ae-9e5835b91c0b"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("4c19587a-dec7-449d-b335-30013ca29423"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("5c7e4574-4d60-4d7d-9b5e-eaaeb5ef391f"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("5c9fc803-7ecc-4f9a-80d7-1d3dedb7fc21"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("9bfe2ca3-73ab-404f-8f8c-dd5004b84d8b"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("bbbad0c3-9758-4508-81d2-ba0f1b068b44"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("bfb2c1f0-fb02-4a79-9922-0594b29add61"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("ce491c2e-6e81-48dc-877c-0375aa73f2fd"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("d02c3613-2722-46e8-ba79-f971a7db3ad8"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("d2e2a39d-5ede-4bbb-ad33-05d2af86f878"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("e1d49a77-b7f7-4570-b2d7-5da07d7dcdda"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f24e609d-3ba1-46dc-b8ec-5fae7bd04bbf"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f3d89927-4f0d-4678-99ce-c58643e163b1"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("d362cee1-39c2-4fce-a53d-43397ab6b184"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("7a628109-d587-40f3-9900-2d5a6724d216"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("8395d1f8-9394-4da6-ac04-d7d5eb4ee47d"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("8dc7e07e-71dc-4677-ad0e-875f2bd59d77"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("9e460ac3-5486-4daa-a717-82ff17b09b70"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("a881316f-dcd2-4a49-a621-0a5d3fa66b86"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("aaefe87b-e5c5-4b29-b605-ac0de1d396ae"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("979b390a-b414-4bf4-bce5-a0510e9103c5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f10db540-8ab5-42fc-98c1-1d6670e98a68"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("a1580aad-5bc7-45e4-8347-232570d1579b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1be6db51-a961-4adf-8902-9f7edd2d1d4c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("24005e30-4b5a-45b4-aab2-61aca02c8e7f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4e1b1e0f-5c71-48ab-8bcb-f31760f94d50"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c2e18fc7-6492-4081-8c19-8ba5e7c42005"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dc3d8918-0070-47cd-aee7-bf6a43dfb6b2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("492e3957-5244-4a7a-9d4a-9efc8b121b79"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "RefreshToken", "RefreshTokenExpiresAtUtc", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), 0, "Photography enthusiast and traveler", "6b810364-fd8b-45b1-b4a3-6768bb457bce", "john@example.com", true, "John", "Doe", false, null, "JOHN@EXAMPLE.COM", "JOHNDOE", "AQAAAAIAAYagAAAAEG9Yh999XbrReKfYRF6NzknIDvSmTjBuDq4KQkfqZweYlubTSIOeVLFmxSD3tar1IA==", null, false, "https://randomuser.me/api/portraits/men/1.jpg", null, null, "4b92b2fb-8d85-435e-a96c-02d15870b5e2", false, "johndoe" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 0, "Food blogger | Travel lover", "7ad093c0-7a87-4930-b419-ba99daef425b", "jane@example.com", true, "Jane", "Smith", false, null, "JANE@EXAMPLE.COM", "JANESMITH", "AQAAAAIAAYagAAAAEG9Yh999XbrReKfYRF6NzknIDvSmTjBuDq4KQkfqZweYlubTSIOeVLFmxSD3tar1IA==", null, false, "https://randomuser.me/api/portraits/women/1.jpg", null, null, "63222f5e-90c3-47ef-9cb7-48d66399c1bb", false, "janesmith" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 0, "Software developer and coffee addict", "71b590a1-a75b-4896-9c7c-4c53f5175515", "alex@example.com", true, "Alex", "Johnson", false, null, "ALEX@EXAMPLE.COM", "ALEXJ", "AQAAAAIAAYagAAAAEG9Yh999XbrReKfYRF6NzknIDvSmTjBuDq4KQkfqZweYlubTSIOeVLFmxSD3tar1IA==", null, false, "https://randomuser.me/api/portraits/men/2.jpg", null, null, "b8dd465b-c95d-4d1d-81b2-0e56da8c00e1", false, "alexj" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "ActorId", "CommentId", "Content", "CreatedAt", "IsRead", "PostId", "Type", "UserId" },
                values: new object[] { new Guid("e5555555-e555-e555-e555-e55555555555"), new Guid("11111111-1111-1111-1111-111111111111"), null, "started following you", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, null, 2, new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "ActorId", "CommentId", "Content", "CreatedAt", "PostId", "Type", "UserId" },
                values: new object[] { new Guid("e6666666-e666-e666-e666-e66666666666"), new Guid("11111111-1111-1111-1111-111111111111"), null, "started following you", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, 2, new Guid("33333333-3333-3333-3333-333333333333") });

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
                    { new Guid("a1111111-a111-a111-a111-a11111111111"), "Beautiful sunset at the beach!", 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("a2222222-a222-a222-a222-a22222222222"), "My homemade pasta recipe 🍝", 3, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 42, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("a3333333-a333-a333-a333-a33333333333"), "My homemade pasta recipe 🍝", 3, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 42, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bde50254-1861-4233-b4f0-7e978971bbd6"), "Beautiful sunset at the beach!", 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c203212b-fc5b-446e-a950-552498d2d1b8"), "New coding setup complete", 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 28, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("e1bc7d1b-308e-4f8c-9d4d-f92dbf22e414"), "Beautiful sunset at the beach!", 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.InsertData(
                table: "UserFollowers",
                columns: new[] { "FollowerId", "FollowingId" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new Guid("22222222-2222-2222-2222-222222222222") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "LikeCount", "ParentCommentId", "PostId", "ReplyCount", "UserId" },
                values: new object[,]
                {
                    { new Guid("c1111111-c111-c111-c111-c11111111111"), "Amazing view!", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 3, null, new Guid("a1111111-a111-a111-a111-a11111111111"), 1, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("c3333333-c333-c333-c333-c33333333333"), "This looks delicious!", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 4, null, new Guid("a2222222-a222-a222-a222-a22222222222"), 1, new Guid("33333333-3333-3333-3333-333333333333") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "ParentCommentId", "PostId", "ReplyCount", "UserId" },
                values: new object[] { new Guid("c4444444-c444-c444-c444-c44444444444"), "Can you share the recipe?", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("a2222222-a222-a222-a222-a22222222222"), 1, new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "LikeCount", "ParentCommentId", "PostId", "ReplyCount", "UserId" },
                values: new object[] { new Guid("c6666666-c666-c666-c666-c66666666666"), "Nice setup! What monitor is that?", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, new Guid("a3333333-a333-a333-a333-a33333333333"), 1, new Guid("11111111-1111-1111-1111-111111111111") });

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
                    { new Guid("b1111111-b111-b111-b111-b11111111111"), 1, new Guid("a1111111-a111-a111-a111-a11111111111"), "https://picsum.photos/id/1/800/800" },
                    { new Guid("b2222222-b222-b222-b222-b22222222222"), 1, new Guid("a2222222-a222-a222-a222-a22222222222"), "https://picsum.photos/id/2/800/800" },
                    { new Guid("b3333333-b333-b333-b333-b33333333333"), 2, new Guid("a2222222-a222-a222-a222-a22222222222"), "https://picsum.photos/id/3/800/800" },
                    { new Guid("b4444444-b444-b444-b444-b44444444444"), 1, new Guid("a3333333-a333-a333-a333-a33333333333"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("be5ca388-333e-42a3-860c-878a810a7069"), 1, new Guid("5f6341cd-5750-4531-9c6e-1c34e279d79f"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("c1744aea-6364-4ca6-895c-342bdfc78dbb"), 2, new Guid("e1bc7d1b-308e-4f8c-9d4d-f92dbf22e414"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("caef3abc-1c05-403a-b705-1ea8d8dc120b"), 1, new Guid("3afa0420-8c57-41dd-b2a9-ccc7b046ec03"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("fa68e757-da98-4d29-8ccf-8f93a7c76a2b"), 1, new Guid("e1bc7d1b-308e-4f8c-9d4d-f92dbf22e414"), "https://picsum.photos/id/4/800/800" },
                    { new Guid("faebe4a8-76d2-4268-ab1c-45864491ab8b"), 4, new Guid("e1bc7d1b-308e-4f8c-9d4d-f92dbf22e414"), "https://picsum.photos/id/4/800/800" }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "CreatedAt", "PostId", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("d1111111-d111-d111-d111-d11111111111"), null, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a1111111-a111-a111-a111-a11111111111"), 0, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("d2222222-d222-d222-d222-d22222222222"), null, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a1111111-a111-a111-a111-a11111111111"), 0, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("d3333333-d333-d333-d333-d33333333333"), null, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a2222222-a222-a222-a222-a22222222222"), 0, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("d4444444-d444-d444-d444-d44444444444"), null, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a2222222-a222-a222-a222-a22222222222"), 0, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("d5555555-d555-d555-d555-d55555555555"), null, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a3333333-a333-a333-a333-a33333333333"), 0, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("d6666666-d666-d666-d666-d66666666666"), null, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a3333333-a333-a333-a333-a33333333333"), 0, new Guid("22222222-2222-2222-2222-222222222222") }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "ActorId", "CommentId", "Content", "CreatedAt", "IsRead", "PostId", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("e1111111-e111-e111-e111-e11111111111"), new Guid("22222222-2222-2222-2222-222222222222"), null, "liked your post", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("a1111111-a111-a111-a111-a11111111111"), 0, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("e2222222-e222-e222-e222-e22222222222"), new Guid("33333333-3333-3333-3333-333333333333"), null, "liked your post", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("a1111111-a111-a111-a111-a11111111111"), 0, new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "LikeCount", "ParentCommentId", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("c2222222-c222-c222-c222-c22222222222"), "Thanks! It was incredible.", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Guid("c1111111-c111-c111-c111-c11111111111"), new Guid("a1111111-a111-a111-a111-a11111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c5555555-c555-c555-c555-c55555555555"), "Sure, I'll DM you!", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Guid("c4444444-c444-c444-c444-c44444444444"), new Guid("a2222222-a222-a222-a222-a22222222222"), new Guid("22222222-2222-2222-2222-222222222222") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "ParentCommentId", "PostId", "UserId" },
                values: new object[] { new Guid("c7777777-c777-c777-c777-c77777777777"), "It's an LG 34\" ultrawide", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("c6666666-c666-c666-c666-c66666666666"), new Guid("a3333333-a333-a333-a333-a33333333333"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "CreatedAt", "PostId", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("d7777777-d777-d777-d777-d77777777777"), new Guid("c1111111-c111-c111-c111-c11111111111"), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, 1, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("d8888888-d888-d888-d888-d88888888888"), new Guid("c1111111-c111-c111-c111-c11111111111"), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, 1, new Guid("33333333-3333-3333-3333-333333333333") }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "ActorId", "CommentId", "Content", "CreatedAt", "IsRead", "PostId", "Type", "UserId" },
                values: new object[] { new Guid("e3333333-e333-e333-e333-e33333333333"), new Guid("22222222-2222-2222-2222-222222222222"), new Guid("c1111111-c111-c111-c111-c11111111111"), "commented on your post", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("a1111111-a111-a111-a111-a11111111111"), 1, new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "CreatedAt", "PostId", "Type", "UserId" },
                values: new object[] { new Guid("d9999999-d999-d999-d999-d99999999999"), new Guid("c2222222-c222-c222-c222-c22222222222"), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, 1, new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "ActorId", "CommentId", "Content", "CreatedAt", "IsRead", "PostId", "Type", "UserId" },
                values: new object[] { new Guid("e4444444-e444-e444-e444-e44444444444"), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("c2222222-c222-c222-c222-c22222222222"), "replied to your comment", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("a1111111-a111-a111-a111-a11111111111"), 1, new Guid("22222222-2222-2222-2222-222222222222") });
        }
    }
}
