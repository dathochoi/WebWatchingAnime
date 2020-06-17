using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebWatchingAnime.Data.Entities;

namespace WebWatchingAnime.Data.Context
{
    public static class ModelBuilderExtensions
    {
        private static object hasher;

        public static void Seed(this ModelBuilder modelBuilder)
        {
            var adminId = Guid.NewGuid();
            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = adminId,
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    Email = "dan@gmail.com",
                    NormalizedEmail = "dandan@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "12345"),
                    SecurityStamp = string.Empty,
                }
              );

             adminId = Guid.NewGuid();
             hasher = new PasswordHasher<AppUser>();
             modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = adminId,
                    UserName = "admin2",
                    NormalizedUserName = "admin2",
                    Email = "dan2@gmail.com",
                    NormalizedEmail = "dandan2@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "12345"),
                    SecurityStamp = string.Empty,
                }
              );
            adminId = Guid.NewGuid();
            hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
               new AppUser()
               {
                   Id = adminId,
                   UserName = "admin3",
                   NormalizedUserName = "admin3",
                   Email = "dan3@gmail.com",
                   NormalizedEmail = "dandan3@gmail.com",
                   EmailConfirmed = true,
                   PasswordHash = hasher.HashPassword(null, "12345"),
                   SecurityStamp = string.Empty,
               }
             );

            modelBuilder.Entity<Year>().HasData(
                 new Year()
                 {
                     Id = 1,
                     Name = "2010",
                     Status = true
                 },
                 new Year()
                 {
                     Id = 2,
                     Name = "2011",
                     Status = true
                 },
                 new Year()
                 {
                     Id = 3,
                     Name = "2012",
                     Status = true
                 },
                 new Year()
                 {
                     Id = 4,
                     Name = "2013",
                     Status = true
                 },

                 new Year()
                 {
                     Id = 5,
                     Name = "2014",
                     Status = true
                 },
                 new Year()
                 {
                     Id = 6,
                     Name = "2015",
                     Status = true
                 },
                 new Year()
                 {
                     Id = 7,
                     Name = "2016",
                     Status = true
                 },
                 new Year()
                 {
                     Id = 8,
                     Name = "2017",
                     Status = true
                 },
                 new Year()
                 {
                     Id = 9,
                     Name = "2018",
                     Status = true
                 },
                 new Year()
                 {
                     Id = 10,
                     Name = "2019",
                     Status = true
                 },
                 new Year()
                 {
                     Id = 11,
                     Name = "2020",
                     Status = true
                 }
                 );

            modelBuilder.Entity<Catetgory>().HasData(
                   new Catetgory()
                   {
                       Id = 1,
                       Name = "Hành động",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 2,
                       Name = "Tình cảm",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 3,
                       Name = "Lịch sử",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 4,
                       Name = "Hài hước",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 5,
                       Name = "Viễn tưởng",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 6,
                       Name = "Võ thuật",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 7,
                       Name = "Giả tưởng",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 8,
                       Name = "Kinh dị",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 9,
                       Name = "Đời thường",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 10,
                       Name = "Học đường",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 11,
                       Name = "Harem",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 12,
                       Name = "Ecchi",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 13,
                       Name = "Shounen",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 14,
                       Name = "Phép thuật",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 15,
                       Name = "Trò chơi",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 16,
                       Name = "Thám tử",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 17,
                       Name = "Mystery",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 18,
                       Name = "Drama",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 19,
                       Name = "Seinen",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 23,
                       Name = "Ác quỷ",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 24,
                       Name = "Psychological",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 20,
                       Name = "Quân đội",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 21,
                       Name = "Thể Thao",
                       Status = true
                   },
                   new Catetgory()
                   {
                       Id = 22,
                       Name = "Âm nhạc",
                       Status = true
                   });
        }
    }
}
