using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CONTRAST_WEB.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace CONTRAST_WEB.Controllers
{
    public class ActualcostController : Controller
    {
        private CONTRASTEntities db = new CONTRASTEntities();

        // GET: Actualcost
        public async Task<ActionResult> Index()
        {
            string Baseurl = "http://localhost:51687/";

            List<vw_request_summary> actinfo = new List<vw_request_summary>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("aaplication/json"));

                HttpResponseMessage response = await client.GetAsync("api/RequestSummary");

                if (response.IsSuccessStatusCode)
                {
                    var actresponse = response.Content.ReadAsStringAsync().Result;
                    actinfo = JsonConvert.DeserializeObject<List<vw_request_summary>>(actresponse);
                }
            }
            return View(actinfo);
        }

        // GET: Actualcost/Details/5
        public async Task<ActionResult> Details(vw_request_summary model)
        {
            
            return View(model);
        }
        

        // GET: Actualcost/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_r_travel_actualcost tb_r_travel_actualcost = await db.tb_r_travel_actualcost.FindAsync(id);
            if (tb_r_travel_actualcost == null)
            {
                return HttpNotFound();
            }
            return View(tb_r_travel_actualcost);
        }

        // POST: Actualcost/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_actualcost,id_request,planning_cost_hotel,planning_cost_flight,actualcost__flight,actualcost_hotel,user_created,create_date")] tb_r_travel_actualcost tb_r_travel_actualcost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_r_travel_actualcost).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tb_r_travel_actualcost);
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
