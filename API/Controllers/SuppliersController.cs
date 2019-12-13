using API.Services;
using API.Services.Interface;
using Data.Model;
using Data.Repository;
using Data.Repository.Interface;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class SuppliersController : ApiController
    {
        ISupplierServices supplier = new SupplierServices();
        //ISupplierRepository supplier = new SupplierRepository();
        // GET: api/Suppliers
        public IEnumerable<Supplier> Get()
        {
            var Data = supplier.Get();
            return Data;
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Suppliers/5
        public string Get(int id)
        {
            var Data = supplier.Get(id);
            return "ID  : "+Data.id+" " +
                " Name  : "+Data.Name+
                " Email : "+Data.Email+
                " IsDelete    : "+Data.IsDelete+
                " CreateDate  : "+Data.CreateDate+
                " UpdateDate  : "+Data.UpdateDate+
                " DelteDate   : "+Data.DeleteDate;
        }

        // POST: api/Suppliers
        public int Post(SupplierVM supplierVM)
        {
            return supplier.Create(supplierVM);
        }

        // PUT: api/Suppliers/5
        public int Put(int id, SupplierVM supplierVM)
        {
            return supplier.Update(id, supplierVM);
        }

        // DELETE: api/Suppliers/5
        public int Delete(int id)
        {
            return supplier.Delete(id);
        }
    }
}
