using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace blazorHramTemplate2.Models
{
    [Table(name: "tags")]
    public class tag
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bootstrap_colors bg_color { get; set; } = bootstrap_colors.secondary;
        public bootstrap_colors text_color { get; set; } = bootstrap_colors.white;

        [DataType(DataType.Date)]
        public DateTime created { get; set; } = DateTime.Now;

        public List<post> posts { get; set; } = new List<post>();
    }
}
