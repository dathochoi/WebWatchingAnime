using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using WebWatchingAnime.Data.Entities;

namespace WebWatchingAnime.Data.Context
{
    public class WebDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public WebDbContext(DbContextOptions options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            modelBuilder.Entity<AnimeCategory>().HasKey(x => new { x.AnimeId, x.CategoryId });

            modelBuilder.Seed();
        }

        public DbSet<Anime> Animes { set; get; }
        public DbSet<Catetgory> Catetgories { set; get; }
        public DbSet<AnimeCategory> AnimeCategorys { set; get; }
        public DbSet<Episode> Episodes { set; get; }
        public DbSet<Season> Seasons { set; get; }
        public DbSet<Systems> Systems { set; get; }
        public DbSet<Year> Year { set; get; }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Sub> Subs { get; set; }

    }
}
