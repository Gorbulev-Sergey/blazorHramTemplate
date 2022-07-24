using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace blazorHramTemplate2.Models
{
    public class appsettings
    {
        public Dictionary<string, string> ConnectionStrings { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, Dictionary<string, string>> Logging { get; set; } = new Dictionary<string, Dictionary<string, string>>();
        public string AllowedHosts { get; set; }
        public site_settings SiteSettings { get; set; } = new site_settings();
    }

    public class site_settings
    {
        public string site_name { get; set; }
        public string site_description { get; set; }
        public string site_footer { get; set; }
    }
}
