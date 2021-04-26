using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            IEnumerable<MVCContactModel> cntList;
            HttpResponseMessage response = GlobalStatic.WebApiClient.GetAsync("Contacts").Result;
             cntList = response.Content.ReadAsAsync<IEnumerable<MVCContactModel>>().Result;
            return View(cntList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new MVCContactModel());
            else
            {
                HttpResponseMessage response = GlobalStatic.WebApiClient.GetAsync("Contacts/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MVCContactModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(MVCContactModel cnt)
        {
            if (cnt.Id == 0)
            {
                HttpResponseMessage response = GlobalStatic.WebApiClient.PostAsJsonAsync("Contacts", cnt).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalStatic.WebApiClient.PutAsJsonAsync("Contacts/" + cnt.Id, cnt).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
                  
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalStatic.WebApiClient.DeleteAsync("Contacts/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}