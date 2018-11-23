using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTree.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public long? Quantity { get; set; }
        public int? CategoryId { get; set; }
    }
}