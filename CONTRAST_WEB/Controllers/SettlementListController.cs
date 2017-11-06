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
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;

namespace CONTRAST_WEB.Controllers
{
    public class SettlementListController : Controller
    {
        private CONTRASTEntities db = new CONTRASTEntities();

        // GET: SettlementList
        public async Task<ActionResult> Index(TravelRequestHelper model)
        {
            string Baseurl = "http://10.85.40.68:90/";
            ViewBag.Employee = model.employee_info;

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
                
                return View(ResponseList);
            }
        }

        // GET: SettlementList/Details/5
        public ActionResult Details(vw_request_summary model)
        {
            tb_r_travel_settlement setlement = new tb_r_travel_settlement();
            

            return View(setlement);
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
