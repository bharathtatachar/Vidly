using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //List<Customer> lstCustomer = new List<Customer>()
        //           {
        //               new Customer{Name = "Rafael Nadal", Id = 1},
        //               new Customer{Name = "Roger Federer", Id = 2}
        //           };
        // GET: Customers
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        
        public ActionResult Customers()
        {

            // var vmCustomers = new CustomersViewModel { Customers = lstCustomer };

            // var customers = GetCustomers();
            var customers = _context.Customers;
            return View(customers);
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(x => x.Id == id);//GetCustomers().SingleOrDefault(x => x.Id == id);
            return View(customer);
        }
        //public ActionResult GetCustomer(int id)
        //{
        //    return View(lstCustomers.Where(p => p.Id == id));
        //}

        
    }
}