using PagedList;
using ShopTree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTree.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        private ShopTreeEntities db = new ShopTreeEntities();
        const int pageSize = 12;
        int pageIndex = 1;
        public ActionResult AllProduct(int? page)
        {
            ViewBag.Title = "Sản phẩm";
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<ProductViewModel> pagingProduct = null;
            var list = (from product in db.Products
                        join image in db.Images on product.Id equals image.ProductId
                        where product.Status == true
                        orderby product.Priority descending
                        select new ProductViewModel()
                        {
                            ProductId = product.Id,
                            ProductName = product.Name,
                            Price = product.Price,
                            ImageUrl = image.Url
                        }).ToList();
            pagingProduct = list.ToPagedList(pageIndex, pageSize);
            return View(pagingProduct);
        }

        public ActionResult Detail(int productId)
        {
            var productView = (from product in db.Products
                               join image in db.Images on product.Id equals image.ProductId
                               where product.Id == productId
                               select new ProductViewModel()
                               {
                                   ProductId = product.Id,
                                   ProductName = product.Name,
                                   Price = product.Price,
                                   ImageUrl = image.Url,
                                   Description = product.Description,
                                   CategoryName = product.Category.Name,
                                   CategoryId = product.CategoryId,
                                   Quantity = product.StockQuantity
                               }).FirstOrDefault();
            ViewBag.Title = productView.ProductName;
            return View(productView);
        }

        [HttpPost]
        public ActionResult Search(string keyword)
        {
            ViewBag.Title = "Kết quả";
            if (string.IsNullOrEmpty(keyword))
            {
                return RedirectToAction("AllProduct", "Products");
            }
            else
            {
                var productList = (from product in db.Products
                                   join image in db.Images on product.Id equals image.ProductId
                                   where product.Name.Contains(keyword)
                                   orderby product.Priority descending
                                   select new ProductViewModel()
                                   {
                                       ProductId = product.Id,
                                       ProductName = product.Name,
                                       Price = product.Price,
                                       ImageUrl = image.Url
                                   }).ToList();
                if (productList.Count > 0)
                {
                    //have a result
                    return View("SearchResult", productList);
                }
                else
                {
                    //no result match
                    ViewBag.Message = "There are no results!";
                    return View("SearchResult", null);
                }
            }
        }

        public ActionResult GetProductByCategoryId(int categoryId)
        {
            ViewBag.Title = db.Categories.Find(categoryId).Name;
            var productList = (from product in db.Products
                               join image in db.Images on product.Id equals image.ProductId
                               where product.CategoryId == categoryId
                               orderby product.Priority descending
                               select new ProductViewModel()
                               {
                                   ProductId = product.Id,
                                   ProductName = product.Name,
                                   Price = product.Price,
                                   ImageUrl = image.Url,
                                   CategoryName = product.Category.Name
                               }).ToList();
            return View("ListProductByCategoryId", productList);
        }

        public ActionResult _RelationProduct(int categoryId, int productId)
        {
            var relationProduct = (from product in db.Products
                                   join image in db.Images on product.Id equals image.ProductId
                                   where product.CategoryId == categoryId && product.Id != productId
                                   orderby product.Priority descending
                                   select new ProductViewModel()
                                   {
                                       ProductId = product.Id,
                                       ProductName = product.Name,
                                       Price = product.Price,
                                       ImageUrl = image.Url
                                   }).Take(12).ToList();
            return PartialView("_RelationProduct", relationProduct);
        }

        public ActionResult _ProductList(int categoryId)
        {
            var list = (from product in db.Products
                        join image in db.Images on product.Id equals image.ProductId
                        where product.CategoryId == categoryId && product.Status == true
                        orderby product.Priority
                        select new ProductViewModel()
                        {
                            ProductId = product.Id,
                            ProductName = product.Name,
                            Price = product.Price,
                            ImageUrl = image.Url
                        }).ToList();

            ViewBag.ProductList = list;
            return PartialView("_ProductList", list);
        }
    }
}