using System;
using System.Collections.Generic;
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
    }
}
