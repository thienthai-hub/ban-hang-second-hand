//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BanHangOnline.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_New
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKey { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifierDate { get; set; }
        public string ModifierBy { get; set; }
        public string Alias { get; set; }
        public bool IsActive { get; set; }
    
        public virtual tb_Category tb_Category { get; set; }
    }
}
