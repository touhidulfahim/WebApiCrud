using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDMVC.Models
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
    }
}