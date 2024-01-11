using BanHangOnline.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHangOnline.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        // GET: Admin/News
        private WebBangHangDemoEntities db = new WebBangHangDemoEntities();

        public ActionResult Index(int? page, string searchTerm)
        {
            var pageNumber = page ?? 1; // nếu không có số trang được cung cấp, mặc định là trang 1
            var pageSize = 3; // Số lượng mục trên mỗi trang

            var items = db.tb_New
                          .Where(p => searchTerm == null || p.Title.Contains(searchTerm))
                          .OrderByDescending(n => n.Id)
                          .ToList();

            var pagedItems = items.ToPagedList(pageNumber, pageSize);

            return View(pagedItems);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(tb_New model)
        {
            if (ModelState.IsValid) // Kiểm tra dữ liệu có hợp lệ
            {
                // Bạn có thể thêm bất kỳ logic xử lý nào tại đây,
                // ví dụ như đặt giá trị cho thuộc tính CreatedDay
                model.CreatedDate = DateTime.Now;
                model.ModifierDate = DateTime.Now;
                model.Alias = BanHangOnline.Models.Common.Filter.FilterChar(model.Title);

                db.tb_New.Add(model); // Thêm đối tượng mới vào cơ sở dữ liệu
                db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                return RedirectToAction("Index"); // Chuyển hướng đến trang Index
            }

            return View(model); // Nếu dữ liệu không hợp lệ, hiển thị lại form với dữ liệu đã nhập
        }
        // Phương thức hiển thị form cập nhật với dữ liệu hiện tại của đối tượng
        public ActionResult Edit(int id)
        {
            var model = db.tb_New.Find(id);
            if (model == null)
            {
                // Xử lý trường hợp không tìm thấy đối tượng
                return HttpNotFound();
            }
            return View(model);
        }

        // Phương thức xử lý dữ liệu POST từ form cập nhật
        [HttpPost]
        public ActionResult Edit(int id, tb_New model)
        {
            if (ModelState.IsValid) // Kiểm tra dữ liệu có hợp lệ
            {
                var existingCategory = db.tb_New.Find(id);
                if (existingCategory == null)
                {
                    // Xử lý trường hợp không tìm thấy đối tượng
                    return HttpNotFound();
                }

                // Cập nhật các thuộc tính của existingCategory bằng dữ liệu từ model
                existingCategory.Title = model.Title;
                existingCategory.Description = model.Description;
                existingCategory.Detail = model.Detail;
                existingCategory.CategoryID = model.CategoryID;
                existingCategory.Image = model.Image;
                existingCategory.SeoDescription = model.SeoDescription;
                existingCategory.SeoKey = model.SeoKey;
                existingCategory.Alias = BanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                existingCategory.SeoTitle = model.SeoTitle;
                existingCategory.CreatedBy = model.CreatedBy;
                existingCategory.CreatedDate = model.CreatedDate;
                existingCategory.IsActive = model.IsActive;
                // Tiếp tục cập nhật các thuộc tính khác như cần thiết

                db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                return RedirectToAction("Index"); // Chuyển hướng đến trang Index
            }

            return View(model); // Nếu dữ liệu không hợp lệ, hiển thị lại form với dữ liệu đã nhập
        }

        //Delete item
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = db.tb_New.Find(id); // Giả sử db là đối tượng của DbContext
            if (model == null)
            {
                // Trả về thông báo lỗi nếu không tìm thấy đối tượng
                return Json(new { success = false, message = "Không tìm thấy đối tượng." });
            }

            db.tb_New.Remove(model); // Xóa đối tượng khỏi cơ sở dữ liệu
            db.SaveChanges(); // Lưu các thay đổi

            // Trả về phản hồi thành công
            return Json(new { success = true, message = "Xóa thành công." });
        }

        //Delete All items

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
                    var item = db.tb_New.Find(id); // Thay thế YourEntity với tên thực thể của bạn
                    if (item != null)
                    {
                        db.tb_New.Remove(item); // Xóa item từ database context
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