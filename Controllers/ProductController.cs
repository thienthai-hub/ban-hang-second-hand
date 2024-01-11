using BanHangOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHangOnline.Controllers
{
    public class ProductController : Controller
    {

        private WebBangHangDemoEntities db = new WebBangHangDemoEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryProduct(string alias, int id)
        {
            var items = db.tb_Product.ToList();
            if (id > 0)
            {
                items = items.Where(x => x.ProductCategoryID == id).ToList();
            }
            return View(items);
        }
    }
}