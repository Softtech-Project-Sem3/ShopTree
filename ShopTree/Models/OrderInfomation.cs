using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTree.Models
{
    public class OrderInfomation
    {
        public string CustomerName { get; set; }
        public string OrderCode { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipperName { get; set; }
        public string ShipperEmail { get; set; }
        public string ShipperAddress { get; set; }
        public string ShipperPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string Status { get; set; }
        public decimal? Total { get; set; }

        public List<OrderDetail> ListOrderDetail { get; set; }
        


    }
}