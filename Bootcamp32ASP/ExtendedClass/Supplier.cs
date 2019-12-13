using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bootcamp32ASP.ExtendedClass
{
    [MetadataType(typeof(SupplierMetaData))]
    public partial class Supplier
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }


    public class SupplierMetaData
    {
        [Required(ErrorMessage = "Supplier Name required", AllowEmptyStrings = false)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Supplier Email required", AllowEmptyStrings = false)]
        [Display(Name = "Emaiil")]
        public string Email { get; set; }
    }
}