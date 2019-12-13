using Bootcamp32ASP.Models;
using Bootcamp32ASP.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bootcamp32ASP.Controllers
{
    public class SuppliersController : Controller
    {
        //Hosted (web)API REST Service base url
        string Baseurl = "http://localhost:49906/";


        myContext myContext = new myContext();
        readonly HttpClient client = new HttpClient();

        public SuppliersController()
        {
            //pasing service baseurl
            client.BaseAddress = new Uri(Baseurl);
            //clear default request header
            client.DefaultRequestHeaders.Clear();
            //define request data format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        // GET: Supplier
        public ActionResult Index()//SupplierVM SupplierVM)
        {
            return View(List());

            //var dtSupp = myContext.tb_m_supplier.ToList();
            //return View(List());

            //var model = new SupplierVM();

            //var dtSupp = myContext.tb_m_supplier.AsEnumerable();
            //model.tb_m_supplier = dtSupp;
            //return View(model);
        }


        public async Task<JsonResult> List()
        {
            //sending request to find web api REST service resource
            HttpResponseMessage Res = await client.GetAsync("API/Suppliers");

            //Checking the response is successfull or not which is sent using HttpClient (*wishing)
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details received from web api
                var service = await Res.Content.ReadAsAsync<tb_m_supplier[]>();

                //Deserializing the response received from web api 
                var json = JsonConvert.SerializeObject(service, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            return Json("Failed", JsonRequestBehavior.DenyGet);
            //return Content(list, "application/json");
            //return Json(myContext.tb_m_supplier.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(tb_m_supplier supplier)
        {
            tb_m_supplier inSupp = new tb_m_supplier();
            inSupp.Name = supplier.Name;
            inSupp.Email = supplier.Email;
            inSupp.CreateDate = DateTime.Now;
            myContext.tb_m_supplier.Add(inSupp);
            return Json(myContext.SaveChanges(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int id)
        {
            var supp = myContext.tb_m_supplier.FirstOrDefault(x => x.id == id);
            var json = JsonConvert.SerializeObject(supp, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> Delete1(int id)
        {
            //Getting param (id) check from supplier

            //sending request to find web api REST service resource
            //HttpResponseMessage Res = await client.DeleteAsync("API/Suppliers/",id.ToString());
            //var response = client.DeleteAsync("api/person/"+id).Result;
            ////Checking the response is successfull or not which is sent using HttpClient (*wishing)
            //if (Res.IsSuccessStatusCode)
            //{
            //    Console.Write("Success");
            //}
            //return Json(response, JsonRequestBehavior.DenyGet);
            var data = myContext.tb_m_supplier.FirstOrDefault(i => i.id == id);
            return Json(myContext.tb_m_supplier.Remove(data), JsonRequestBehavior.AllowGet);
        }

        // GET: Supplier/Details/5
        public ActionResult Details(int id)
        {
            var dtSupp = myContext.tb_m_supplier.Where(i => i.id == id).FirstOrDefault();
            return View(dtSupp);
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        public ActionResult Create(tb_m_supplier supplier)
        {
            try
            {
                // TODO: Add insert logic here
                tb_m_supplier inSupp = new tb_m_supplier();
                inSupp.Name = supplier.Name;
                inSupp.Email = supplier.Email;
                inSupp.CreateDate = DateTime.Now;
                myContext.tb_m_supplier.Add(inSupp);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int id)
        {
            var etSupp = myContext.tb_m_supplier.Where(i => i.id == id).FirstOrDefault();
            return View(etSupp);
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, tb_m_supplier supplier)
        {
            try
            {
                // TODO: Add update logic here
                var etSupp = myContext.tb_m_supplier.Where(i => i.id == id).FirstOrDefault();
                etSupp.Name = supplier.Name;
                etSupp.Email = supplier.Name;
                etSupp.CreateDate = DateTime.Now;
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int id)
        {
            var deRow = myContext.tb_m_supplier.Where(d => d.id == id).FirstOrDefault();
            return View(deRow);
        }

        // POST: Supplier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var deRow = myContext.tb_m_supplier.Where(d => d.id == id).FirstOrDefault();
                myContext.tb_m_supplier.Remove(deRow);
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
