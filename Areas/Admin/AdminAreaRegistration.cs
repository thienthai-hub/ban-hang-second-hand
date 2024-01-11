using System.Web.Mvc;

namespace BanHangOnline.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                //xử lý lỗi khi website không hiểu đang chạy trên trang Controller hay Controller.admin
                namespaces: new[] { "BanHangOnline.Areas.Admin.Controllers" }
            );
        }
    }
}