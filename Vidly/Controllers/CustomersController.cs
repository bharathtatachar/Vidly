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

        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var membershipTypeVM = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm",membershipTypeVM);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var CustomerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //method 1 - TryUpdateModel() -- not so reliable since all properties need not be updated, and maybe some should not be updated ever!
                // FYI - to update some properties using this method, specify in 3 rd position of this methods overload the properties to update.
                CustomerInDb.Name = customer.Name;
                CustomerInDb.Birthday = customer.Birthday;
                CustomerInDb.MembershipTypeId = customer.MembershipTypeId;
                CustomerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                //if dont want to use every property , may require an automapper to update based on convention.
                //if want to restrict updates to only certain properties , then create a DTO (data transfer object)
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
    
            var ViewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };


            return View("CustomerForm", ViewModel);

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