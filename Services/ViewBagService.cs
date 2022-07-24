using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorHramTemplate2.Services
{
    public class ViewBagService
    {
        public string PageTitle { get; set; }
        //public string BackUrl
        //{
        //    //get => js.InvokeAsync<string>("getItem", "tag").Result.ToString();
        //    //set
        //    //{
        //    //    js.InvokeVoidAsync("setItem", "tag", value);
        //    //}
        //}
    }
}
