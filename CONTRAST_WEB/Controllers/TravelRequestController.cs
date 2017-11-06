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
    public class TravelRequestController : Controller
    {
        //private CONTRASTEntities db = new CONTRASTEntities();

        [HttpPost]

        // /*
        public async Task<ActionResult> Index(TravelRequestHelper model)
        { 
            //string Baseurl = "http://localhost:51687/";
            string Baseurl = "http://10.85.40.68:90/";
            ViewBag.Username = model.employee_info.name;         
           
            using (var client = new HttpClient())
            {               
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage response = await client.GetAsync("api/Destination/Destination_List");
                if (response.IsSuccessStatusCode)
                {
                    List<String> ResponseList = new List<String>();
                    var str = response.Content.ReadAsStringAsync().Result;
                    ResponseList = JsonConvert.DeserializeObject<List<String>>(str);
                    List<SelectListItem> ListItem = new List<SelectListItem>();
                    int k=1;
                    foreach (var item in ResponseList)
                    {
                        var listItem = new SelectListItem();
                        listItem.Text = item;
                        listItem.Value = k.ToString();
                        ListItem.Add(listItem);
                        k++;
                    }
                    ViewBag.RL = ListItem;
                }
                //ViewBag.ResponseList = new List<SelectListItem> { }; 
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage response = await client.GetAsync("api/Purpose/");
                if (response.IsSuccessStatusCode)
                {
                    List<String> ResponseList = new List<String>();
                    var str = response.Content.ReadAsStringAsync().Result;
                    ResponseList = JsonConvert.DeserializeObject<List<String>>(str);
                    List<SelectListItem> ListItem = new List<SelectListItem>();
                    int k = 1;
                    foreach (var item in ResponseList)
                    {
                        var listItem = new SelectListItem();
                        listItem.Text = item;
                        listItem.Value = item;
                        ListItem.Add(listItem);
                        k++;
                    }
                    ViewBag.RL2 = ListItem;
                }
                //ViewBag.ResponseList = new List<SelectListItem> { }; 
            }


            return View(model);
        }

        ///*
        public ActionResult Index()
        {
            
            return View();
        }

    }
}
