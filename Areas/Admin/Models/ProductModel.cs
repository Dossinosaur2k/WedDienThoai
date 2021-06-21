using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Demowed.Areas.Admin.Models
{
    public class ProductModel
    {
        public int Masp { get; set; }
        public string Tensp { get; set; }
        public decimal Giatien { get; set; }
        public int Soluong { get; set; }
        public int Mahang { get; set; }
    }
}