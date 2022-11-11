using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogAppService.Infrastructure.Migrations
{
    public partial class mig_userKeyRelishes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleRelishes_AspNetUsers_AppUserId",
                table: "ArticleRelishes");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "ArticleRelishes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleRelishes_AspNetUsers_AppUserId",
                table: "ArticleRelishes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleRelishes_AspNetUsers_AppUserId",
                table: "ArticleRelishes");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "ArticleRelishes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleRelishes_AspNetUsers_AppUserId",
                table: "ArticleRelishes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
