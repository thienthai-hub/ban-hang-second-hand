using BanHangOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHangOnline.Controllers
{
    public class MenuController : Controller
    {
        private WebBangHangDemoEntities db = new WebBangHangDemoEntities();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuTop()
        {
            var items = db.tb_Category.OrderBy(x => x.Position).ToList();
            return PartialView("MenuTop",items);
        }
        public ActionResult MenuProductCategory()
        {
            var items = db.tb_ProductCategory.ToList();
            return PartialView("MenuProductCategory", items);
        }
        public ActionResult MenuLeft()
        {
            var items = db.tb_ProductCategory.ToList();
            return PartialView("MenuLeft", items);
        }
            public ActionResult MenuArrivals()
        {
            var items = db.tb_ProductCategory.ToList();
            return PartialView("MenuArrivals", items);
        }
    }
}