using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogAppService.Infrastructure.Migrations
{
    public partial class mig_userRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Articles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "ArticleRelishes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "ArticleCommentRelishes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "ArticleComment",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AppUserId",
                table: "Articles",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleRelishes_AppUserId",
                table: "ArticleRelishes",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCommentRelishes_AppUserId",
                table: "ArticleCommentRelishes",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComment_AppUserId",
                table: "ArticleComment",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleComment_AspNetUsers_AppUserId",
                table: "ArticleComment",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCommentRelishes_AspNetUsers_AppUserId",
                table: "ArticleCommentRelishes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleRelishes_AspNetUsers_AppUserId",
                table: "ArticleRelishes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_AppUserId",
                table: "Articles",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleComment_AspNetUsers_AppUserId",
                table: "ArticleComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCommentRelishes_AspNetUsers_AppUserId",
                table: "ArticleCommentRelishes");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleRelishes_AspNetUsers_AppUserId",
                table: "ArticleRelishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_AppUserId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_AppUserId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_ArticleRelishes_AppUserId",
                table: "ArticleRelishes");

            migrationBuilder.DropIndex(
                name: "IX_ArticleCommentRelishes_AppUserId",
                table: "ArticleCommentRelishes");

            migrationBuilder.DropIndex(
                name: "IX_ArticleComment_AppUserId",
                table: "ArticleComment");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ArticleRelishes");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ArticleCommentRelishes");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ArticleComment");
        }
    }
}
