using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace testbiedro.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public string Quantity { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Weight { get; set; }
        public int Category_Id { get; set; }
        public string Image { get; set; }
    }
}