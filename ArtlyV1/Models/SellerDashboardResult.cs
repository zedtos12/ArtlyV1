using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Models
{
    public class SellerDashboardResult
    {

    }
    
    public class SellerDashboardResult_RecentSales
    {
        public string Buyer { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string status { get; set; }
    }
    public class SellerDashboardResult_TransactionHistory
    {
        public string Buyer { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string status { get; set; }
    }
}