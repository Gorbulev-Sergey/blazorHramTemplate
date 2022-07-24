using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace blazorHramTemplate2.Models
{
    [Table(name: "imageAlbums")]
    public class imageAlbum
    {
        public int ID { get; set; }
        [Display(Name = "Название")]
        public string title { get; set; }
        [Display(Name = "Краткое описание")]
        public string description { get; set; }
        [Display(Name = "Обложка альбома"), DataType(DataType.ImageUrl)]
        public string cover_image { get; set; }
        [Display(Name = "Картинки")]
        public virtual IList<image> images { get; set; } = new List<image>();
        [Display(Name = "Комментарии")]
        public virtual IList<comment> comments { get; set; } = new List<comment>();
        [Display(Name = "Нравится")]
        public virtual IList<like> likes { get; set; } = new List<like>();
        [DataType(DataType.Date)]
        public DateTime created { get; set; } = DateTime.Now;
        public string userId { get; set; }
    }
}
