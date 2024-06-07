using ArtlyV1.Models;
using ArtlyV1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Handlers
{
    public class SellerTransactionHistoryHandler
    {
        ArtlyDatabaseEntities db = DatabaseSingleton.getInstance();

        public List<SellerDashboardResult_TransactionHistory> getSellerTransactionHistory(TransactionHistoryRequest param)
        {
            var result = db.TransactionDetails
                    .Where(x => x.MsProduct.UserInput == param.IdUser)
                    .OrderBy(x => x.MsTransaction.OrderDate)
                    .Select(x => new
                    {
                        Buyer = x.MsTransaction.MsUser.FullName,
                        ProductName = x.MsProduct.ProductName,
                        Price = x.Quantity * x.UnitPrice,
                        status = x.MsTransaction.LtStatu.StatusName,
                        Type = x.MsProduct.LtProductType,
                        LtStatus = x.MsTransaction.LtStatu
                    })
                    .Take(5)
                    .ToList();

            var typeName = param.Type == "1" ? "Digital" : "Non-Digital";   

            if (!String.IsNullOrEmpty(param.Type))
            {
                result = result.Where(x => x.Type.ProductTypeName == typeName).ToList();
            }
            if (!String.IsNullOrEmpty(param.Filter))
            {
                result = result.Where(x => x.LtStatus.StatusName == param.Filter).ToList();
            }

            var results = result.Select(x => new SellerDashboardResult_TransactionHistory
            {
                Buyer = x.Buyer,
                ProductName = x.ProductName,
                Price = x.Price,
                status = x.status
            }).ToList();

            foreach(var item in results)
            {
                if (item.status == "Complete")
                {
                    item.status = "<td class=\"border-0\"><label class=\"badge badge-success border-0\">Completed</label></td>";
                }
                else if (item.status == "On-Delivery")
                {
                    item.status = "<td class=\"border-0\"><label class=\"badge badge-warning border-0\">On Delivery</label></td>";
                }
                else if (item.status == "On-Process")
                {
                    item.status = "<td class=\"border-0\"><label class=\"badge badge-info border-0\">On Process</label></td>";
                }
            }

            return results;
        }
    }
}