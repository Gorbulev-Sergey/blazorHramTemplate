using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace blazorHramTemplate2.Models
{
    [Table(name: "general")]
    public class general
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string db_connection_string { get; set; }
    }
}
