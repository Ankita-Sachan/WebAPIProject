using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using ClientApplication.Models;
using System.Web.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace ClientApplication.Controllers
{
    public class ClientController : Controller
    {
        // GET: /Client/

        public ActionResult GetEmployee()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:34140/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/Employee/").Result;
            if (response.IsSuccessStatusCode)
            {
                var employeeDetails = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                return View(employeeDetails);
            }
            return View();
        }

        [HttpGet]
        public ActionResult NewEmployee()
        {
            Employee emp = new Employee();
            return PartialView(emp);
        }
        public JsonResult Create(Employee emp)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:34140/");
            StringContent content = new StringContent(JsonConvert.SerializeObject(emp));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = client.PostAsync("api/Employee",content).Result;
            var jsonTask = response.Content.ReadAsStringAsync().Result;
            emp = JsonConvert.DeserializeObject<Employee>(jsonTask);
            
            if(response.IsSuccessStatusCode)
            {
                return Json(new { success = response, responseText="Saved!",id=emp.ID}, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = response, responseText = "Error!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult UpdateEmployeeData(Employee emp)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:34140/");
            using (HttpContent content = new StringContent(JsonConvert.SerializeObject(emp)))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = client.PutAsync("api/Employee/" + emp.ID, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { success = false, responseText = "Error!", Content= response.Content}, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = true, responseText = "Updated Succesfully"}, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpGet]
        public  JsonResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:34140/");
            HttpResponseMessage response = client.DeleteAsync("api/Employee/Delete?id=" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            
            //return RedirectToAction("GetEmployee");
        }

       
    }
}