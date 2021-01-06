using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyApp.Models;
using VidlyApp.ViewModels;

namespace VidlyApp.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult ShowCustomers()
        {
            var customers = GetCustomers();
            var viewModel = new ShowCustomerViewModel()
            {
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult CustomerDetail(int? id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        private List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }


    }
}