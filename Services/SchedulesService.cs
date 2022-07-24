using blazorHramTemplate2.Data;
using blazorHramTemplate2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace blazorHramTemplate2.Services
{
    public class ScheduleService
    {
        //ApplicationDbContext _context;
        DbContextOptions<ApplicationDbContext> _options;
        public ScheduleService(ApplicationDbContext context, DbContextOptions<ApplicationDbContext> options)
        {
            //_context = context;
            _options = options;
        }
        public List<schedule_string> schedule(DateTime schedule_year_and_month)
        {
            using (var context = new ApplicationDbContext(_options))
            {
                return context.schedule.Where(s => s.date_and_time.Year == schedule_year_and_month.Year && s.date_and_time.Month == schedule_year_and_month.Month).OrderBy(d => d.date_and_time).ToList();
            }
        }
        public async Task update_or_create(List<schedule_string> schedule)
        {
            using (var context = new ApplicationDbContext(_options))
            {
                foreach (var str in schedule)
                {
                    // сохраняем или меняем
                    if (!String.IsNullOrEmpty(str.description) || str.prayer != тип_службы.пусто || str.date_and_time.ToString() != "0:00")
                    {
                        if (str.ID == 0)
                        {
                            context.schedule.Add(str);
                        }
                        else
                        {
                            context.Update(str);
                        }
                    }

                }
                await context.SaveChangesAsync();
            }

            using (var context = new ApplicationDbContext(_options))
            {
                foreach (var str in context.schedule)
                {
                    // Очищаем пустые строки в бд, которые могли попасть после обновления данных
                    if (String.IsNullOrEmpty(str.description) && str.prayer == тип_службы.пусто)
                    {
                        context.Remove(str);
                    }
                }
                await context.SaveChangesAsync();
            }
        }
        public async Task delete(List<schedule_string> schedule)
        {
            using (var context = new ApplicationDbContext(_options))
            {
                foreach (var str in schedule)
                {
                    try { context.schedule.Remove(str); }
                    catch { }
                }
                await context.SaveChangesAsync();
            }
        }

        public bool has_schedule_in_this_date(DateTime date)
        {
            using (var context = new ApplicationDbContext(_options))
            {
                if (context.schedule.FirstOrDefault(str => str.date_and_time.Year == date.Year && str.date_and_time.Month == date.Month) != null)
                {
                    return true;
                }
                else return false;
            }
        }
    }
}
