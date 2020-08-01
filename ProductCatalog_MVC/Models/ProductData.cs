using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog_MVC.Models
{
    public class ProductData
    {
        public int ID { get; set; }
        public string TeaserImage { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}
