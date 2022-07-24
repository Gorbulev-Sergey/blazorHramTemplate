using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorHramTemplate2.Models
{
    public class Filter
    {
        //Для сортировки на опубликованные и неопубликованные
        public filter1 filter1 { get; set; } = new filter1();
        // Для сортировки по типу публикации
        public filter2 filter2 { get; set; } = new filter2();
        // Для сортировки по дате
        public filter3 filter3 { get; set; } = new filter3();
        // Для тегов
        public string filter4 { get; set; }
    }

    public enum filter1
    {
        все,
        опубликованые,
        неопубликованые
    }

    public enum filter2
    {
        все,
        объявление,
        новость,
        статья,
        видео
    }

    public enum filter3
    {
        новые,
        старые
    }
}
