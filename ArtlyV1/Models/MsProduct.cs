//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArtlyV1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MsProduct
    {
        public string IdProduct { get; set; }
        public string ProductName { get; set; }
        public string IdProductCategory { get; set; }
        public string IdProductType { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual LtProductCategory LtProductCategory { get; set; }
        public virtual LtProductType LtProductType { get; set; }
    }
}
