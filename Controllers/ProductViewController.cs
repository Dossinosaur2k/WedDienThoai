using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demowed.Controllers
{
    public class ProductViewController : Controller
    {
        // GET: ProductView
        public ActionResult Index()
        {
            return View();
        }
    }
}