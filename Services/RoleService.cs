using blazorHramTemplate2.Data;
using blazorHramTemplate2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorHramTemplate2.Services
{
    public class RoleService
    {
        DbContextOptions<ApplicationDbContext> options;

        public RoleService(DbContextOptions<ApplicationDbContext> options)
        {
            this.options = options;
        }

        public List<IdentityRole> getAll()
        {
            List<IdentityRole> roles = new List<IdentityRole>();
            using (var context = new ApplicationDbContext(options))
            {
                roles = context.ASPNetRoles.ToList();
            }
            return roles;
        }

        public List<string> getById(string userId)
        {
            List<string> rolesId = new List<string>();
            List<string> roles = new List<string>();
            using (var context = new ApplicationDbContext(options))
            {
                rolesId = context.ASPNetUserRoles.Where(u => u.UserId == userId).Select(r => r.RoleId).ToList();
                foreach (var id in rolesId)
                {
                    roles.Add(context.ASPNetRoles.FirstOrDefault(r => r.Id == id).Name);
                }
            }
            return roles;
        }

        public void add(IdentityRole item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                context.ASPNetRoles.Add(item);
                context.SaveChanges();
            }
        }

        public void add(string item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                context.ASPNetRoles.Add(new IdentityRole { Name = item });
                context.SaveChanges();
            }
        }

        public void delete(IdentityRole item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                context.ASPNetRoles.Remove(item);
                context.SaveChanges();
            }
        }

        public void delete(string item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                context.ASPNetRoles.Remove(context.ASPNetRoles.FirstOrDefault(r => r.Name == item));
                context.SaveChanges();
            }
        }

        public void update(IdentityRole item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                context.ASPNetRoles.Update(item);
                context.SaveChanges();
            }
        }

        public void update(string item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                context.ASPNetRoles.Update(context.ASPNetRoles.FirstOrDefault(r => r.Name == item));
                context.SaveChanges();
            }
        }

        public void addRoleToUser(user user, IdentityRole role)
        {
            using (var context = new ApplicationDbContext(options))
            {
                if (user != null & context.AspNetUsers.FirstOrDefault(u => u.Id == user.Id) != null & role != null)
                {
                    if (!context.ASPNetRoles.Contains(role))
                    {
                        context.ASPNetRoles.Add(role);
                        context.SaveChanges();
                    }
                    context.ASPNetUserRoles.Add(new IdentityUserRole<string> { UserId = user.Id, RoleId = role.Id });
                    context.SaveChanges();
                }
            }
        }

        public void addRoleToUser(user user, string role)
        {
            using (var context = new ApplicationDbContext(options))
            {
                if (user != null & context.AspNetUsers.FirstOrDefault(u => u.Id == user.Id) != null & !string.IsNullOrEmpty(role))
                {
                    if (!context.ASPNetRoles.Contains(context.ASPNetRoles.FirstOrDefault(r => r.Name == role)))
                    {
                        context.ASPNetRoles.Add(new IdentityRole { Name = role });
                        context.SaveChanges();
                    }
                    context.ASPNetUserRoles.Add(new IdentityUserRole<string> { UserId = user.Id, RoleId = role });
                    context.SaveChanges();
                }
            }
        }
    }
}
