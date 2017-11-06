using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using CONTRAST_WEB.Models;

namespace CONTRAST_WEB.Controllers
{
    
    public class HomeController : Controller
    {
        private CONTRASTEntities db = new CONTRASTEntities();

        [HttpPost]
        
       // /*
        public async Task<ActionResult> Travel(tb_r_travel_request model)
        {

            //string Baseurl = "http://localhost:50195/";
            string Baseurl = "http://10.85.40.68:90/";
            using (var client = new HttpClient())
            {

                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage response = await client.PostAsJsonAsync("api/tb_r_travel_request",model);
                
                return View();
            }
        }

        ///*
        public ActionResult Travel()
        {
            ViewBag.Message = "Your application description page.";
            ///*
            var client = new HttpClient();           
            //*/
            return View();
        }

        public async Task<ActionResult> Travel2(tb_m_employee model, string a)
        {
            //string Baseurl = "http://localhost:50195/";
            string Baseurl = "http://10.85.40.68:90/";
            var ParticipantList = new List<tb_m_employee>{
                //new Participant() { NoregId = "BCA", Name = "Steve",  Age = 21, Amount = 337556412, City = "Malang" }
                new tb_m_employee() { bank_account = model.bank_account}

            };

            List<tb_m_employee> EmpInfo = new List<tb_m_employee>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Employee/tb_m_employee/" + a);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<List<tb_m_employee>>(EmpResponse);
                }
            }

            return View();
        }
        //*/
        //*/
        public ActionResult Index()
        {  
            return View( );
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Index(string model)
        {
            tb_m_employee trh = new tb_m_employee();
            if (trh != null) trh.code = model.Trim();
            TravelRequestHelper trh2 = new TravelRequestHelper();
            trh2.employee_info = trh;
            return View(trh2);
        }

        public ActionResult Menu(tb_m_employee model)
        {
            ViewBag.Title = model.code;

            return View(model);
        }

        public ActionResult Exec()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Settlement()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Participant()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SettlementList()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TravelStatus()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult TravelStatusList()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}