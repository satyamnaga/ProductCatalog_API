using ProductMVC_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMVC_UI.Controllers
{
    public class AccountController : Controller
    {
        ProductEntity pe = new ProductEntity();
        ProductDbContext pd = new ProductDbContext();
        public ActionResult Home()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ProductEntity entity)
        {
            if (entity.RoleName == "Admin" && entity.Username == "Admin" && entity.Password == "Admin")
            {
                return RedirectToAction("AdminHome", "Admin");
            }
            else if (entity.RoleName == "User" && entity.Username == "Hari" && entity.Password == "Hari@123")
            {
                return RedirectToAction("UserHome", "User");
            }
            else
            {
                Response.Write("<script>alert('Invalid Credentials...!')</script>");
                return View();
            }
        }
    }
}