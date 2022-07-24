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
    public class UserService
    {
        DbContextOptions<ApplicationDbContext> options;

        public UserService(DbContextOptions<ApplicationDbContext> options)
        {
            this.options = options;
        }

        public List<user> getAll()
        {
            List<user> users = new List<user>();
            using (var context = new ApplicationDbContext(options))
            {
                users = context.AspNetUsers.ToList();
            }
            return users;
        }

        public user getById(string id)
        {
            user user = new user();
            using (var context = new ApplicationDbContext(options))
            {
                user = context.AspNetUsers.FirstOrDefault(u => u.Id == id);
            }
            return user;
        }

        public void add(user item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                if (item != null)
                {
                    context.AspNetUsers.Add(item);
                    context.SaveChanges();
                }
            }
        }

        public void delete(user item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                if (item != null)
                {
                    context.AspNetUsers.Remove(item);
                    context.SaveChanges();
                }
            }
        }

        public void update(user item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                if (item != null)
                {
                    context.AspNetUsers.Update(item);
                    context.SaveChanges();
                }
            }
        }

        public List<IdentityRole> getUserRoles(user user)
        {
            List<IdentityRole> roles = new List<IdentityRole>();
            List<IdentityUserRole<string>> allUserRoles = new List<IdentityUserRole<string>>();
            using (var context = new ApplicationDbContext(options))
            {
                allUserRoles = context.ASPNetUserRoles.ToList();
            }
            using (var context = new ApplicationDbContext(options))
            {
                foreach (var item in allUserRoles)
                {
                    if (item.UserId == user.Id)
                    {
                        roles.Add(context.ASPNetRoles.FirstOrDefault(r => r.Id == item.RoleId));
                    }
                }
            }
            return roles;
        }

        public void addRoleToUser(user user, IdentityRole role)
        {
            using (var context = new ApplicationDbContext(options))
            {
                if (user != null & role != null & context.AspNetUsers.FirstOrDefault(u => u.Id == user.Id) != null)
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

        public void removeRoleFromUser(user user, IdentityRole role)
        {
            using (var context = new ApplicationDbContext(options))
            {
                if (user != null & role != null & context.AspNetUsers.FirstOrDefault(u => u.Id == user.Id) != null)
                {
                    try
                    {
                        context.ASPNetUserRoles.Remove(context.ASPNetUserRoles.FirstOrDefault(i => i.UserId == user.Id & i.RoleId == role.Id));
                    }
                    catch { }
                    context.SaveChanges();
                }
            }
        }
    }
}
