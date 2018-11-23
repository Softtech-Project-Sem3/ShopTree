using ShopTree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTree.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private ShopTreeEntities db = new ShopTreeEntities();
        public ActionResult Index()
        {
            ViewBag.Title = "Fairy Garden";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "Về chúng tôi";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Liên hệ";

            return View();
        }

        public ActionResult PaymentGuide()
        {
            ViewBag.Title = "Hướng dẫn thanh toán";
            return View();
        }

        public ActionResult ShoppingGuide()
        {
            ViewBag.Title = "Hướng dẫn mua hàng";
            return View();
        }

        public ActionResult TraddingAccount()
        {
            ViewBag.Title = "Tài khoản giao dịch";
            return View();
        }

        public ActionResult Return()
        {
            ViewBag.Title = "Giao hàng - Đổi trả";
            return View();
        }

        public ActionResult Security()
        {
            ViewBag.Title = "Chính sách bảo mật";
            return View();
        }

        public ActionResult _Categories()
        {
            var categories = db.Categories.ToList();
            return PartialView("_Categories", categories);
        }

        public ActionResult _BlogFooter()
        {
            var blogs = db.Blogs.OrderByDescending(x => x.Hot).Take(6).ToList();
            return PartialView("_BlogFooter", blogs);
        }

        public ActionResult _BlogSideBar()
        {
            var blogs = db.Blogs.Take(5).ToList();
            return PartialView("_BlogSideBar", blogs);
        }

        public ActionResult _CategoriesRight()
        {
            var list = db.Categories.ToList();
            return PartialView("_CategoriesRight", list);
        }
    }
}