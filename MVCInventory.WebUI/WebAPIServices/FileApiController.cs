using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using MVCInventory.Data;

namespace MVCInventory.WebUI.WebAPIServices
{
    public class FileApiController : ApiBaseController
    {
        private readonly string UploadFolder;

        public FileApiController(IUtils utils) : base(utils)
        {
            this.UploadFolder = HostingEnvironment.MapPath("~/App_Data/Uploads");
        }

        ///// <summary>
        ///// Get list of uploaded files.
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("api/files")]
        //public IHttpActionResult Get()
        //{
        //    try
        //    {
        //        //var uploadFiles = this.UploadFileManager.Get();
        //        //var model = Mapper.Map<List<UploadedFileApiModel>>(uploadFiles);
        //        var model = ;
        //        using (var dbContext = new InventoryContext())
        //        {
        //            return dbContext.Buildings.ToList();
        //        }
        //        return Ok(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError();
        //    }
        //}
    }
}
