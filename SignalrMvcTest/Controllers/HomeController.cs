using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Script.Serialization;

namespace SignalrMvcTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Fire()
        {
            DummyClass dummy = new DummyClass()
            {
                Id = 12312,
                Description = String.Format("Esto fue disparado a las {0}",DateTime.Now.ToString()),
                Name = "Algo super importante!",
                Url = "http://balusoft.wordpress.com"                
            };

            // Serializamos el objeto
            string json = new JavaScriptSerializer().Serialize(dummy);

            var hub = Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<SignalClass>();
            hub.Clients.All.onNewItem(json);


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}