using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace blazorHramTemplate2.Models
{
    public class user : IdentityUser
    {
        [PersonalData, Display(Name = "Публикации")]
        public virtual IList<post> posts { get; set; } = new List<post>();
        [PersonalData, Display(Name = "Албомы фотографий")]
        public virtual IList<imageAlbum> imageAlbums { get; set; } = new List<imageAlbum>();
        [PersonalData, Display(Name = "Комментарии")]
        public virtual IList<comment> comments { get; set; } = new List<comment>();
        [PersonalData, Display(Name = "Лайки")]
        public virtual IList<like> likes { get; set; } = new List<like>();
        [PersonalData, Display(Name = "Расписания")]
        public virtual IList<schedule_string> schedule { get; set; }

        //public virtual IList<IdentityRole> ASPNetRoles { get; set; }
    }
}
