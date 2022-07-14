using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ReportController : BaseApiController
    {
      [HttpGet("GetReportToken")]
      public string GetRptToken()
        {
            var userName = UserAccessor.GetUsername();
            var password = "Sw33tt34!";
            //var tkApi = "http://desktop-1mq5eqq:49987/reporting/api/site/acmerpt/get-user-key";
            var rptTokenHelper = new ReportTokenHelper();
            var tkUrl = "http://desktop-1mq5eqq:49987/reporting/api/site/acmerpt/token";
            return rptTokenHelper.GenerateToken(tkUrl, userName, password);

        }

        [HttpGet("GetReportItems")]
        public List<ApiItems> GetReportItems()
        {
            var token = GetRptToken();
            return ReportItemHelper.GetItems(token);
        }

        [HttpPost("DeleteReport/{id}")]
        public bool DeleteReport(string id)
        {
            var BoldURL = "http://desktop-1mq5eqq:49987";


            using (var client = new HttpClient())
           {
              
                client.BaseAddress = new Uri(BoldURL + "/reporting/api/site/acmerpt/v1.0/items/" + id);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetRptToken());
                var result =  client.DeleteAsync(new Uri(BoldURL + "/reporting/api/site/acmerpt/v1.0/items/" + id)).Result;
                //client.GetAsync(embedClass.dashboardServerApiUrl + embedDetailsUrl).Result;

                //string resultContent = result.Content.ReadAsStringAsync().Result;
                return result.IsSuccessStatusCode;
            }
        }

    }
}
