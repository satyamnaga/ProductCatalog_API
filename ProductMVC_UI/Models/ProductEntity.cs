using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductMVC_UI.Models
{
    public class ProductEntity
    {
        public int ID { get; set; }
        public string TeaserImage { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string RoleName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public enum RoleName
    {
        Admin,
        User
    }
}