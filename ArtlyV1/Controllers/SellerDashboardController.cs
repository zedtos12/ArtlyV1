using ArtlyV1.Handlers;
using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Controllers
{
    public class SellerDashboardController
    {
        SellerDashboardHandler SellerDashboardHandler = new SellerDashboardHandler();
        SellerTransactionHistoryHandler SellerTransactionHistoryHandler = new SellerTransactionHistoryHandler();

        public int getSellerSales(string sellerId)
        {
            return SellerDashboardHandler.getSellerSales(sellerId);
        }

        public decimal getSellerRevenue(string sellerId)
        {
            return SellerDashboardHandler.getSellerRevenue(sellerId);
        }
        public int getSellerProducts(string sellerId)
        {
            return SellerDashboardHandler.getSellerProducts(sellerId);
        }
        public int getSellerSalesToday(string sellerId)
        {
            return SellerDashboardHandler.getSellerSalesToday(sellerId);
        }
        public decimal getSellerRevenueToday(string sellerId)
        {
            return SellerDashboardHandler.getSellerRevenueToday(sellerId);
        }
        public int getSellerProductsToday(string sellerId)
        {
            return SellerDashboardHandler.getSellerProductsToday(sellerId);
        }
        public List<SellerDashboardResult_RecentSales> sellerDashboardResult_RecentSales(string sellerId)
        {
            return SellerDashboardHandler.GetRecentSales(sellerId);
        }

        public List<SellerDashboardResult_TransactionHistory> GetTransactionHistories(TransactionHistoryRequest param)
        {
            return SellerTransactionHistoryHandler.getSellerTransactionHistory(param);
        }
    }
}