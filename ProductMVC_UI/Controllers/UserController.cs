using ProductMVC_UI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMVC_UI.Controllers
{
    public class UserController : Controller
    {
        ProductEntity pe = new ProductEntity();
        ProductDbContext pd = new ProductDbContext();
        public ActionResult UserHome()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ViewProduct()
        {
            List<ProductEntity> obj = new List<ProductEntity>();
            SqlDataReader sdr = pd.ShowProduct();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    ProductEntity pe = new ProductEntity();
                    pe.ID = Convert.ToInt32(sdr["ID"]);
                    pe.TeaserImage = Convert.ToString(sdr["TeaserImage"]);
                    pe.ShortDescription = Convert.ToString(sdr["ShortDescription"]);
                    pe.LongDescription = Convert.ToString(sdr["LongDescription"]);
                    obj.Add(pe);
                }
            }
            return View(obj);
        }
    }
}