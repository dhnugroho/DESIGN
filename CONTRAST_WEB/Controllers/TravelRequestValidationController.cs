using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    public class TravelRequestValidationController : Controller
    {
        // GET: TravelRequestValidation
        public async Task<ActionResult> Index(TravelRequestHelper model)
        {
            TimeSpan duration = ((DateTime)model.travel_request.end_date -(DateTime)model.travel_request.start_date);
            model.travel_request.duration = duration.Days;
            
            //string Baseurl = "http://localhost:51687/";
            string Baseurl = "http://10.85.40.68:90/";
            using (var client = new HttpClient())
            {
                tb_m_destination EmpInfo = new tb_m_destination();
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Destination/Region?reg=" + model.travel_request.id_destination_city);
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<tb_m_destination>(EmpResponse);
                }
                model.travel_request.destination_code = EmpInfo.id_region;
            }

            using (var client = new HttpClient())
            {

                vw_travel_allowance EmpInfo = new vw_travel_allowance();
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/TravelAllowance?rank=" + model.employee_info.@class + "&reg=" + model.travel_request.destination_code + "&dt=" + ((model.travel_request.overseas_flag == true) ? 1 : 0).ToString());

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<vw_travel_allowance>(EmpResponse);

                }
                model.travel_request.allowance_meal_idr = EmpInfo.meal_allowance*Convert.ToInt32(duration.Days);
                // cek winter gak?
                ///*
                if (model.travel_request.start_date.Value.Month == 12 || model.travel_request.start_date.Value.Month == 1 || model.travel_request.start_date.Value.Month == 0)
                {
                    model.travel_request.allowance_winter = EmpInfo.winter_allowance;
                }
                else
                    model.travel_request.allowance_winter = 0;
                //*/

            }
            using (var client = new HttpClient())
            {
                tb_m_rate_flight EmpInfo = new tb_m_rate_flight();
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/RateFlight/" + model.travel_request.id_destination_city);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<tb_m_rate_flight>(EmpResponse);
                }
                model.travel_request.allowance_ticket = (EmpInfo.economy)*2;
            }

            using (var client = new HttpClient())
            {
                tb_m_rate_hotel EmpInfo = new tb_m_rate_hotel();
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/RateHotel?rank=" + model.employee_info.@class);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<tb_m_rate_hotel>(EmpResponse);
                }
                if(model.travel_request.overseas_flag==true)model.travel_request.allowance_hotel = EmpInfo.overseas*Convert.ToInt32(duration.Days);
                else
                model.travel_request.allowance_hotel = EmpInfo.domestik * Convert.ToInt32(duration.Days);
            }

            model.travel_request.apprv_flag_lvl5="0";
            model.travel_request.apprv_flag_lvl1="0";
            model.travel_request.apprv_flag_lvl2="0";
            model.travel_request.apprv_flag_lvl3="0";
            model.travel_request.apprv_flag_lvl4="0";
            model.travel_request.allowance_preparation = 0;
            model.travel_request.grand_total_allowance = model.travel_request.allowance_meal_idr + model.travel_request.allowance_hotel + model.travel_request.allowance_preparation + model.travel_request.allowance_ticket + model.travel_request.allowance_winter;
            

            //for exep employee
            model.travel_request.exep_empolyee = false;
            return View(model);
        }
    }
}