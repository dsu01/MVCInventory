using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCInventory.WebUI.WebAPIServices
{
    public abstract class ApiBaseController : ApiController
    {
        protected IUtils Utils;

        public ApiBaseController(IUtils utils)
        {
            this.Utils = utils;
        }
    }

    public interface IUtils
    {
        int GetCurrentUserId();
    }

    public class Utils : IUtils
    {
        public int GetCurrentUserId()
        {
            return  1;
        }
    }
}
