using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiCacheDemo.Mvc.Clients.Interfaces;

namespace WebApiCacheDemo.Mvc.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        private ISampleClient _sampleClient;

        public HomeController(ISampleClient sampleClient)
        {
            _sampleClient = sampleClient;
        }

        [HttpGet]
        [Route("")]
        [Route("Index")]
        public ActionResult Index()
        {
            var model = _sampleClient.GetSampleDateAndNumber();
            return View(model);
        }
    }
}