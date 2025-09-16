using ArkSoft_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArkSoft_MVC.Controllers
{
    public class CustomerController : Controller
    {
        //METHOD TO RETURN PAGE THAT SHOWS LIST OF ALL CUSTOEMRS IN DB
        public IActionResult AllCustomers()
        {
            //pull a list of customer data in db and return list
            return View();
        }

        //METHOD TO RETURN PAGE THAT SHOWS FORM TO ADD A NEW CUSTOMER
        public IActionResult CreateCustomer()
        {
            //displays add page for form
            return View();
        }

        //METHOD TO ADD A NEW CUSTOMER
        public IActionResult AddCustomer(Customer newCust)
        {
            //process customer object from form
            //add to db
            //redirect to page that shows list of customers to show updated list
            return View("AllCustomers");
        }
    }
}
