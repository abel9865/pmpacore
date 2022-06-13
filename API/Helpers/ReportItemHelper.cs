using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;


namespace API.Helpers
{
    public class ReportItemHelper
    {

        public static List<ApiItems> GetItems(string token)
        {
            var BoldReportsURL = "http://desktop-1mq5eqq:49987";
            var itemType = "Report";

            using (var proxy = new CustomWebClient())
            {
                proxy.Headers["Content-type"] = "application/json";
                proxy.Headers["Authorization"] = token;
                    //token.token_type + " " + token.access_token; // token must be passed here
                proxy.Encoding = Encoding.UTF8;

                try
                {
                    var rdata = proxy.DownloadString(new Uri(BoldReportsURL + "/reporting/api/site/acmerpt/v1.0/items?itemType=" + itemType));
                    var response = JsonConvert.DeserializeObject<List<ApiItems>>(rdata);
                    return response;
                }
                catch (WebException ex)
                {
                    if (ex.Response is HttpWebResponse)
                    {
                        var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                        dynamic obj = JsonConvert.DeserializeObject(resp);
                        Console.WriteLine(obj);
                    }
                }
                return null;
            }
        }

    }
    public class ApiItems
    {
        public bool CanRead { get; set; }

        public bool CanWrite { get; set; }

        public bool CanDelete { get; set; }

        public bool CanSchedule { get; set; }

        public bool CanDownload { get; set; }

        public bool CanOpen { get; set; }

        public bool CanMove { get; set; }

        public bool CanCopy { get; set; }

        public bool CanClone { get; set; }

        public bool CanCreateItem { get; set; }

        public Guid? CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int ModifiedById { get; set; }

        public string CreatedByDisplayName { get; set; }

        public int CreatedById { get; set; }

        public string ModifiedByFullName { get; set; }

        public string ItemLocation { get; set; }

        public int ItemType { get; set; }

        public Guid Id { get; set; }

        public string CreatedDate { get; set; }

        public string ModifiedDate { get; set; }

        public DateTime ItemModifiedDate { get; set; }

        public DateTime ItemCreatedDate { get; set; }

        public Guid ReportId { get; set; }

        public string ReportName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }

    class CustomWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            var request = base.GetWebRequest(uri);
            request.Timeout = 4 * 60 * 1000; //Increase time out
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).KeepAlive = false;
            }
            return request;
        }
    }
}
