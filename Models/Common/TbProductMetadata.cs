using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHangOnline.Models.Common
{
    public class TbProductMetadata
    {
        public List<string> Image { get; set; } = new List<string>(); // Danh sách chứa các đường dẫn hình ảnh
    }

    // using BanHangOnline.Models.Common;
    //using System.ComponentModel.DataAnnotations;

    //[MetadataType(typeof(TbProductMetadata))]
}