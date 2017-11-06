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

namespace CONTRAST_WEB.Controllers
{
    public class vw_request_summaryController : Controller
    {
        private CONTRASTEntities db = new CONTRASTEntities();

        // GET: vw_request_summary
        public async Task<ActionResult> Index()
        {
            return View(await db.vw_request_summary.ToListAsync());
        }

        // GET: vw_request_summary/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw_request_summary vw_request_summary = await db.vw_request_summary.FindAsync(id);
            if (vw_request_summary == null)
            {
                return HttpNotFound();
            }
            return View(vw_request_summary);
        }

        // GET: vw_request_summary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vw_request_summary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_request,group_code,id_dit,no_reg,id_destination_city,destination_code,multiple_destination_flag,departure,participants_flag,overseas_flag,id_travel_type,request_type,travel_purpose,invited_by,reason_of_assigment,air_ticket_flag,passport_flag,apprv_by_dh,apprv_by_fd,apprv_by_vp,apprv_by_pd,apprv_dh,apprv_fd,apprv_vp,apprv_pd,apprv_dh_date,apprv_fd_date,apprv_vp_date,apprv_pd_date,budget,remaining_budget,exep_empolyee,start_date,end_date,duration,create_date,comments,transit_by_land,transit_by_air,total_transit,allowance_transit_by_land,allowance_transit_by_air,total_allowance_transit,allowance_meal_idr,allowance_meal_jpy,allowance_meal_usd,allowance_hotel,allowance_transportation,allowance_laundry,allowance_miscellaneous,total_allowance_basic,allowance_ticket,allowance_visa,allowance_passport,total_allowance_document,grand_total_allowance,status_request,active_flag,destination_name,region_name")] vw_request_summary vw_request_summary)
        {
            if (ModelState.IsValid)
            {
                db.vw_request_summary.Add(vw_request_summary);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vw_request_summary);
        }

        // GET: vw_request_summary/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw_request_summary vw_request_summary = await db.vw_request_summary.FindAsync(id);
            if (vw_request_summary == null)
            {
                return HttpNotFound();
            }
            return View(vw_request_summary);
        }

        // POST: vw_request_summary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_request,group_code,id_dit,no_reg,id_destination_city,destination_code,multiple_destination_flag,departure,participants_flag,overseas_flag,id_travel_type,request_type,travel_purpose,invited_by,reason_of_assigment,air_ticket_flag,passport_flag,apprv_by_dh,apprv_by_fd,apprv_by_vp,apprv_by_pd,apprv_dh,apprv_fd,apprv_vp,apprv_pd,apprv_dh_date,apprv_fd_date,apprv_vp_date,apprv_pd_date,budget,remaining_budget,exep_empolyee,start_date,end_date,duration,create_date,comments,transit_by_land,transit_by_air,total_transit,allowance_transit_by_land,allowance_transit_by_air,total_allowance_transit,allowance_meal_idr,allowance_meal_jpy,allowance_meal_usd,allowance_hotel,allowance_transportation,allowance_laundry,allowance_miscellaneous,total_allowance_basic,allowance_ticket,allowance_visa,allowance_passport,total_allowance_document,grand_total_allowance,status_request,active_flag,destination_name,region_name")] vw_request_summary vw_request_summary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vw_request_summary).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vw_request_summary);
        }

        // GET: vw_request_summary/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw_request_summary vw_request_summary = await db.vw_request_summary.FindAsync(id);
            if (vw_request_summary == null)
            {
                return HttpNotFound();
            }
            return View(vw_request_summary);
        }

        // POST: vw_request_summary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            vw_request_summary vw_request_summary = await db.vw_request_summary.FindAsync(id);
            db.vw_request_summary.Remove(vw_request_summary);
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
