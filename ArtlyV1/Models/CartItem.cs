using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Models
{
    public class CartItem
    {
        private MsProduct product { get; set; }
        private int qty { get; set; }

        public CartItem(MsProduct product, int qty)
        {
            this.product = product;
            this.qty = qty;
        }
    }
}