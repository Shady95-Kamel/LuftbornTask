using LuftbornTask.Models;
using LuftbornTask.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LuftbornTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService customerService;

        public HomeController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
         //Get All Customers
        public async Task<IActionResult> Index() 
        {
            var customers = await customerService.GetCustomers();
            return View(customers);
        }

        //Get Single Customer
        public async Task<IActionResult> Details(int id) 
        {
           var customer= await customerService.GetCustomer(id);
            return View(customer);
        }

        //Create New Customer
        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer) 
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    await customerService.AddCustomer(customer);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
          
            ModelState.AddModelError("", "You have to fill all the required fields!");
            return View(Index());
        }

        //Get Single Customer
        public async Task <IActionResult> Edit(int id)
        {
            var customer = await customerService.GetCustomer(id);
            return View(customer);
        }

        //Edit Customer
        [HttpPost]
        public async Task <IActionResult> Edit(int id, Customer customer)
        {
            try
            {
              await  customerService.EditCustomer(id, customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //Get Single Customer
        public async Task <IActionResult> Delete(int id)
        {
            var customer = await customerService.GetCustomer(id);
            return View(customer);
        }

        public async Task <IActionResult> ConfirmDelete(int id)
        {
            try
            {
                await customerService.DeleteCustomer(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
