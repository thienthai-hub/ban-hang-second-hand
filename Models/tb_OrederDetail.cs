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
    
    public partial class tb_OrederDetail
    {
        public int Id { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Quantity { get; set; }
    
        public virtual tb_Order tb_Order { get; set; }
        public virtual tb_Product tb_Product { get; set; }
    }
}
