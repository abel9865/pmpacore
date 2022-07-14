using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using API.Helpers;
using API.Helpers.DashboardHelpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
   // [AllowAnonymous]
    public class DashboardController : BaseApiController
    {
       

        [HttpPost]
        [Route("GetDetails")]
        public string GetDetails([FromBody] object embedQuerString)
        {
            var embedClass = Newtonsoft.Json.JsonConvert.DeserializeObject<EmbedClass>(embedQuerString.ToString());

            var embedQuery = embedClass.embedQuerString;
            // User your user-email as embed_user_email
            embedQuery += "&embed_user_email=" + EmbedProperties.UserEmail;
            var embedDetailsUrl = "/embed/authorize?" + embedQuery.ToLower() + "&embed_signature=" + GetSignatureUrl(embedQuery.ToLower());

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(embedClass.dashboardServerApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();

                var result = client.GetAsync(embedClass.dashboardServerApiUrl + embedDetailsUrl).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                return resultContent;
            }

        }

        public string GetSignatureUrl(string queryString)
        {
            if (queryString != null)
            {
                var encoding = new System.Text.UTF8Encoding();
                var keyBytes = encoding.GetBytes(EmbedProperties.EmbedSecret);
                var messageBytes = encoding.GetBytes(queryString);
                using (var hmacsha1 = new HMACSHA256(keyBytes))
                {
                    var hashMessage = hmacsha1.ComputeHash(messageBytes);
                    return Convert.ToBase64String(hashMessage);
                }
            }
            return string.Empty;
        }



        [HttpGet("GetDashboardToken")]
        public string GetDashboardToken()
        {
            return DashboardToken.GetDashboardToken(UserAccessor);


            //var userName = UserAccessor.GetUsername();
            //userName = "abel9865@gmail.com";
            //var password = "Sw33tt34!";
            ////var tkApi = "http://desktop-1mq5eqq:49987/reporting/api/site/acmerpt/get-user-key";
            //var tkUrl = "http://desktop-1mq5eqq:49987/bi/api/site/acmebi/token";
            //var rptTokenHelper = new ReportTokenHelper();
            //return rptTokenHelper.GenerateToken(tkUrl, userName, password);

        }

        [HttpGet("GetDashboardItems")]
        public List<DashboardItem> GetDashboardItems()
        {
            var token = GetDashboardToken();
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
                    var rdata = proxy.DownloadString(new Uri(BoldURL + "/bi/api/site/acmebi/v2.0/items?itemType=2"));
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

        [HttpPost("DeleteDashboard/{id}")]
        public bool DeleteDashboard(string id)
        {
            var BoldURL = "http://desktop-1mq5eqq:49987";


            using (var client = new HttpClient())
            {

        
                client.BaseAddress = new Uri(BoldURL + "/bi/api/site/acmebi/v2.0/items/" + id);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetDashboardToken());
                var result = client.DeleteAsync(new Uri(BoldURL + "/bi/api/site/acmebi/v2.0/items/" + id)).Result;

                return result.IsSuccessStatusCode;
            }
        }
    }
}
