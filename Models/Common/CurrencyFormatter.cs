using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace BanHangOnline.Models.Common
{
    public class CurrencyFormatter
    {
        public static string FormatToVND(decimal amount)
        {
            CultureInfo vietnameseCulture = new CultureInfo("vi-VN");
            return string.Format(vietnameseCulture, "{0:C0}", amount) + " VND";
        }
    }
}