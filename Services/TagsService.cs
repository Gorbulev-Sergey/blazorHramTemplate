using blazorHramTemplate2.Data;
using blazorHramTemplate2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorHramTemplate2.Services
{
    public class TagsService
    {
        DbContextOptions<ApplicationDbContext> options;
        public TagsService(DbContextOptions<ApplicationDbContext> options)
        {
            this.options = options;
        }

        public List<tag> tags()
        {
            using (var context = new ApplicationDbContext(options))
            {
                return context.tags.OrderBy(t => t.name).ToList();
            }
        }
        public async Task add(tag tag)
        {
            using (var context = new ApplicationDbContext(options))
            {
                if (tag != null && !String.IsNullOrWhiteSpace(tag.name))
                {
                    tag.description = tag.name;
                    context.tags.Add(tag);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task edit(tag tag)
        {
            using (var context = new ApplicationDbContext(options))
            {
                context.tags.Update(tag);
                await context.SaveChangesAsync();
            }
        }

        public async Task remove(tag tag)
        {
            using (var context = new ApplicationDbContext(options))
            {
                if (tag != null)
                {
                    context.tags.Remove(tag);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
