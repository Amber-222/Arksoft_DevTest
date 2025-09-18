using ArkSoft_MVC.Database;
using ArkSoft_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.Extensions;
using X.PagedList.Mvc.Core;

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
        public IActionResult AllCustomers(string sortOrder, string currentFilter, string sortDirection, string searchFilter, int? page)
        {
            int pageSize = 10;
            int pageIndex = page ?? 1;

            if (String.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "Name";
            }
            if (String.IsNullOrEmpty(sortDirection))
            {
                sortDirection = "desc";
            }
            if (!String.IsNullOrEmpty(searchFilter))
            {
                pageIndex = 1;
            }
            else
            {
                searchFilter = currentFilter;
            }

            ViewBag.currentDirection = sortDirection;
            ViewBag.nextDirection = sortDirection == "desc" ? "asc" : "desc"; //switch between descending and ascending sorting on every click
            ViewBag.currentSort = sortOrder;
            ViewBag.searchFilter = searchFilter;
            ViewBag.currentFilter = searchFilter;

            IQueryable<Customer> customerQuery = null;

            if (!String.IsNullOrEmpty(searchFilter))
            {
                //filter by input
                customerQuery = dbContext.Customer.Where(c => c.custName.Contains(searchFilter));
            }
            else
            {
                //or pull in full list
                customerQuery = dbContext.Customer;
            }

            //apply sorts on filtered/full list
            switch (sortOrder)
            {
                case "Name":
                    if (sortDirection == "desc")
                    {
                        customerQuery = customerQuery.OrderByDescending(c => c.custName);
                    }
                    else
                    {
                        customerQuery = customerQuery.OrderBy(c => c.custName);

                    }
                    break;
                case "VAT Number":
                    if (sortDirection == "desc")
                    {
                        customerQuery = customerQuery.OrderByDescending(c => c.vatNumber);
                    }
                    else
                    {
                        customerQuery = customerQuery.OrderBy(c => c.vatNumber);
                    }

                    break;
                case "Default":
                    customerQuery = customerQuery.OrderByDescending(c => c.custName);
                    break;
            }

            IPagedList<Customer> customers = customerQuery.ToPagedList(pageIndex, pageSize);

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

            if (result)
            {
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
