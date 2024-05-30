using ArtlyV1.Models;
using ArtlyV1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Handlers
{
    public class SellerDashboardHandler
    {
        ArtlyDatabaseEntities db = DatabaseSingleton.getInstance();

        public int getSellerSales(string sellerId)
        {
            var sales = db.TransactionDetails
                    .Where(x => x.MsProduct.UserInput == sellerId)
                    .ToList();

            return sales.Count();
        }

        public decimal getSellerRevenue(string sellerId)
        {
            var sales = db.TransactionDetails
                    .Where(x => x.MsProduct.UserInput == sellerId)
                    .Select(x => new
                    {
                        Profit = x.UnitPrice * x.Quantity,
                    })
                    .ToList();

            decimal revenue = 0;
            foreach (var sale in sales)
            {
                revenue += sale.Profit;
            }

            return revenue;
        }

        public int getSellerProducts(string sellerId)
        {
            var products = db.MsProducts
                    .Where(x => x.UserInput == sellerId)
                    .ToList();

            return products.Count();
        }

        public int getSellerSalesToday(string sellerId)
        {
            var sales = db.TransactionDetails
                    .AsEnumerable()
                    .Where(x => x.MsProduct.UserInput == sellerId && x.MsTransaction.OrderDate.Date == DateTime.Today)
                    .ToList();

            return sales.Count();
        }

        public decimal getSellerRevenueToday(string sellerId)
        {
            var sales = db.TransactionDetails
                    .AsEnumerable()
                    .Where(x => x.MsProduct.UserInput == sellerId && x.MsTransaction.OrderDate.Date == DateTime.Today)
                    .Select(x => new
                    {
                        Profit = x.UnitPrice * x.Quantity,
                    })
                    .ToList();

            decimal revenue = 0;
            foreach (var sale in sales)
            {
                revenue += sale.Profit;
            }

            return revenue;
        }

        public int getSellerProductsToday(string sellerId)
        {
            var products = db.MsProducts
                    .AsEnumerable()
                    .Where(x => x.UserInput == sellerId && x.DateCreated.Date == DateTime.Today)
                    .ToList();

            return products.Count();
        }

        public List<SellerDashboardResult_RecentSales> GetRecentSales(string sellerId)
        {
            var result = db.TransactionDetails
                    .Where(x => x.MsProduct.UserInput == sellerId)
                    .OrderBy(x => x.MsTransaction.OrderDate)
                    .Select(x => new SellerDashboardResult_RecentSales
                    {
                        Buyer = x.MsTransaction.MsUser.FullName,
                        ProductName = x.MsProduct.ProductName,
                        Price = x.Quantity * x.UnitPrice,
                        status = x.MsTransaction.LtStatu.StatusName
                    })
                    .Take(5)    
                    .ToList();

            return result;
        }

    }
}