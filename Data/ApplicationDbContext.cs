using blazorHramTemplate2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace blazorHramTemplate2.Data
{
    public class ApplicationDbContext : IdentityDbContext<user>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();

            if (Roles.Count() == 0 || tags.Count() == 0)
            {
                Roles.AddRange(new IdentityRole { Name = "администратор", NormalizedName = "АДМИНИСТРАТОР" },
                    new IdentityRole { Name = "редактор", NormalizedName = "РЕДАКТОР" });
                tags.AddRange(
                    new tag { name = "объявления", description = "Объявления" },
                    new tag { name = "новости", description = "Новости" },
                    new tag { name = "видео", description = "Видеозаписи" });
                SaveChanges();
            }
        }

        public DbSet<user> AspNetUsers { get; set; }
        public DbSet<IdentityRole> ASPNetRoles { get; set; }
        public DbSet<IdentityUserRole<string>> ASPNetUserRoles { get; set; }

        public DbSet<post> posts { get; set; }
        public DbSet<comment> comments { get; set; }
        public DbSet<like> likes { get; set; }
        public DbSet<tag> tags { get; set; }
        public DbSet<imageAlbum> imageAlbums { get; set; }
        public DbSet<schedule_string> schedule { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
