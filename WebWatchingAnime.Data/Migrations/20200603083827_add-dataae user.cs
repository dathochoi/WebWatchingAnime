using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWatchingAnime.Data.Migrations
{
    public partial class adddataaeuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("84ec622b-f39e-4037-8034-dc6cd9920fe1"), 0, "88b6b659-c782-4794-ab50-96326446b81d", "dan@gmail.com", true, null, false, null, "dandan@gmail.com", "admin", "AQAAAAEAACcQAAAAEIQRVNmRgL83wnEiOkNE/LMJu6vLCxObrEyF2rXbqzYqZKYkGapDjgnRKyaAj9jUGw==", null, false, "", false, false, "admin" });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("23887e4c-28b4-4cf1-940f-77788d304317"), 0, "9080c5a1-7ea5-4220-b920-d1161ef36d93", "dan2@gmail.com", true, null, false, null, "dandan2@gmail.com", "admin2", "AQAAAAEAACcQAAAAEBH1YTjhGoJvgFQZl4krKj0tjo+I+/dz8GXrcIGhaGHu/jTHUbgI+k2G+KG0alqH7g==", null, false, "", false, false, "admin2" });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("66013d83-c7dd-4310-a407-672d88f7c536"), 0, "f0bc197f-dfed-474e-a7d5-d0fce075293b", "dan3@gmail.com", true, null, false, null, "dandan3@gmail.com", "admin3", "AQAAAAEAACcQAAAAEPIdgM3Io2jw3pjg3Vi9xnrSzq8oiM93I1HNB0RCbyxuNpHjNwphjXWTKYALTw51sw==", null, false, "", false, false, "admin3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("23887e4c-28b4-4cf1-940f-77788d304317"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("66013d83-c7dd-4310-a407-672d88f7c536"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("84ec622b-f39e-4037-8034-dc6cd9920fe1"));
        }
    }
}
