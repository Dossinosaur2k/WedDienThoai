using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;

namespace Demowed.Controllers
{
    public class HomeViewController : Controller
    {
        // GET: HomeView
        public ActionResult Index(string searchString, int page = 1, int pagesize = 6)
        {
            var user = new UserDao();
            var model = user.ListwhereAllsp(searchString, page, pagesize);
            ViewBag.searchString = searchString;

            return View(model);
        }
    }
}