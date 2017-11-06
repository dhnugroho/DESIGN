using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using CONTRAST_WEB.Models;

namespace CONTRAST_WEB.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Index(TravelRequestHelper model)
        {
             
           // string Baseurl = "http://localhost:51687/";
            string Baseurl = "http://10.85.40.68:90/";
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Employee/" + model.employee_info.code);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    model.employee_info = JsonConvert.DeserializeObject<tb_m_employee>(EmpResponse);
                }
                
                //returning the employee list to view  
                //model.employee_info = EmpInfo;
            }
            ViewBag.Username = model.employee_info.name;
            return View(model);
        }      
      //  /*
      [HttpPost]
      public async System.Threading.Tasks.Task<ActionResult>Index2(TravelRequestHelper model)
      { 
          //string Baseurl = "http://localhost:51687/";
          string Baseurl = "http://10.85.40.68:90/";
          
          model.travel_request.no_reg = Convert.ToInt32(model.employee_info.code) ;
           
          TimeSpan duration = (DateTime)model.travel_request.end_date - (DateTime)model.travel_request.start_date;
          model.travel_request.duration = duration.Days;

          ViewBag.Title = model.employee_info.code;
          //request no reg name
          using (var client = new HttpClient())
          {
              //Passing service base url  
              client.BaseAddress = new Uri(Baseurl);

              client.DefaultRequestHeaders.Clear();
              //Define request data format  
              client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

              //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
              HttpResponseMessage Res = await client.GetAsync("api/Employee/" + model.employee_info.code);

              //Checking the response is successful or not which is sent using HttpClient  
              if (Res.IsSuccessStatusCode)
              {
                  //Storing the response details recieved from web api   
                  var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                  //Deserializing the response recieved from web api and storing into the Employee list  
                  model.employee_info = JsonConvert.DeserializeObject<tb_m_employee>(EmpResponse);
              }
                ViewBag.Username = model.employee_info.name;
          }
          model.travel_request.active_flag = true;
          model.travel_request.create_date = DateTime.Now;
          model.travel_request.status_request="0";
          model.travel_request.comments = "lel";
          model.travel_request.participants_flag = false;
          model.travel_request.invited_by = model.travel_request.no_reg;
            model.travel_request.multiple_destination_flag = false;
            
            using (var client = new HttpClient())
          {
              //Passing service base url  
              client.BaseAddress = new Uri(Baseurl);

              client.DefaultRequestHeaders.Clear();
              //Define request data format  
              client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

              //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
              HttpResponseMessage response = await client.PostAsJsonAsync("api/TravelRequest", model.travel_request);              
          }
            return View(model);
      }
    }
}