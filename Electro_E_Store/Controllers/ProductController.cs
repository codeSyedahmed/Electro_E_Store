using Electro_E_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Electro_E_Store.Controllers
{
    public class ProductController : Controller
    {
        DB_ShopEntities db = new DB_ShopEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProduct()
        {
            return View();
        }
    }
}