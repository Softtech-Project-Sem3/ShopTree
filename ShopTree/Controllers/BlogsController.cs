using ShopTree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTree.Controllers
{
    public class BlogsController : Controller
    {
        // GET: Blogs
        private ShopTreeEntities db = new ShopTreeEntities();
        public ActionResult Index()
        {
            ViewBag.Title = "Blogs";
            var blogs = db.Blogs.ToList();
            return View("AllBlog", blogs);
        }

        public ActionResult Detail(int blogId)
        {
            var blog = db.Blogs.Find(blogId);
            ViewBag.Title = blog.Title;
            return View(blog);
        }
    }
}