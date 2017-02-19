using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace testbiedro.Models
{
    public class Order
    {
        [Key]
        public int Order_Id { get; set; }
        public string Client_Name { get; set; }
        public int Table_Number { get; set; }
        public DateTime Order_Date { get; set; }        
        public int Status { get; set; }
    }
}