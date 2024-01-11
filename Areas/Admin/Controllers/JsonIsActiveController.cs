using BanHangOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHangOnline.Areas.Admin.Controllers
{
    public class JsonIsActiveController : Controller
    {
        // GET: Admin/JsonIsActive
        private WebBangHangDemoEntities db = new WebBangHangDemoEntities();
        [HttpPost]
        public JsonResult ToggleIsActiveNew(int id, bool? isActive)
        {
            var model = db.tb_New.Find(id);
            if (model == null)
            {
                return Json(new { success = false, message = "Đối tượng không tìm thấy" });
            }

            model.IsActive = !model.IsActive; // Đảo ngược trạng thái IsActive
            db.SaveChanges();

            return Json(new { success = true, isActive = model.IsActive });
        }
        [HttpPost]
        public JsonResult ToggleIsActiveCategory(int id, bool? isActive)
        {
            var model = db.tb_Category.Find(id);
            if (model == null)
            {
                return Json(new { success = false, message = "Đối tượng không tìm thấy" });
            }

            model.IsActive = !model.IsActive; // Đảo ngược trạng thái IsActive
            db.SaveChanges();

            return Json(new { success = true, isActive = model.IsActive });
        }
        [HttpPost]
        public JsonResult ToggleIsActivePost(int id, bool? isActive)
        {
            var model = db.tb_Post.Find(id);
            if (model == null)
            {
                return Json(new { success = false, message = "Đối tượng không tìm thấy" });
            }

            model.IsActive = !model.IsActive; // Đảo ngược trạng thái IsActive
            db.SaveChanges();

            return Json(new { success = true, isActive = model.IsActive });
        }
        [HttpPost]
        public JsonResult ToggleIsActiveProduct(int id, bool? isActive)
        {
            var model = db.tb_Product.Find(id);
            if (model == null)
            {
                return Json(new { success = false, message = "Đối tượng không tìm thấy" });
            }

            model.IsActive = !model.IsActive; // Đảo ngược trạng thái IsActive
            db.SaveChanges();

            return Json(new { success = true, isActive = model.IsActive });
        }

        //IsSale
        [HttpPost]
        public JsonResult ToggleIsSaleProduct(int id)
        {
            var model = db.tb_Product.Find(id);
            if (model == null)
            {
                return Json(new { success = false, message = "Đối tượng không tìm thấy" });
            }

            model.IsSale = !model.IsSale; // Đảo ngược trạng thái IsSale
            db.SaveChanges();

            return Json(new { success = true, isSale = model.IsSale });
        }


        //IsHome
        [HttpPost]
        public JsonResult ToggleIsHomeProduct(int id)
        {
            var model = db.tb_Product.Find(id);
            if (model == null)
            {
                return Json(new { success = false, message = "Đối tượng không tìm thấy" });
            }

            model.IsHome = !model.IsHome; // Đảo ngược trạng thái IsHome
            db.SaveChanges();

            return Json(new { success = true, isHome = model.IsHome });
        }

        [HttpPost]
        public JsonResult ToggleIsFeatureProduct(int id)
        {
            var model = db.tb_Product.Find(id);
            if (model == null)
            {
                return Json(new { success = false, message = "Đối tượng không tìm thấy" });
            }

            model.IsFeature = !model.IsFeature; // Đảo ngược trạng thái IsFeature
            db.SaveChanges();

            return Json(new { success = true, isFeature = model.IsFeature });
        }

    }
}