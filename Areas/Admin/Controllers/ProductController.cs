using BanHangOnline.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHangOnline.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        private WebBangHangDemoEntities db = new WebBangHangDemoEntities();
        public ActionResult Index(int? page, string searchTerm)
        {
            var pageNumber = page ?? 1; // nếu không có số trang được cung cấp, mặc định là trang 1
            var pageSize = 10; // Số lượng mục trên mỗi trang

            var items = db.tb_Product
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
        //[HttpPost]
        //public ActionResult Add(tb_Product model, HttpPostedFileBase ImageFile)
        //{
        //    try
        //    {
        //        if (modelstate.isvalid)
        //        {
        //            if (imagefile != null && imagefile.contentlength > 0)
        //            {
        //                var filename = path.getfilename(imagefile.filename);
        //                var path = path.combine(server.mappath("/images/"), filename);
        //                imagefile.saveas(path);

        //                model.image = "/images/" + filename;
        //            }

        //            db.tb_product.add(model);
        //            db.savechanges();

        //            return redirecttoaction("index");
        //        }

        //        return view(model);
        //    }
        //    catch (exception e)
        //    {
        //        // xử lý ngoại lệ, bạn có thể ghi log lỗi ở đây
        //        return view("error");
        //    }
        //}

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(ImageFile.FileName);
                var filePath = Path.Combine(Server.MapPath("~/Images"), fileName);
                ImageFile.SaveAs(filePath);

                // Lưu tên file vào session
                List<string> images = Session["UploadedImages"] as List<string>;
                if (images == null)
                {
                    images = new List<string>();
                }
                images.Add(fileName);
                Session["UploadedImages"] = images;

                return Json(new { success = true, fileName = fileName });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(tb_Product model)
        {
            if (ModelState.IsValid)
            {
                List<string> images = Session["UploadedImages"] as List<string>;
                if (images != null && images.Any())
                {
                    // Nếu có hình ảnh, xử lý lưu trữ chúng
                    // Ví dụ: Lưu đường dẫn đầu tiên hoặc tạo một cấu trúc để lưu nhiều hình ảnh
                    model.Image = @"\Images\" + images.First();

                    // Xóa session sau khi sử dụng
                    Session["UploadedImages"] = null;
                }

                // Đặt thời gian hiện tại
                model.CreatedDate = DateTime.Now;
                model.ModifierDate = DateTime.Now;
                model.Alias = BanHangOnline.Models.Common.Filter.FilterChar(model.Title);

                db.tb_Product.Add(model);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }



        public ActionResult Edit(int id)
        {
            var model = db.tb_Product.Find(id);
            if (model == null)
            {
                // Xử lý trường hợp không tìm thấy đối tượng
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, tb_Product model, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                var existingCategory = db.tb_Product.Find(id);
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(imageFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    imageFile.SaveAs(path);

                    // Cập nhật đường dẫn hình ảnh
                    existingCategory.Image = @"\Images\" + fileName;
                }

                // Cập nhật các thuộc tính khác của existingCategory
                // ...
                existingCategory.Title = model.Title;
                existingCategory.Description = model.Description;
                existingCategory.ProductCategoryID = model.ProductCategoryID;
                existingCategory.Detail = model.Detail;
                existingCategory.Price = model.Price;
                existingCategory.PriceSale = model.PriceSale;
                existingCategory.SeoDescription = model.SeoDescription;
                existingCategory.SeoKey = model.SeoKey;
                existingCategory.Alias = BanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                existingCategory.SeoTitle = model.SeoTitle;
                existingCategory.CreatedBy = model.CreatedBy;
                existingCategory.CreatedDate = DateTime.Now;
                existingCategory.IsActive = model.IsActive;
                existingCategory.IsHome = model.IsHome;
                existingCategory.IsSale = model.IsSale;
                existingCategory.IsFeature = model.IsFeature;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        //Delete item
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = db.tb_Product.Find(id); // Giả sử db là đối tượng của DbContext
            if (model == null)
            {
                // Trả về thông báo lỗi nếu không tìm thấy đối tượng
                return Json(new { success = false, message = "Không tìm thấy đối tượng." });
            }

            db.tb_Product.Remove(model); // Xóa đối tượng khỏi cơ sở dữ liệu
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
                    var item = db.tb_Product.Find(id); // Thay thế YourEntity với tên thực thể của bạn
                    if (item != null)
                    {
                        db.tb_Product.Remove(item); // Xóa item từ database context
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