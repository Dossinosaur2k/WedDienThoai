using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;
using ModelEF.Model;
using PagedList;

namespace Demowed.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
      
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var user = new UserDao();
            var model = user.ListwhereAllsp(searchString, page, pagesize);
            ViewBag.searchString = searchString;

            return View(model);
        }
    
         public ActionResult Detail(int id)
        {
           var user = new UserDao();
           var model = user.Find(id);

        return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            setViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Sanpham model)
        {

            setViewBag();
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.Find(model.Masp) != null)
                {
                    SetAlert("Tên sản phẩm tồn tại, Mời nhập tên khác", "warning");
                    return RedirectToAction("Create", "Product");
                }
                int result = dao.Insertsp(model);
                if (result!=0)
                {
                    SetAlert("Tạo mới sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Product");
                }

                else
                {
                    SetAlert("Tạo mới sản phẩm không thành công", "error");
                    ModelState.AddModelError("", "Tạo sản phẩm thành công");
                }

            }
            return View();
        }
        public void setViewBag(long? selectedid=null)
        {
            var dao = new UserDao();
            ViewBag.MaHangID = new SelectList(dao.ListAllsp(),"Mahang","TenHang",selectedid);

        }
    }
}