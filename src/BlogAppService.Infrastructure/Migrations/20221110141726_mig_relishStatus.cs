using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogAppService.Infrastructure.Migrations
{
    public partial class mig_relishStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RelishEnums",
                table: "ArticleRelishes",
                newName: "RelishStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RelishStatus",
                table: "ArticleRelishes",
                newName: "RelishEnums");
        }
    }
}
