using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWatchingAnime.Data.Migrations
{
    public partial class updatestatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Year",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Year");
        }
    }
}
