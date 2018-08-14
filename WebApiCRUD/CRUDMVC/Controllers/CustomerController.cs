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
            if (id==0)
            {
                return View(new CustomerViewModel());
            }
            else
            {
                HttpResponseMessage response = CustomerClient.ApiCLient.GetAsync("Customers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<CustomerViewModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddEditCustomer(CustomerViewModel customer)
        {
            if (customer.CustomerId==0)
            {
                HttpResponseMessage response = CustomerClient.ApiCLient.PostAsJsonAsync("Customers", customer).Result;
            }
            else
            {
                HttpResponseMessage response = CustomerClient.ApiCLient.PutAsJsonAsync("Customers/" + customer.CustomerId, customer).Result;
            }
            
            return RedirectToAction("Index");
        }


        public ActionResult DeleteCustomer(int id)
        {
            HttpResponseMessage response = CustomerClient.ApiCLient.DeleteAsync("Customers/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }

    }
}