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
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace CONTRAST_WEB.Controllers
{
    public class TravelStatusController : Controller
    {
        private CONTRASTEntities db = new CONTRASTEntities();

        // GET: TravelStatus
        public async Task<ActionResult> Index(TravelRequestHelper model)
        {
            //string Baseurl = "http://localhost:50195/";
            string Baseurl = "http://10.85.40.68:90/";
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                List<vw_request_summary> ResponseList = new List<vw_request_summary>();

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage response = await client.GetAsync("api/RequestSummary/" + model.employee_info.code);
                if (response.IsSuccessStatusCode)
                {                   
                    var str = response.Content.ReadAsStringAsync().Result;
                    ResponseList = JsonConvert.DeserializeObject<List<vw_request_summary>>(str);
                }
                ViewBag.Username = model.employee_info.name;
                return View(ResponseList);
            }

        }

        // Details: TravelStatus
        public async Task<ActionResult> Details(IEnumerable<vw_request_summary> model)
        {
            TravelRequestHelper model2 = new TravelRequestHelper();
            //model2.travel_request = model;

            return View(model2);
        }

        // POST: TravelStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_request,group_code,id_dit,no_reg,id_destination_city,destination_code,multiple_destination_flag,departure,participants_flag,overseas_flag,id_travel_type,request_type,travel_purpose,invited_by,reason_of_assigment,air_ticket_flag,passport_flag,apprv_by_dh,apprv_by_fd,apprv_by_vp,apprv_by_pd,apprv_dh,apprv_fd,apprv_vp,apprv_pd,apprv_dh_date,apprv_fd_date,apprv_vp_date,apprv_pd_date,budget,remaining_budget,exep_empolyee,start_date,end_date,duration,create_date,comments,transit_by_land,transit_by_air,total_transit,allowance_transit_by_land,allowance_transit_by_air,total_allowance_transit,allowance_meal_idr,allowance_meal_jpy,allowance_meal_usd,allowance_hotel,allowance_transportation,allowance_laundry,allowance_miscellaneous,total_allowance_basic,allowance_ticket,allowance_visa,allowance_passport,total_allowance_document,grand_total_allowance,status_request,active_flag")] tb_r_travel_request tb_r_travel_request)
        {
            if (ModelState.IsValid)
            {
                db.tb_r_travel_request.Add(tb_r_travel_request);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tb_r_travel_request);
        }

        // GET: TravelStatus/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_r_travel_request tb_r_travel_request = await db.tb_r_travel_request.FindAsync(id);
            if (tb_r_travel_request == null)
            {
                return HttpNotFound();
            }
            return View(tb_r_travel_request);
        }

        // POST: TravelStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_request,group_code,id_dit,no_reg,id_destination_city,destination_code,multiple_destination_flag,departure,participants_flag,overseas_flag,id_travel_type,request_type,travel_purpose,invited_by,reason_of_assigment,air_ticket_flag,passport_flag,apprv_by_dh,apprv_by_fd,apprv_by_vp,apprv_by_pd,apprv_dh,apprv_fd,apprv_vp,apprv_pd,apprv_dh_date,apprv_fd_date,apprv_vp_date,apprv_pd_date,budget,remaining_budget,exep_empolyee,start_date,end_date,duration,create_date,comments,transit_by_land,transit_by_air,total_transit,allowance_transit_by_land,allowance_transit_by_air,total_allowance_transit,allowance_meal_idr,allowance_meal_jpy,allowance_meal_usd,allowance_hotel,allowance_transportation,allowance_laundry,allowance_miscellaneous,total_allowance_basic,allowance_ticket,allowance_visa,allowance_passport,total_allowance_document,grand_total_allowance,status_request,active_flag")] tb_r_travel_request tb_r_travel_request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_r_travel_request).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tb_r_travel_request);
        }

        // GET: TravelStatus/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_r_travel_request tb_r_travel_request = await db.tb_r_travel_request.FindAsync(id);
            if (tb_r_travel_request == null)
            {
                return HttpNotFound();
            }
            return View(tb_r_travel_request);
        }

        // POST: TravelStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_r_travel_request tb_r_travel_request = await db.tb_r_travel_request.FindAsync(id);
            db.tb_r_travel_request.Remove(tb_r_travel_request);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
