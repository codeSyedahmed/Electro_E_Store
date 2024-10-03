using Electro_E_Store.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpGet]
        public ActionResult AddProduct()
        {
            if (Session["admin_id"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.Categories = new SelectList(db.tb_Categories, "category_id", "category_name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(tb_Products products, HttpPostedFileBase fileBase)
        {
            ViewBag.Categories = new SelectList(db.tb_Categories, "category_id", "category_name");
            if (ModelState.IsValid)
			{
				var productExists = db.tb_Products.Any(x => x.product_name.Equals(products.product_name));
				if (productExists)
				{
					ModelState.AddModelError("product_name", "Product name already exists");
					return View(products);
				}
				var modelExists = db.tb_Products.Any(x => x.model.Equals(products.model));
				if (modelExists)
				{
					ModelState.AddModelError("model", "Model number already registered");
					return View(products);
				}

				Dictionary<string, string> fileUpload = UploadImage(fileBase);
				if (fileUpload.ContainsKey("success"))
				{
                    products.product_img = fileUpload["success"];
                    products.inserted_at = DateTime.Now;
                    products.updated_at = DateTime.Now;
                    db.tb_Products.Add(products);
                    db.SaveChanges();
                    TempData["success"] = "Product added successfully!";
                    return RedirectToAction("ProductList");
                }
				else
				{
                    TempData["error"] = fileUpload["error"];
                    return View(products);
                }

            }
            return View(products);
        }

        private bool DeleteImage(string filename)
        {
            bool result = false;
            if (fileALreadyExist(filename))
            {
                try
                {
                    string path = Server.MapPath(filename);
                    FileInfo file = new FileInfo(path);
                    file.Delete();
                    result = true;
                }
                catch
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }
        private bool fileALreadyExist(string filename)
        {
            string path = Server.MapPath(filename);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Dictionary<string, string> UploadImage(HttpPostedFileBase file)
		{
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (file != null && file.ContentLength > 0)
			{
                string filename = Path.GetFileName(file.FileName);
                filename = "~/UploadImages/" + filename;

                if (fileALreadyExist(filename))
				{
                    result.Add("error", "Another file with same name already exists, Choose different or rename your file!");
                    return result;
				}

                string extension = Path.GetExtension(file.FileName);

                if(extension.ToLower().Equals(".jpg")|| extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
				{
					try
					{
                        string path = Server.MapPath(filename);
                        file.SaveAs(path);

						//if (productFileName != "")
						//{
						//	DeleteImage(productFileName);
						//}

						result.Add("success", filename);
					}
					catch
					{
                        result.Add("error", "Some unknown error occured while uploading the file!");
                    }
				}
				else
				{
                    result.Add("error", "Only jpg, jpeg and png formats are allowed!");
                }
            }
			else
			{
                result.Add("error", "Please select a file");
            }
            return result;
		}
    }
}