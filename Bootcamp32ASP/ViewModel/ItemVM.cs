using Bootcamp32ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bootcamp32ASP.ViewModel
{
    public class ItemVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int Supplier_id { get; set; }
    }
}