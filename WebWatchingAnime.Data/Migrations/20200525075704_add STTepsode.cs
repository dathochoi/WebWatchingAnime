using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWatchingAnime.Data.Migrations
{
    public partial class addSTTepsode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "STT",
                table: "Episodes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "STT",
                table: "Episodes");
        }
    }
}
