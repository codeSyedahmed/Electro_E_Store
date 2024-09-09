using Electro_E_Store.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Electro_E_Store.Controllers
{
    public class AdminController : Controller
    {
        DB_ShopEntities db = new DB_ShopEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(tb_Admin admin)
        {
            if(ModelState.IsValid)
            {
                var isemailExits = db.tb_Admin.Any(x => x.admin_email.Equals(admin.admin_email));
                if(isemailExits)
                {
                    ModelState.AddModelError("admin_email", "Email already exits, Please enter another email");
                    return View(admin);
                }

                admin.join_date = DateTime.Now;
                admin.updated_at = DateTime.Now;

                db.tb_Admin.Add(admin);
                db.SaveChanges();
                TempData["success"] = "Your account has been created!";
                return RedirectToAction("Login");
            }
            return View(admin);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel login)
        {
            if(ModelState.IsValid)
            {
                var admin = db.tb_Admin.Where(a => a.admin_email.Equals(login.admin_email) && a.a_password.Equals(login.a_password)).FirstOrDefault();

                if(admin != null)
                {
                    Session["admin_id"] = admin.admin_id.ToString();
                    Session["admin_name"] = admin.admin_name.ToString();

                    FormsAuthentication.SetAuthCookie(admin.admin_email, false);
                    return RedirectToAction("Index", "Admin");
                }
            }

            // in case of error
            ModelState.AddModelError("InvalidLogin", "invalid email or password or perhaps you are not a verified user!");
            return View(login);
        }

        public ActionResult Logout()
        {
            if(Session["admin_id"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            Session["admin_id"] = null;
            Session["admin_name"] = null;

            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Admin");
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            int login_admin_id = Convert.ToInt32(Session["admin_id"]);
            tb_Admin admin = db.tb_Admin.Find(login_admin_id);
            return View(admin);
        }

        [HttpPost]
        public ActionResult EditProfile(tb_Admin userProfile)
        {
            if (ModelState.IsValid)
            {
                userProfile.updated_at = DateTime.Now;
                db.Entry(userProfile).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                Session["admin_name"] = userProfile.admin_name;
                ViewData["success"] = "Profile Updated succesfully";
            }
            return View(userProfile);
        }
    }
    
}
