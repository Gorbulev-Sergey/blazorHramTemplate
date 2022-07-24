using blazorHramTemplate2.Data;
using blazorHramTemplate2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorHramTemplate2.Services
{
    public class PostsService
    {
        DbContextOptions<ApplicationDbContext> options;
        string Tag;
        int Page = 1;
        int Take = 6;
        public bool canNext = true;

        public PostsService(DbContextOptions<ApplicationDbContext> options)
        {
            this.options = options;
        }

        public List<post> getNext(string tag = "объявления")
        {
            if (Tag != tag) { Tag = tag; Page = 1; }
            using (var context = new ApplicationDbContext(options))
            {
                var posts = context.posts.Include(p => p.tags).Include(p => p.comments).Include(p => p.likes).OrderByDescending(d => d.created).Where(p => p.tags.FirstOrDefault(t => t.name == tag).posts.Count > 0);

                if (posts.Count() > 0)
                {
                    if (posts.Count() <= Take * Page)
                    {
                        canNext = false;
                    }
                    else if (posts.Count() > Take * Page)
                    {
                        canNext = true;
                    }
                    posts = posts.Skip(0).Take(Take * Page);
                    Page++;
                    return posts.ToList();
                }
                else return new List<post>();

            }
        }

        public void add(post item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                var newTags = item.tags;
                item.tags = null;
                context.posts.Add(item);
                context.SaveChanges();

                context.posts.Include(p => p.tags).FirstOrDefault(p => p.Equals(item)).tags.AddRange(newTags);
                context.SaveChanges();
            }
        }

        public async Task addAsync(post item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                var newTags = item.tags;
                item.tags = null;
                context.posts.Add(item);
                await context.SaveChangesAsync();

                context.posts.Include(p => p.tags).FirstOrDefault(p => p.Equals(item)).tags.AddRange(newTags);
                await context.SaveChangesAsync();
            }
        }

        public void delete(post item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                context.posts.Remove(item);
                context.SaveChanges();
            }
        }

        public async Task deleteAsync(post item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                context.posts.Remove(item);
                await context.SaveChangesAsync();
            }
        }

        public List<post> get()
        {
            using (var context = new ApplicationDbContext(options))
            {
                var posts = context.posts.Include(p => p.tags).Include(p => p.comments).Include(p => p.likes).ToList();
                return posts.OrderBy(p => p.created).ToList();
            }
        }

        public async Task<List<post>> getAsync()
        {
            using (var context = new ApplicationDbContext(options))
            {
                var posts = await context.posts.Include(p => p.tags).Include(p => p.comments).Include(p => p.likes).ToListAsync();
                return posts.OrderBy(p => p.created).ToList();
            }
        }

        public post itemById(int id)
        {
            using (var context = new ApplicationDbContext(options))
            {
                return context.posts.Include(p => p.tags).Include(p => p.comments).Include(p => p.likes).FirstOrDefault(p => p.ID == id);
            }
        }

        public async Task<post> itemByIdAsync(int id)
        {
            using (var context = new ApplicationDbContext(options))
            {
                return await context.posts.Include(p => p.tags).Include(p => p.comments).Include(p => p.likes).FirstOrDefaultAsync(p => p.ID == id);
            }
        }

        public void update(post item)
        {
            // Обновляем всё, кроме тегов
            using (var context = new ApplicationDbContext(options))
            {
                var tags = item.tags;
                item.tags = null;
                context.Update(item);
                context.SaveChanges();

                item.tags = tags;
            }

            // Обновляем теги
            using (var context = new ApplicationDbContext(options))
            {
                post postDB = context.posts.Include(t => t.tags).FirstOrDefault(p => p.ID == item.ID);

                // Работаем с тегами
                List<tag> новыеТеги = item.tags;
                List<tag> старыеТеги = postDB.tags;
                List<tag> наДобавление = новыеТеги.Where(t => t.posts.Count == 0).ToList();
                List<tag> наУдаление = старыеТеги.Where(x => новыеТеги.All(a => a.ID != x.ID)).ToList();

                postDB.tags.AddRange(наДобавление);
                foreach (var t in наУдаление)
                {
                    postDB.tags.Remove(t);
                }

                context.SaveChanges();
            }
        }

        public async Task updateAsync(post item)
        {
            // Обновляем всё, кроме тегов
            using (var context = new ApplicationDbContext(options))
            {
                var tags = item.tags;
                item.tags = null;
                context.Update(item);
                await context.SaveChangesAsync();

                item.tags = tags;
            }

            // Обновляем теги
            using (var context = new ApplicationDbContext(options))
            {
                post postDB = context.posts.Include(t => t.tags).FirstOrDefault(p => p.ID == item.ID);

                // Работаем с тегами
                List<tag> новыеТеги = item.tags;
                List<tag> старыеТеги = postDB.tags;
                List<tag> наДобавление = новыеТеги.Where(t => t.posts.Count == 0).ToList();
                List<tag> наУдаление = старыеТеги.Where(x => новыеТеги.All(a => a.ID != x.ID)).ToList();

                postDB.tags.AddRange(наДобавление);
                foreach (var t in наУдаление)
                {
                    postDB.tags.Remove(t);
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
