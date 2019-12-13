using Bootcamp32ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bootcamp32ASP.ViewModel
{
    public class SupplierVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }

        //public IEnumerable<tb_m_supplier> tb_m_supplier { get; set; }
    }
}