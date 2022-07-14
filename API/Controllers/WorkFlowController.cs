using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API.Helpers.WorkFlowHelpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
	public class WorkFlowController : BaseApiController
	{
        private static readonly string wfURL = "https://localhost:15265";


        [HttpGet("GetWorkFlows/{tenantId}")]
        public async Task<List<WorkFlowItem>> GetWorkFlowsAsync(string tenantId)
        {
            WorkFlowItems workFlows = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(wfURL + "/v1/workflow-definitions");
                client.DefaultRequestHeaders.Accept.Clear();
                var result = client.GetAsync(new Uri(wfURL + "/v1/workflow-definitions")).Result;
                 workFlows = JsonConvert.DeserializeObject<WorkFlowItems>(await result.Content.ReadAsStringAsync());
            }

            var wfByTenant=  workFlows.items.Where(x=>x.tenantId==tenantId).ToList();
            //workFlows = new WorkFlowItems{ items = wfByTenant, totalCount=workFlows.totalCount};
            return wfByTenant;
        }


        [HttpPost("DeleteWorkFlow/{id}")]
        public bool DeleteWorkFlow(string id)
        {
           


            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(wfURL + "/v1/workflow-definitions" + id);
                client.DefaultRequestHeaders.Accept.Clear();
                
                var result = client.DeleteAsync(new Uri(wfURL + "/v1/workflow-definitions/" + id)).Result;

                return result.IsSuccessStatusCode;
            }
        }
    }
}

