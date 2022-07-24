using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorHramTemplate2.Models
{
    public static class myDateTimeExtension
    {
        public static string ToRus(this DateTime date)
        {
            switch (date.Month)
            {
                case 1: return $"{date.Day} января {date.Year}";
                case 2: return $"{date.Day} февраля {date.Year}";
                case 3: return $"{date.Day} марта {date.Year}";
                case 4: return $"{date.Day} апреля {date.Year}";
                case 5: return $"{date.Day} мая {date.Year}";
                case 6: return $"{date.Day} июня {date.Year}";
                case 7: return $"{date.Day} июля {date.Year}";
                case 8: return $"{date.Day} августа {date.Year}";
                case 9: return $"{date.Day} сентября {date.Year}";
                case 10: return $"{date.Day} октября {date.Year}";
                case 11: return $"{date.Day} ноября {date.Year}";
                case 12: return $"{date.Day} декабря {date.Year}";
            }

            return date.ToShortDateString();
        }

        public static string ToRusMonth(this DateTime date)
        {
            switch (date.Month)
            {
                case 1: return $"января";
                case 2: return $"февраля";
                case 3: return $"марта";
                case 4: return $"апреля";
                case 5: return $"мая";
                case 6: return $"июня";
                case 7: return $"июля";
                case 8: return $"августа";
                case 9: return $"сентября";
                case 10: return $"октября";
                case 11: return $"ноября";
                case 12: return $"декабря";
            }

            return date.Month.ToString();
        }
    }
}
