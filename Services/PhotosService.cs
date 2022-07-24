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
    public class PhotosService
    {
        DbContextOptions<ApplicationDbContext> options;

        public PhotosService(DbContextOptions<ApplicationDbContext> options)
        {
            this.options = options;
        }

        public void add(imageAlbum item)
        {
            item.images = item.images.ToList().Where(i => !string.IsNullOrEmpty(i.url)).ToList();
            using (var context = new ApplicationDbContext(options))
            {
                context.imageAlbums.Add(item);
                context.SaveChanges();
            }
        }

        public async Task addAsync(imageAlbum item)
        {
            item.images = item.images.ToList().Where(i => !string.IsNullOrEmpty(i.url)).ToList();
            //foreach (var i in item.images)
            //{
            //    if (string.IsNullOrEmpty(i.url)) item.images.Remove(i);
            //}

            using (var context = new ApplicationDbContext(options))
            {
                context.imageAlbums.Add(item);
                await context.SaveChangesAsync();
            }
        }

        public void delete(imageAlbum item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                context.imageAlbums.Remove(item);
                context.SaveChanges();
            }
        }

        public async Task deleteAsync(imageAlbum item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                context.imageAlbums.Remove(item);
                await context.SaveChangesAsync();
            }
        }

        public List<imageAlbum> get()
        {
            using (var context = new ApplicationDbContext(options))
            {
                return context.imageAlbums.Include(i => i.images).OrderBy(i => i.ID).ToList();
            }
        }

        public async Task<List<imageAlbum>> getAsync()
        {
            using (var context = new ApplicationDbContext(options))
            {
                return await context.imageAlbums.Include(i => i.images).OrderBy(i => i.ID).ToListAsync();
            }
        }

        /// <summary>
        /// Получить альбом по его id
        /// </summary>
        /// <param name="id">id альбома</param>
        /// <returns></returns>
        public imageAlbum itemById(int id)
        {
            using (var context = new ApplicationDbContext(options))
            {
                return context.imageAlbums.Include(i => i.images).FirstOrDefault(a => a.ID == id);
            }
        }

        public async Task<imageAlbum> itemByIdAsync(int id)
        {
            using (var context = new ApplicationDbContext(options))
            {
                return await context.imageAlbums.Include(i => i.images).FirstOrDefaultAsync(a => a.ID == id);
            }
        }

        public void update(imageAlbum item)
        {
            using (var context = new ApplicationDbContext(options))
            {
                var album = context.imageAlbums.Include(i => i.images).FirstOrDefault(a => a.ID == item.ID);
                album.images.Clear();
                context.SaveChanges();
            }


            using (var context = new ApplicationDbContext(options))
            {
                var album = context.imageAlbums.FirstOrDefault(a => a.ID == item.ID);
                album.title = item.title;
                album.cover_image = item.cover_image;
                album.description = item.description;
                foreach (var i in item.images)
                {
                    if (!string.IsNullOrEmpty(i.url))
                    {
                        album.images.Add(i);
                    }
                }
                context.SaveChanges();
            }
        }

        public async Task updateAsync(imageAlbum item)
        {
            update(item);
        }
    }
}
