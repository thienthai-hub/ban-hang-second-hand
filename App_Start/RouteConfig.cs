using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BanHangOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "product",
                url: "san-pham",
                defaults: new { controller = "ItemProduct", action = "index", id = UrlParameter.Optional },
                //xử lý lỗi khi website không hiểu đang chạy trên trang controller hay controller.admin
                namespaces: new[] { "BanHangOnline.Controllers" }
            );

            routes.MapRoute(
            name: "CategoryProduct",
            url: "danh-muc-sam-pham/{alias}-{id}",
            defaults: new { controller = "Product", action = "CategoryProduct", id = UrlParameter.Optional },
            namespaces: new[] { "BanHangOnline.Controllers" }
            );

            routes.MapRoute(
               name: "Contact",
               url: "lien-he",
               defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
               //xử lý lỗi khi website không hiểu đang chạy trên trang Controller hay Controller.admin
               namespaces: new[] { "BanHangOnline.Controllers" }
           );
            routes.MapRoute(
              name: "Giới Thiệu",
              url: "gioi-thieu",
              defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
              //xử lý lỗi khi website không hiểu đang chạy trên trang Controller hay Controller.admin
              namespaces: new[] { "BanHangOnline.Controllers" }
          );
            routes.MapRoute(
               name: "Trang Chủ",
               url: "trang-chu",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               //xử lý lỗi khi website không hiểu đang chạy trên trang Controller hay Controller.admin
               namespaces: new[] { "BanHangOnline.Controllers" }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                //xử lý lỗi khi website không hiểu đang chạy trên trang Controller hay Controller.admin
                namespaces: new[] { "BanHangOnline.Controllers" }
            );
        }
    }
}
