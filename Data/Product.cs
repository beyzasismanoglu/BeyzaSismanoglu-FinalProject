using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BeyzaSismanoglu_FinalProject.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Product_Name { get; set; }
        public int Stock { get; set; }
        public int Waster_product { get; set; }
        public int Price { get; set; }
    }
}
