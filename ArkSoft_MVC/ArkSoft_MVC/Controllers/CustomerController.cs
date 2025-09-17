using ArkSoft_MVC.Database;
using ArkSoft_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace ArkSoft_MVC.Controllers
{
    public class CustomerController : Controller
    {
        public dbContext dbContext;
        public readonly IWebHostEnvironment env;

        public CustomerController(dbContext dbContext, IWebHostEnvironment env)
        {
            this.dbContext = dbContext;
            this.env = env;
        }

        //METHOD TO RETURN PAGE THAT SHOWS LIST OF ALL CUSTOEMRS IN DB
        public IActionResult AllCustomers(string sortOrder, string currentSort, int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            if (String.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "Name";
            }

            ViewBag.currentSort = sortOrder;

            IPagedList<Customer> customers = null;

            switch (sortOrder)
            {
                case "Name":
                    if (sortOrder.Equals(currentSort))
                    {
                        customers = dbContext.Customer.OrderByDescending(c => c.custName).ToPagedList(pageIndex, pageSize);
                    }
                    else
                    {
                        customers = dbContext.Customer.OrderBy(c => c.custName).ToPagedList(pageIndex, pageSize);
                    }
                    break;
                case "VAT Number":
                    if (sortOrder.Equals(currentSort))
                    {
                        customers = dbContext.Customer.OrderByDescending(c => c.vatNumber).ToPagedList(pageIndex, pageSize);
                    }
                    else
                    {
                        customers = dbContext.Customer.OrderBy(c => c.vatNumber).ToPagedList(pageIndex, pageSize);
                    }
                    break;
                case "Default":
                    customers = dbContext.Customer.OrderByDescending(c => c.custName).ToPagedList(pageIndex, pageSize);
                    break;
            }

            return View(customers);
        }

        //METHOD TO RETURN PAGE THAT SHOWS FORM TO ADD A NEW CUSTOMER
        public IActionResult CreateCustomer()
        {
            //displays add page for form
            return View();
        }

        //METHOD TO ADD A NEW CUSTOMER
        public async Task<IActionResult> AddCustomer(Customer newCust)
        {
            //process customer object from form
            var result = await dbContext.CreateCustomer(newCust);
            
            if (result) { 
                //redirect to page that shows list of customers to show updated list
                return RedirectToAction("AllCustomers");
            }
            else
            {
                return View(newCust);
            }
            
        }

        //METHOD TO DISPLAY PAGE WITH CUSTOMER DETAISL TO UPDATE
        public async Task<IActionResult> UpdateDetails(int custID)
        {
            var cust = await dbContext.Customer.FirstOrDefaultAsync(c => c.custID == custID); //look for the customer to update in db

            if (cust != null)
            {
                return View(cust);
            }
            else
            {
                return RedirectToAction("AllCustomers");
            }
        }

        //METHOD ACCEPTING UPDATED DETAILS
        public async Task<IActionResult> Update(Customer cust)
        {
            if (cust != null)
            {
                var result = await dbContext.Update(cust);

                if (result)
                {
                    return RedirectToAction("AllCustomers");
                }
            }
            return View(cust);
        }

        //METHDO TO DELET CUSTOMER RECORD
        public async Task<IActionResult> Delete(int custID)
        {
            var result = await dbContext.Delete(custID);

            if (result)
            {
                return RedirectToAction("AllCustomers");
            }

            return View();
        }
    }
}
