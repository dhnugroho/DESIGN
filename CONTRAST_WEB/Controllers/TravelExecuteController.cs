using CONTRAST_WEB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.IO;

namespace CONTRAST_WEB.Controllers
{
    public class TravelExecuteController : Controller
    {
        private CONTRASTEntities db = new CONTRASTEntities();
        
        // GET: TravelExecute
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

        // GET: TravelExecute
        public ActionResult Executed()
        {
            CONTRASTEntities db = new CONTRASTEntities();
            return View();
        }

        public JsonResult ImageUpload(ImageViewModel model)
        {
            CONTRASTEntities db = new CONTRASTEntities();
            int ImgId = 0;
            var Lat = "Latitude";
            var Lon = "Longitude";
            var file = model.ImageFile;
            byte[] Imagebyte = null;

            if (file != null)
            {

                //var fileName = Path.GetFileName(file.FileName);
                //var extention = Path.GetExtension(file.FileName);
                //var filenamewithoutextension = Path.GetFileNameWithoutExtension(file.FileName);

                file.SaveAs(Server.MapPath("/UploadImage/" + file.FileName));

                BinaryReader reader = new BinaryReader(file.InputStream);

                Imagebyte = reader.ReadBytes(file.ContentLength);

                tb_r_travel_execution img = new tb_r_travel_execution();
                //img.Lat = Lat;
                //img.Lon = Lon;
                img.desc_upload = file.FileName;
                //img.numbers = Imagebyte.ToString();
                img.pic_path = "/UploadedImage/" + file.FileName;
                //img.IsDelete = 0;
                db.tb_r_travel_execution.Add(img);
                db.SaveChanges();

                ImgId = img.id_travel;

            }

            return Json(ImgId, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ImageRetrieve(int imgID)
        {
            CONTRASTEntities db = new CONTRASTEntities();
            var img = db.tb_r_travel_execution.SingleOrDefault(x => x.id_travel == imgID);
            return View();
            //add field "bytes" type data "Image"
            //return File(img.id_travel, "image/jpg");
        }
    }
}