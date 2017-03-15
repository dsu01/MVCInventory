using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MVCInventory.Data;
using MVCInventory.Domain;

namespace MVCInventory.WebUI.WebAPIServices
{
    public class FacilityApiController : ApiBaseController
    {
       
        public FacilityApiController(IUtils utils) : base(utils)
        {
           
        }

        /// <summary>
        /// Get list of uploaded files.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/facilities")]
        public IHttpActionResult Get()
        {
            try
            {
                //var uploadFiles = this.UploadFileManager.Get();
                //var model = Mapper.Map<List<UploadedFileApiModel>>(uploadFiles);
                var model = new List<Facility>();
                using (var dbContext = new InventoryContext())
                {
                    model =  dbContext.Facilities.ToList();
                }
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}