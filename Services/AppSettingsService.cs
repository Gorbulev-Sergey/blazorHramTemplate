using blazorHramTemplate2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace blazorHramTemplate2.Services
{
    public class AppSettingsService
    {
        public appsettings settings
        {
            get
            {
                using (StreamReader reader = new StreamReader(new FileStream(path: "appsettings.json", mode: FileMode.OpenOrCreate)))
                {
                    return JsonConvert.DeserializeObject<appsettings>(reader.ReadToEnd());
                }
            }
            set
            {
                using (StreamWriter writer = new StreamWriter(new FileStream(path: "appsettings.json", mode: FileMode.Truncate)))
                {
                    writer.Write(JsonConvert.SerializeObject(value));
                }
            }
        }
    }
}
