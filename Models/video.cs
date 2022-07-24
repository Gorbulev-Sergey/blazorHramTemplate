﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace blazorHramTemplate2.Models
{
    [Table(name: "videos")]
    public class video
    {
        public int ID { get; set; }
        [Display(Name = "Url видео"), DataType(DataType.Url)]
        public string url { get; set; }

        [DataType(DataType.Date)]
        public DateTime created { get; set; } = DateTime.Now;

        public int? postID { get; set; }
    }
}
