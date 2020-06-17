using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWatchingAnime.Data.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimeCategory",
                columns: table => new
                {
                    AnimeId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeCategory", x => new { x.AnimeId, x.CategoryId });
                });

            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    OrderName = table.Column<string>(nullable: true),
                    ImgSrc = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SrcTrailer = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    EpisodesMax = table.Column<string>(nullable: true),
                    IsAnime = table.Column<bool>(nullable: false),
                    IsEpisodes = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    SeasonId = table.Column<int>(nullable: true),
                    SeasonName = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CategoryIds = table.Column<string>(nullable: true),
                    SubId = table.Column<int>(nullable: false),
                    YearId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Src = table.Column<string>(nullable: false),
                    AnimeId = table.Column<int>(nullable: false),
                    STT = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Systems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    IconLogo = table.Column<string>(maxLength: 255, nullable: false),
                    ImageCover = table.Column<string>(maxLength: 255, nullable: false),
                    Lat = table.Column<float>(nullable: false),
                    Lng = table.Column<float>(nullable: false),
                    LinkFaceBook = table.Column<string>(nullable: false),
                    LinkInstargram = table.Column<string>(nullable: true),
                    Descaription = table.Column<string>(maxLength: 255, nullable: false),
                    NameWebsite = table.Column<string>(maxLength: 255, nullable: false),
                    Node = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Year",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 4, nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Year", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("7b126afe-40cf-40df-a036-3cef880bd782"), 0, "3f60615f-74e8-4d5c-93b1-72c8353cb88d", "dan@gmail.com", true, null, false, null, "dandan@gmail.com", "admin", "AQAAAAEAACcQAAAAEHNOOsEZrbvwTbZcH4V+waChsxTPRA1yozIc8XXl87+juIwuHuN7P4BItTLLg9WBsg==", null, false, "", false, false, "admin" },
                    { new Guid("f4db346b-3760-4c20-b8c8-76665732f710"), 0, "caac12b1-3701-4c1f-a0d0-6c2ae8845777", "dan2@gmail.com", true, null, false, null, "dandan2@gmail.com", "admin2", "AQAAAAEAACcQAAAAEK7PIUW3bQqztlc4zHRaE3R/BzouDnn5uNiMfxxg9CwVAmkOFv7zALQCOfPeY9vmeQ==", null, false, "", false, false, "admin2" },
                    { new Guid("26fc06da-acf9-44a5-ad53-e6dd60051716"), 0, "0b683d0d-0543-419c-ace2-8ba0097a6df0", "dan3@gmail.com", true, null, false, null, "dandan3@gmail.com", "admin3", "AQAAAAEAACcQAAAAEAB8UCJ7d7ZH/6UvGMf3RLCeeVHCm5h/oQPz34n15wkS4n8wdxO4ofBkq7FPHIOWfg==", null, false, "", false, false, "admin3" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { 22, "Âm nhạc", true },
                    { 21, "Thể Thao", true },
                    { 20, "Quân đội", true },
                    { 24, "Psychological", true },
                    { 23, "Ác quỷ", true },
                    { 19, "Seinen", true },
                    { 18, "Drama", true },
                    { 17, "Mystery", true },
                    { 15, "Trò chơi", true },
                    { 14, "Phép thuật", true },
                    { 13, "Shounen", true },
                    { 16, "Thám tử", true },
                    { 11, "Harem", true },
                    { 12, "Ecchi", true },
                    { 2, "Tình cảm", true },
                    { 3, "Lịch sử", true },
                    { 4, "Hài hước", true },
                    { 5, "Viễn tưởng", true },
                    { 1, "Hành động", true },
                    { 7, "Giả tưởng", true },
                    { 8, "Kinh dị", true },
                    { 9, "Đời thường", true },
                    { 10, "Học đường", true },
                    { 6, "Võ thuật", true }
                });

            migrationBuilder.InsertData(
                table: "Year",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { 10, "2019", true },
                    { 1, "2010", true },
                    { 2, "2011", true },
                    { 3, "2012", true },
                    { 4, "2013", true },
                    { 5, "2014", true },
                    { 6, "2015", true },
                    { 7, "2016", true },
                    { 8, "2017", true },
                    { 9, "2018", true },
                    { 11, "2020", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeCategory");

            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropTable(
                name: "AppRole");

            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Subs");

            migrationBuilder.DropTable(
                name: "Systems");

            migrationBuilder.DropTable(
                name: "Year");
        }
    }
}
