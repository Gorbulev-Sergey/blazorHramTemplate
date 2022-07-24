using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace blazorHramTemplate2.Models
{
    public enum type
    {
        [Display(Name = "Объявление")]
        объявление,
        [Display(Name = "Новость")]
        новость,
        [Display(Name = "Cтатья")]
        статья,
        [Display(Name = "Видео")]
        видео

    }
}
