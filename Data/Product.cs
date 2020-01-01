using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BeyzaSismanoglu_FinalProject.Data
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Product_Name { get; set; }
        public int Stock { get; set; }
        public int Waster_product { get; set; }
        public int Price { get; set; }
    }
}
