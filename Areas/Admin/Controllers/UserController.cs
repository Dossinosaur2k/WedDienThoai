using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Demowed.Areas.Admin.Models;
using ModelEF.DAO;
using ModelEF.Model;
using PagedList;

namespace Demowed.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        // public ActionResult Index()
        //{
        //   var user = new UserDao();
        // var model = user.ListAll();

        //return View(model);
        //}

        //public ActionResult Index(int page = 1, int pagesize = 5)
        //{
          //  var user = new UserDao();
          //  var model = user.ListAll();
         //   return View(model.ToPagedList(page,pagesize));
     //   }   
     [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var user = new UserDao();
            var model = user.ListwhereAll(searchString, page, pagesize);
            ViewBag.searchString = searchString;

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Dangnhap model)
        {
            
            
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.Find(model.users) != null)
                {
                    SetAlert("Tên người dùng tồn tại, Mời nhập tên khác", "warning");
                    return RedirectToAction("Create", "User");
                }
                string result = dao.Insert(model);
                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Tạo mới người dùng thành công", "success");
                    return RedirectToAction("Index", "User");
                }

                else
                {
                    SetAlert("Tạo mới người dùng không thành công", "error");
                    ModelState.AddModelError("", "Tạo Người dùng thành công");
                }

            }
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var dao = new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
    }

}