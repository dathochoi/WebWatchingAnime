using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWatchingAnime.Data.Migrations
{
    public partial class addmaxesps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EpisodesMax",
                table: "Animes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EpisodesMax",
                table: "Animes");
        }
    }
}
