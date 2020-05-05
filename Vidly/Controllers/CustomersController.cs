using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public List<Customer> GetCustomers()
        {
            return  new List<Customer>
            {
                new Customer{Name = "John Smith" , id = 1},
                new Customer{Name = "Mary Williams" , id = 2}
            };
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customer = GetCustomers();
            return View(customer);
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(i => i.id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
    }
}