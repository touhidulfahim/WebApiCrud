using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDMVC.Models;
using System.Net.Http;

namespace CRUDMVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            IEnumerable<CustomerViewModel> empList;
            HttpResponseMessage response = CustomerClient.ApiCLient.GetAsync("Customers").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<CustomerViewModel>>().Result;
            return View(empList);            
        }

        [HttpGet]

        public ActionResult AddEditCustomer(int id=0)
        {
            return View(new CustomerViewModel());
        }

        [HttpPost]
        public ActionResult AddEditCustomer(CustomerViewModel customer)
        {
            HttpResponseMessage response = CustomerClient.ApiCLient.PostAsJsonAsync("Customers", customer).Result;
            return RedirectToAction("Index");
        }

    }
}