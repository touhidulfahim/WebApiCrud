using CRUDMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;


namespace CRUDMVC.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            IEnumerable<CustomerViewModel> empList;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Customer").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<CustomerViewModel>>().Result;
            return View(empList);
        }
    }
}