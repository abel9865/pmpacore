using System;
namespace API.Helpers.DashboardHelpers
{
    public class EmbedProperties
    {
        //BoldBI server URL (ex: http://localhost:5000/bi, http://dashboard.syncfusion.com/bi)
        public static string RootUrl = "http://desktop-1mq5eqq:49987/bi"; //"https://demo-chargebackgurus.boldbi.com/bi";

        //For Bold BI Enterprise edition, it should be like `site/site1`. For Bold BI Cloud, it should be empty string.
        public static string SiteIdentifier = "site/acmebi";

        //Enter your BoldBI credentials here.
        public static string UserEmail = "abel9865@gmail.com"; //"demo@boldbi.com";

        // Get the embedSecret key from Bold BI. Please check this link(https://help.syncfusion.com/bold-bi/on-premise/site-settings/embed-settings)
        public static string EmbedSecret = "9UmSya58tI2M7lMU4YDKNvbLoGVt3khO"; //"z2TKemsTTn3JOSEiFkM1G3Jp7LRhS247";
    }
}
