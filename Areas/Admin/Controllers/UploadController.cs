using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHangOnline.Areas.Admin.Controllers
{
    public class UploadController : Controller
    {
        // GET: Admin/Upload
        [HttpPost]
        public ActionResult UploadImage()
        {
            try
            {
                HttpPostedFileBase file = Request.Files["imageFile"];
                if (file != null && file.ContentLength > 0)
                {
                    // Đặt tên cho file và lưu trữ file
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Upload/image"), fileName);
                    file.SaveAs(path);

                    // Trả về tên file hoặc đường dẫn để sử dụng ở client
                    return Json(new { success = true, fileName = fileName }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { success = false, message = "Không có file được chọn." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}