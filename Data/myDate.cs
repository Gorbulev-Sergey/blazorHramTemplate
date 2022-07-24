using System;

namespace blazorHramTemplate2.Data
{
    public static class myDate
    {
        public static DateTime ToRusDate(this DateTime date)
        {
            return date.ToLocalTime();
        }
    }
}
