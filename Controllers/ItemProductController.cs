using BanHangOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHangOnline.Controllers
{
    public class ItemProductController : Controller
    {
        private WebBangHangDemoEntities db = new WebBangHangDemoEntities();
        // GET: ItemProduct
        public ActionResult Index(int?id)
        {
            var items = db.tb_Product.ToList();
            if (id!=null) {
                items = items.Where(x => x.ProductCategoryID == id).ToList();
            }
            return View(items);
        }
        public ActionResult Pratuial_ItemsProduct() {
            var items = db.tb_Product.Where(x=>x.IsActive).Take(10).ToList();
            return View(items);
        }
        public ActionResult Pratuial_ItemsProductBestSeller()
        {
            var items = db.tb_Product.Where(x => x.IsHome && x.IsActive).ToList();
            return View(items);
        }

    }
}