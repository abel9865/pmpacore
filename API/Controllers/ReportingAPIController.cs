using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BoldReports.Web.ReportViewer;
using BoldReports.Web.ReportDesigner;

namespace API.Controllers
{
   
   //[Microsoft.AspNetCore.Cors.EnableCors("AllowAllOrigins")]
        [AllowAnonymous]
[ApiExplorerSettings(IgnoreApi = true)]
[Route("[controller]/[action]")]
    public class ReportingAPIController :  BaseApiController, BoldReports.Web.ReportDesigner.IReportDesignerController
    {
       
        private Microsoft.Extensions.Caching.Memory.IMemoryCache _cache;
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment _hostingEnvironment;

        public ReportingAPIController(Microsoft.Extensions.Caching.Memory.IMemoryCache memoryCache, Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment)
        {
              _cache = memoryCache;
        _hostingEnvironment = hostingEnvironment;
           
        }

       

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }


 [NonAction]
    private string GetFilePath(string itemName, string key)
    {
        string dirPath =  System.IO.Path.Combine(this._hostingEnvironment.WebRootPath + "\\" + "Cache", key);

        if (!System.IO.Directory.Exists(dirPath))
        {
            System.IO.Directory.CreateDirectory(dirPath);
        }

        return  System.IO.Path.Combine(dirPath, itemName);
    }

    public object GetImage(string key, string image)
    {
        return ReportDesignerHelper.GetImage(key, image, this);
    }

    public object GetResource(ReportResource resource)
    {
        return ReportHelper.GetResource(resource, this, _cache);
    }

    [NonAction]
    public void OnInitReportOptions(ReportViewerOptions reportOption)
    {

    }

    [NonAction]
    public void OnReportLoaded(ReportViewerOptions reportOption)
    {

    }

    [HttpPost]
    public object PostDesignerAction([FromBody] Dictionary<string, object> jsonResult)
    {
        return ReportDesignerHelper.ProcessDesigner(jsonResult, this, null, this._cache);
    }

    public object PostFormDesignerAction()
    {
        return ReportDesignerHelper.ProcessDesigner(null, this, null, this._cache);
    }

    public object PostFormReportAction()
    {
        return ReportHelper.ProcessReport(null, this, this._cache);
    }

    [HttpPost]
    public object PostReportAction([FromBody] Dictionary<string, object> jsonResult)
    {
        return ReportHelper.ProcessReport(jsonResult, this, this._cache);
    }

    [NonAction]
    public bool SetData(string key, string itemId, ItemInfo itemData, out string errorMessage)
    {
        errorMessage = string.Empty;

        if (itemData.Data != null)
        {
            System.IO.File.WriteAllBytes(this.GetFilePath(itemId, key), itemData.Data);
        }
        else if (itemData.PostedFile != null)
        {
            var fileName = itemId;
            if (string.IsNullOrEmpty(itemId))
            {
                fileName = System.IO.Path.GetFileName(itemData.PostedFile.FileName);
            }

            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                itemData.PostedFile.OpenReadStream().CopyTo(stream);
                byte[] bytes = stream.ToArray();
                var writePath = this.GetFilePath(fileName, key);

                System.IO.File.WriteAllBytes(writePath, bytes);
                stream.Close();
                stream.Dispose();
            }
        }
        return true;
    }

    [NonAction]
    public ResourceInfo GetData(string key, string itemId)
    {
        var resource = new ResourceInfo();
        try
        {
            var filePath = this.GetFilePath(itemId, key);
            if (itemId.Equals( System.IO.Path.GetFileName(filePath), StringComparison.InvariantCultureIgnoreCase) &&  System.IO.File.Exists(filePath))
            {
                resource.Data =  System.IO.File.ReadAllBytes(filePath);
            }
            else
            {
                resource.ErrorMessage = "File not found from the specified path";
            }
        }
        catch (Exception ex)
        {
            resource.ErrorMessage = ex.Message;
        }

        return resource;
    }

    [HttpPost]
    public void UploadReportAction()
    {
        ReportDesignerHelper.ProcessDesigner(null, this, this.Request.Form.Files[0], this._cache);
    }





    }
}