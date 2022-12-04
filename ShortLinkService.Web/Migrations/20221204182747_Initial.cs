using Microsoft.EntityFrameworkCore.Migrations;

namespace ShortLinkService.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LinkAliases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullLink = table.Column<string>(maxLength: 416, nullable: true),
                    Token = table.Column<string>(maxLength: 26, nullable: true),
                    BitmapCodePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkAliases", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkAliases");
        }
    }
}
