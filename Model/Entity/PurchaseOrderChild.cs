//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseOrderChild
    {
        public long Id { get; set; }
        public long MasterOrderId { get; set; }
        public long ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
}
