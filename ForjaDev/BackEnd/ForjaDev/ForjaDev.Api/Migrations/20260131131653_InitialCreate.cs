using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForjaDev.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "VARCHAR", maxLength: 180, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    password_hash = table.Column<string>(type: "VARCHAR", maxLength: 260, nullable: false),
                    email = table.Column<string>(type: "VARCHAR", maxLength: 220, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "member",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at_utc = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    slug = table.Column<string>(type: "VARCHAR", maxLength: 200, nullable: false),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 200, nullable: false),
                    role_title = table.Column<string>(type: "VARCHAR", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_member_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "following",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberToFollowId = table.Column<Guid>(type: "uuid", nullable: false),
                    FollowingMemberId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_following", x => x.Id);
                    table.ForeignKey(
                        name: "fk_following_follower_member",
                        column: x => x.MemberToFollowId,
                        principalTable: "member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_following_target_member",
                        column: x => x.FollowingMemberId,
                        principalTable: "member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    tag = table.Column<string>(type: "VARCHAR", maxLength: 180, nullable: false),
                    title = table.Column<string>(type: "VARCHAR", maxLength: 200, nullable: false),
                    body = table.Column<string>(type: "Text", nullable: false),
                    create_at_utc = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    likes_count = table.Column<int>(type: "INT", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_post", x => x.Id);
                    table.ForeignKey(
                        name: "fk_post_category",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_post_member",
                        column: x => x.MemberId,
                        principalTable: "member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    message = table.Column<string>(type: "TEXT", nullable: false),
                    create_at_utc = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    ParentCommentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comment", x => x.Id);
                    table.ForeignKey(
                        name: "fk_comment_member",
                        column: x => x.MemberId,
                        principalTable: "member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_comment_parent_comment",
                        column: x => x.ParentCommentId,
                        principalTable: "comment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_comment_post",
                        column: x => x.PostId,
                        principalTable: "post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "likes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    member_id = table.Column<Guid>(type: "uuid", nullable: false),
                    post_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_likes", x => x.id);
                    table.ForeignKey(
                        name: "FK_likes_member_member_id",
                        column: x => x.member_id,
                        principalTable: "member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_likes_post_PostId",
                        column: x => x.PostId,
                        principalTable: "post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comment_MemberId",
                table: "comment",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_ParentCommentId",
                table: "comment",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_PostId",
                table: "comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_following_FollowingMemberId",
                table: "following",
                column: "FollowingMemberId");

            migrationBuilder.CreateIndex(
                name: "ix_following_unique_relationship",
                table: "following",
                columns: new[] { "MemberToFollowId", "FollowingMemberId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_likes_member_id",
                table: "likes",
                column: "member_id");

            migrationBuilder.CreateIndex(
                name: "IX_likes_PostId",
                table: "likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_member_UserId",
                table: "member",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_post_CategoryId",
                table: "post",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_post_MemberId",
                table: "post",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "following");

            migrationBuilder.DropTable(
                name: "likes");

            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "member");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
