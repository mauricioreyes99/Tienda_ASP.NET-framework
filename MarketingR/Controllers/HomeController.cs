using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketingR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
        [HttpPost]
       public JsonResult Operacion(int valorCaja1, int valorCaja2)
        {
            try
            {
                var res = valorCaja1 + valorCaja2;
                return Json(res);
            }
            catch (Exception)
            {
                return Json(String.Format("ERROR"));
                throw;
            }
            
            
        }
    }
}