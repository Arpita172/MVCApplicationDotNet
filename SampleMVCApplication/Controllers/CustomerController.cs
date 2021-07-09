using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMVCApplication.Models;

namespace SampleMVCApplication.Controllers
{
    public class CustomerController : Controller
    {
        public static List<Customer> customerList = new List<Customer>{
                            new Customer() { customerID = 1, firstName = "John", lastName="sherin",email="john@gmail.com",contactNo="909067679" } ,
                            new Customer() { customerID = 2, firstName = "Rony", lastName="ronalds",email="ron@gmail.com",contactNo="89344012" } ,
                            new Customer() { customerID = 3, firstName = "Ahmed", lastName="sherif",email="ahshe@gmail.com",contactNo="866757474" } ,
                            new Customer() { customerID = 4, firstName = "Mathew", lastName="ostich",email="math12@gmail.com",contactNo="32901929" } ,

            };
        static Customer x;
        public ActionResult Index()
        {
            return View(customerList.OrderBy(c => c.customerID));
        }
        public ActionResult Edit(int Id)
        {
            
            var customer = customerList.Where(c => c.customerID == Id).FirstOrDefault();

            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer cust)
        {
            var customer = customerList.Where(c => c.customerID == cust.customerID).FirstOrDefault();
            customerList.Remove(customer);
            customerList.Add(cust);
            foreach(Customer custo in customerList)
            {
                Console.WriteLine(custo);
            }
           
            return RedirectToAction("Index");


        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Customer cust)
        {

            customerList.Add(cust);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int Id)
        {
            var customer = customerList.Where(c => c.customerID == Id).FirstOrDefault();

            return View(customer); 
        }
       
        public ActionResult Delete(int Id)
        {
            Customer customer = customerList.Where(c => c.customerID == Id).FirstOrDefault();

            x = customer;
              return View(customer);



        }
        [HttpPost]
        public ActionResult Delete()
        {
            customerList.Remove(x);
            return RedirectToAction("Index");

        }
    }
}