using API.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Model;
using Data.ViewModel;
using Data.Context;
using Data.Repository.Interface;
using Data.Repository;

namespace API.Services
{
    public class SupplierServices : ISupplierServices
    {
        int status = 0;
        ISupplierRepository srepository = new SupplierRepository();
        MyContext myContext = new MyContext();
        public int Create(SupplierVM supplierVM)
        {
            //var supplier = myContext.Suppliers.Where(s => s.Name.ToLower() == supplierVM.Name.ToLower() || s.Email.ToLower() == supplierVM.Email.ToLower());
            //int result = 0;
            if (string.IsNullOrWhiteSpace(supplierVM.Name) || string.IsNullOrWhiteSpace(supplierVM.Email))
            {
                return status;
            }
            else
            {
                return srepository.Create(supplierVM);
            }
            //if (supplier != null)
            //{
            //    var push = new Supplier(supplierVM);
            //    myContext.Suppliers.Add(push);
            //    result = myContext.SaveChanges();
            //}
            //return result;
        }



        public int Delete(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return status;
            }
            else
            {
                return srepository.Delete(id);
            }
        }

        public IEnumerable<Supplier> Get()
        {
            return srepository.Get();
            //return myContext.Suppliers.ToList();
        }

        public Supplier Get(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                var data = status;

            }
            return srepository.Get(id);
        }

        public int Update(int id, SupplierVM supplierVM)
        {
            //var supplier = myContext.Suppliers.Where(s => s.Name.ToLower() == supplierVM.Name.ToLower() || s.Email.ToLower() == supplierVM.Email.ToLower());
            //int result = 0;
            if (string.IsNullOrWhiteSpace(supplierVM.Name) || string.IsNullOrWhiteSpace(supplierVM.Email))
            {
                return status;
            }
            else
            {
                return srepository.Update(id, supplierVM);
            }
            //if (supplier != null)
            //{
            //    var update = myContext.Suppliers.Find(id);
            //    update.Update(supplierVM);
            //    result = myContext.SaveChanges();
            //}
            //return result;
        }

    }
}
