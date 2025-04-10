using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Instagram_Backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Users_UserId",
                table: "Likes");

            migrationBuilder.DropTable(
                name: "UserUser");

            migrationBuilder.CreateTable(
                name: "UserFollowers",
                columns: table => new
                {
                    FollowingId = table.Column<Guid>(type: "uuid", nullable: false),
                    FollowerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollowers", x => new { x.FollowerId, x.FollowingId });
                    table.ForeignKey(
                        name: "FK_UserFollowers_Users_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserFollowers_Users_FollowingId",
                        column: x => x.FollowingId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "RefreshToken", "RefreshTokenExpiresAtUtc", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), 0, "Photography enthusiast and traveler", "adae4445-ecf6-4fb2-a7e3-25d04cfe3fe9", "john@example.com", true, "John", "Doe", false, null, "JOHN@EXAMPLE.COM", "JOHNDOE", "AQAAAAIAAYagAAAAEG9Yh999XbrReKfYRF6NzknIDvSmTjBuDq4KQkfqZweYlubTSIOeVLFmxSD3tar1IA==", null, false, "https://randomuser.me/api/portraits/men/1.jpg", null, null, null, false, "johndoe" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 0, "Food blogger | Travel lover", "77cbcba0-e069-4b81-aea0-5495ca4dfb99", "jane@example.com", true, "Jane", "Smith", false, null, "JANE@EXAMPLE.COM", "JANESMITH", "AQAAAAIAAYagAAAAEG9Yh999XbrReKfYRF6NzknIDvSmTjBuDq4KQkfqZweYlubTSIOeVLFmxSD3tar1IA==", null, false, "https://randomuser.me/api/portraits/women/1.jpg", null, null, null, false, "janesmith" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 0, "Software developer and coffee addict", "5bd3d7d5-a190-4ebe-890f-fb9fe4f88f07", "alex@example.com", true, "Alex", "Johnson", false, null, "ALEX@EXAMPLE.COM", "ALEXJ", "AQAAAAIAAYagAAAAEG9Yh999XbrReKfYRF6NzknIDvSmTjBuDq4KQkfqZweYlubTSIOeVLFmxSD3tar1IA==", null, false, "https://randomuser.me/api/portraits/men/2.jpg", null, null, null, false, "alexj" }
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
                    { new Guid("a1111111-a111-a111-a111-a11111111111"), "Beautiful sunset at the beach!", 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("a2222222-a222-a222-a222-a22222222222"), "My homemade pasta recipe 🍝", 3, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 42, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("a3333333-a333-a333-a333-a33333333333"), "New coding setup complete", 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), 28, new Guid("33333333-3333-3333-3333-333333333333") }
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
                    { new Guid("b1111111-b111-b111-b111-b11111111111"), 1, new Guid("a1111111-a111-a111-a111-a11111111111"), "https://picsum.photos/id/1/800/800" },
                    { new Guid("b2222222-b222-b222-b222-b22222222222"), 1, new Guid("a2222222-a222-a222-a222-a22222222222"), "https://picsum.photos/id/2/800/800" },
                    { new Guid("b3333333-b333-b333-b333-b33333333333"), 2, new Guid("a2222222-a222-a222-a222-a22222222222"), "https://picsum.photos/id/3/800/800" },
                    { new Guid("b4444444-b444-b444-b444-b44444444444"), 1, new Guid("a3333333-a333-a333-a333-a33333333333"), "https://picsum.photos/id/4/800/800" }
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

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowers_FollowingId",
                table: "UserFollowers",
                column: "FollowingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Users_UserId",
                table: "Likes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Users_UserId",
                table: "Likes");

            migrationBuilder.DropTable(
                name: "UserFollowers");

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
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.CreateTable(
                name: "UserUser",
                columns: table => new
                {
                    FollowersId = table.Column<Guid>(type: "uuid", nullable: false),
                    FollowingId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUser", x => new { x.FollowersId, x.FollowingId });
                    table.ForeignKey(
                        name: "FK_UserUser_Users_FollowersId",
                        column: x => x.FollowersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUser_Users_FollowingId",
                        column: x => x.FollowingId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserUser_FollowingId",
                table: "UserUser",
                column: "FollowingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Users_UserId",
                table: "Likes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
