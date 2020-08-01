using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProductMVC_UI.Models
{
    public class ProductDbContext
    {
        string str = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        SqlConnection cn;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter sda;
        SqlDataReader sdr;
        public void InsertProduct(ProductEntity pe)
        {
            cn = new SqlConnection(str);
            cmd = new SqlCommand("Insert_Product", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TeaserImage", pe.TeaserImage);
            cmd.Parameters.AddWithValue("@ShortDescription", pe.ShortDescription);
            cmd.Parameters.AddWithValue("@LongDescription", pe.LongDescription);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public void UpdateProduct(ProductEntity pe)
        {
            cn = new SqlConnection(str);
            cmd = new SqlCommand("Update_Product", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", pe.ID);
            cmd.Parameters.AddWithValue("@TeaserImage", pe.TeaserImage);
            cmd.Parameters.AddWithValue("@ShortDescription", pe.ShortDescription);
            cmd.Parameters.AddWithValue("@LongDescription", pe.LongDescription);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public void DeleteProduct(int ID)
        {
            cn = new SqlConnection(str);
            cmd = new SqlCommand("Delete_Product", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ID);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public SqlDataReader ShowProduct()
        {
            cn = new SqlConnection(str);
            cmd = new SqlCommand("Show_Product", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            sdr = cmd.ExecuteReader();
            return sdr;
        }
        public ProductEntity SelectProduct(int id)
        {
            ProductEntity obj = new ProductEntity();
            cn = new SqlConnection(str);
            cmd = new SqlCommand("Select * from products where ID =" + id, cn);
            cn.Open();
            sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    obj.ID = Convert.ToInt32(sdr["ID"]);
                    //obj.TeaserImage = Convert.ToString(sdr["TeaserImage"]);
                    obj.ShortDescription = Convert.ToString(sdr["ShortDescription"]);
                    obj.LongDescription = Convert.ToString(sdr["LongDescription"]);
                }
            }
            return obj;
        }
    }
}