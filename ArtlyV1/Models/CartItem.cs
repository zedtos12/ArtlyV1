using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Models
{
    public class CartItem
    {
        public MsProduct product { get; set; }
        public String sellerName { get; set; }
        public int qty { get; set; }

        public CartItem(MsProduct product, String sellerName, int qty)
        {
            this.product = product;
            this.sellerName = sellerName;
            this.qty = qty;
        }
    }
}