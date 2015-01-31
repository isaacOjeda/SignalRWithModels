using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;

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
            

            var hub = GlobalHost.ConnectionManager.GetHubContext<SignalClass>();
            hub.Clients.All.onNewItem(dummy);

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