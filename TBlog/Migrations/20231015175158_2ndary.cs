using Microsoft.EntityFrameworkCore.Migrations;

namespace TBlog.Migrations
{
    public partial class _2ndary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TagPosts_PId",
                table: "TagPosts",
                column: "PId");

            migrationBuilder.CreateIndex(
                name: "IX_TagPosts_TId",
                table: "TagPosts",
                column: "TId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagPosts_Posts_PId",
                table: "TagPosts",
                column: "PId",
                principalTable: "Posts",
                principalColumn: "PId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagPosts_Tags_TId",
                table: "TagPosts",
                column: "TId",
                principalTable: "Tags",
                principalColumn: "TId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagPosts_Posts_PId",
                table: "TagPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_TagPosts_Tags_TId",
                table: "TagPosts");

            migrationBuilder.DropIndex(
                name: "IX_TagPosts_PId",
                table: "TagPosts");

            migrationBuilder.DropIndex(
                name: "IX_TagPosts_TId",
                table: "TagPosts");
        }
    }
}
