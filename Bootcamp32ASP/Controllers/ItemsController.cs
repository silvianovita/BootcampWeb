﻿using Bootcamp32ASP.Models;
using Bootcamp32ASP.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bootcamp32ASP.Controllers
{
    public class ItemsController : Controller
    {
        
        myContext myContext = new myContext();
        int sid;

        // GET: Items
        public ActionResult Index()
        {
            //var dtItem = myContext.tb_item.ToList();
            return View(List());
        }

        public JsonResult List()
        {
            var service = myContext.tb_item.ToList();
            var list = JsonConvert.SerializeObject(service, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });

            return Json(list, JsonRequestBehavior.AllowGet);
           
        }

        public JsonResult Add(tb_m_supplier supplier)
        {
            return Json(myContext.tb_m_supplier.Add(supplier), JsonRequestBehavior.AllowGet);
        }

        // GET: Items / Detail (id) --By
        public ActionResult Details(int id)
        {
            var dtItem = myContext.tb_item.Where(i => i.ID == id).FirstOrDefault();
            return View(dtItem);
        }

        //GET: Item /Create
        public ActionResult Create()
        {
            var db = new myContext();
            IEnumerable<SelectListItem> items = db.tb_m_supplier
              //.Where( s=>s.id==etItem.tb_m_supplier.id)
              .Select(c => new SelectListItem
              {
                  Value = c.id.ToString(),
                  Text = c.Name
              }).ToArray();
            ViewBag.Supplier_Id = items;
            return View();
        }

        //POST: Item /Create
        [HttpPost]
        public ActionResult Create(ItemVM item)
        {
            try
            {
                tb_item dtItem = new tb_item();
                dtItem.Name = item.Name;
                dtItem.Stock = item.Stock;
                dtItem.Price = item.Price;
                dtItem.Supplier_id = item.Supplier_id;
                myContext.tb_item.Add(dtItem);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            //BISA
            //tb_item dtItem = new tb_item();
            //dtItem.Name = item.Name;
            //dtItem.Stock = item.Stock;
            //dtItem.Price = item.Price;
            ////dtItem.tb_m_supplier = myContext.tb_m_supplier.FirstOrDefault(i => i.id == item.tb_m_supplier.id);
            ////dtItem.tb_m_supplier.id = myContext.tb_m_supplier.FirstOrDefault(i => i.id == item.tb_m_supplier.id).id;
            //myContext.tb_item.Add(dtItem);
            //myContext.SaveChanges();
        }

        // GET: Items / Edit (id) -- by
        public ActionResult Edit(int id)    
        {
            var item = myContext.tb_item.Where(i => i.ID == id).FirstOrDefault();
            ItemVM ItemVM = new ItemVM();
            var db = new myContext();
            IEnumerable<SelectListItem> items = db.tb_m_supplier
              //.Where( s=>s.id==etItem.tb_m_supplier.id)
              .Select(c => new SelectListItem
              {
                  Value = c.id.ToString(),
                  Text = c.Name
              }).ToArray();
            foreach (var it in items)
            {
                if (item.tb_m_supplier.Name==it.Text)
                {
                    it.Selected = true;
                }
                else
                {
                    it.Selected = false;
                }
            }
            ViewBag.Supplier_Id = items;
            ItemVM.ID = item.ID;
            ItemVM.Name = item.Name;
            ItemVM.Stock = item.Stock;
            ItemVM.Price = item.Price;
            ItemVM.Supplier_id = item.tb_m_supplier.id;
            return View(ItemVM);
        }

        // POST: Items / Edit (id)(edit) --by
        [HttpPost]
        public ActionResult Edit(int id, ItemVM ItemVM)
        {
            try
            {
                var etItem = myContext.tb_item.Where(i => i.ID == id).FirstOrDefault();
                tb_item items = new tb_item();
                etItem.Name = ItemVM.Name;
                etItem.Stock = ItemVM.Stock;
                etItem.Price = ItemVM.Price;
                etItem.Supplier_id = ItemVM.Supplier_id;
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET:Items/ delete
        public ActionResult Delete(int id)
        {
            var dtItem = myContext.tb_item.Where(i => i.ID == id).FirstOrDefault();
            return View(dtItem);
        }
        
        //POST: Items/ delete
        [HttpPost]
        public ActionResult Delete(int id, tb_item item)
        {
            try
            {
                var dtItem = myContext.tb_item.FirstOrDefault(i => i.ID == id);
                myContext.tb_item.Remove(dtItem);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}