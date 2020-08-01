using ProductMVC_UI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMVC_UI.Controllers
{
    public class AdminController : Controller
    {
        ProductEntity pe = new ProductEntity();
        ProductDbContext pd = new ProductDbContext();
        int id;
        public ActionResult AdminHome()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ShowProduct()
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
        [HttpPost]
        public ActionResult Delete(int id)
        {
            int ID = id;
            pd.DeleteProduct(ID);
            return RedirectToAction("ShowProduct");
        }
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            ProductEntity pe = pd.SelectProduct(id);
            return View(pe);
        }
        [HttpPost]
        public ActionResult EditProduct(ProductEntity entity, HttpPostedFileBase UploadImage)
        {
            pe.ID = entity.ID;
            string fileName = Path.GetFileNameWithoutExtension(UploadImage.FileName);
            string extension = Path.GetExtension(UploadImage.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmss") + extension;
            pe.TeaserImage = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            UploadImage.SaveAs(fileName);
            pe.ShortDescription = entity.ShortDescription;
            pe.LongDescription = entity.LongDescription;
            pd.UpdateProduct(pe);
            Response.Write("<script>alert('Product Details successfully updated.')</script>");
            ModelState.Clear();
            return View();
        }
    }
}