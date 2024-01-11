using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHangOnline.Models.Common
{
    public class TbNewMetadata
    {
        [Required(ErrorMessage = "Title không được bỏ trống")]
        public string Title { get; set; }
        [AllowHtml]
        public string Detail { get; set; }

        // Thuộc tính trợ giúp

    }

    // using BanHangOnline.Models.Common;
    //using System.ComponentModel.DataAnnotations;

    //[MetadataType(typeof(TbNewMetadata))]
}