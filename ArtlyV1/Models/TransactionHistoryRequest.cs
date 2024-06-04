using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Models
{
    public class TransactionHistoryRequest
    {
        public string IdUser { get; set; }
        public string Type { get; set; }
        public string Filter { get; set; }
    }
}