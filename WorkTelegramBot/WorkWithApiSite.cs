using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;

namespace WorkTelegramBot
{
    class WorkWithApiSite
    {
        public string GetData(DateTime date)
        {
            WebClient client = new WebClient();
            string sBaseUrl = "https://api.privatbank.ua/p24api/exchange_rates?json&date=" + date.ToShortDateString();
            string allCourse = client.DownloadString(sBaseUrl);
            return allCourse;
        }
    }
}
