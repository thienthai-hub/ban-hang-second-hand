using BanHangOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHangOnline.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        private WebBangHangDemoEntities db = new WebBangHangDemoEntities();
        public ActionResult Index()
        {
            var items = db.tb_Category.ToList();
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(tb_Category model)
        {
            if (ModelState.IsValid) // Kiểm tra dữ liệu có hợp lệ
            {
                // Bạn có thể thêm bất kỳ logic xử lý nào tại đây,
                // ví dụ như đặt giá trị cho thuộc tính CreatedDay
                model.CreatedDate = DateTime.Now;
                model.ModifierDate = DateTime.Now;
                model.Alias = BanHangOnline.Models.Common.Filter.FilterChar(model.Title);

                db.tb_Category.Add(model); // Thêm đối tượng mới vào cơ sở dữ liệu
                db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                return RedirectToAction("Index"); // Chuyển hướng đến trang Index
            }

            return View(model); // Nếu dữ liệu không hợp lệ, hiển thị lại form với dữ liệu đã nhập
        }
        // Phương thức hiển thị form cập nhật với dữ liệu hiện tại của đối tượng
        public ActionResult Edit(int id)
        {
            var model = db.tb_Category.Find(id);
            if (model == null)
            {
                // Xử lý trường hợp không tìm thấy đối tượng
                return HttpNotFound();
            }
            return View(model);
        }

        // Phương thức xử lý dữ liệu POST từ form cập nhật
        [HttpPost]
        public ActionResult Edit(int id, tb_Category model)
        {
            if (ModelState.IsValid) // Kiểm tra dữ liệu có hợp lệ
            {
                var existingCategory = db.tb_Category.Find(id);
                if (existingCategory == null)
                {
                    // Xử lý trường hợp không tìm thấy đối tượng
                    return HttpNotFound();
                }

                // Cập nhật các thuộc tính của existingCategory bằng dữ liệu từ model
                existingCategory.Title = model.Title;
                existingCategory.Description = model.Description;
                existingCategory.Position = model.Position;
                existingCategory.SeoDescription = model.SeoDescription;
                existingCategory.SeoKey = model.SeoKey;
                existingCategory.Alias = BanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                existingCategory.SeoTitle = model.SeoTitle;
                existingCategory.IsActive = model.IsActive;
                existingCategory.CreatedBy = model.CreatedBy;
                existingCategory.ModifierDate = DateTime.Now;
                // Tiếp tục cập nhật các thuộc tính khác như cần thiết

                db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                return RedirectToAction("Index"); // Chuyển hướng đến trang Index
            }

            return View(model); // Nếu dữ liệu không hợp lệ, hiển thị lại form với dữ liệu đã nhập
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = db.tb_Category.Find(id); // Giả sử db là đối tượng của DbContext
            if (model == null)
            {
                // Trả về thông báo lỗi nếu không tìm thấy đối tượng
                return Json(new { success = false, message = "Không tìm thấy đối tượng." });
            }

            db.tb_Category.Remove(model); // Xóa đối tượng khỏi cơ sở dữ liệu
            db.SaveChanges(); // Lưu các thay đổi

            // Trả về phản hồi thành công
            return Json(new { success = true, message = "Xóa thành công." });
        }

        [HttpPost]
        public ActionResult DeleteSelectedItems(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return Json(new { success = false, message = "Không có mục nào được chọn." });
            }

            try
            {
                foreach (var id in ids)
                {
                    var item = db.tb_Category.Find(id); // Thay thế YourEntity với tên thực thể của bạn
                    if (item != null)
                    {
                        db.tb_Category.Remove(item); // Xóa item từ database context
                    }
                }
                db.SaveChanges(); // Lưu thay đổi vào database

                return Json(new { success = true, message = "Xóa thành công." });
            }
            catch (Exception ex)
            {
                // Xử lý lỗi.
                return Json(new { success = false, message = "Lỗi trong quá trình xóa: " + ex.Message });
            }
        }

    }
}