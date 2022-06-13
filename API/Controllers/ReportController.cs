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
            var tkApi = "http://desktop-1mq5eqq:49987/reporting/api/site/acmerpt/get-user-key";
            var rptTokenHelper = new ReportTokenHelper();
            return rptTokenHelper.GenerateToken(userName, password, tkApi);

        }

        [HttpGet("GetReportItems")]
        public List<ApiItems> GetReportItems()
        {
            var token = GetRptToken();
            return ReportItemHelper.GetItems(token);
        }
    }
}
