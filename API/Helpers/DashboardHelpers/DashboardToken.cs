using System;
using Application.Interfaces;

namespace API.Helpers.DashboardHelpers
{
	public class DashboardToken
	{
		public static string GetDashboardToken(IUserAccessor UserAccessor)
        {
            var userName = UserAccessor.GetUsername();
            userName = "abel9865@gmail.com";
            var password = "Sw33tt34!";
            //var tkApi = "http://desktop-1mq5eqq:49987/reporting/api/site/acmerpt/get-user-key";
            var tkUrl = "http://desktop-1mq5eqq:49987/bi/api/site/acmebi/token";
            var rptTokenHelper = new ReportTokenHelper();
            return rptTokenHelper.GenerateToken(tkUrl, userName, password);

        }
    }
}

