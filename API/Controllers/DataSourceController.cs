using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using API.Helpers;
using API.Helpers.DashboardHelpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
	[ApiExplorerSettings(IgnoreApi = true)]
	public class DataSourceController : BaseApiController
	{
        [HttpGet("GetDataSourceItems")]
        public List<DashboardItem> GetDataSourceItems()
        {
            var token = DashboardToken.GetDashboardToken(UserAccessor);
            return GetItems(token);
        }


        public static List<DashboardItem> GetItems(string token)
        {
            var BoldURL = "http://desktop-1mq5eqq:49987";


            using (var proxy = new CustomWebClient())
            {
                proxy.Headers["Content-type"] = "application/json";
                proxy.Headers["Authorization"] = "bearer " + token;
                //token.token_type + " " + token.access_token; // token must be passed here
                proxy.Encoding = Encoding.UTF8;

                try
                {
                    //https://{yourdomain}/bi/api/site/<site_identifier>/v2.0/items
                    var rdata = proxy.DownloadString(new Uri(BoldURL + "/bi/api/site/acmebi/v2.0/items?itemType=4"));
                    var response = JsonConvert.DeserializeObject<List<DashboardItem>>(rdata);
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
}

