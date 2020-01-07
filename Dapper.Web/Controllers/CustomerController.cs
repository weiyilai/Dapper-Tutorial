using Dapper.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Dapper.Web.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> customers = new List<Customer>();
            using (IDbConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["TutorialConnection"].ConnectionString))
            {
                customers = db.Query<Customer>("Select * From Customers").ToList();
            }
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            Customer customer = new Customer();
            using (IDbConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["TutorialConnection"].ConnectionString))
            {
                customer = db.Query<Customer>("Select * From Customers WHERE CustomerID =" + id, new { id }).SingleOrDefault();
            }
            return View(customer);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["TutorialConnection"].ConnectionString))
                {
                    string sqlQuery = "Insert Into Customers (FirstName, LastName, Email) Values(@FirstName, @LastName, @Email)";

                    int rowsAffected = db.Execute(sqlQuery, customer);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer customer = new Customer();
            using (IDbConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["TutorialConnection"].ConnectionString))
            {
                customer = db.Query<Customer>("Select * From Customers WHERE CustomerID =" + id, new { id }).SingleOrDefault();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["TutorialConnection"].ConnectionString))
                {
                    string sqlQuery = "UPDATE Customers set FirstName='" + customer.FirstName +
                        "',LastName='" + customer.LastName +
                        "',Email='" + customer.Email +
                        "' WHERE CustomerID=" + customer.CustomerID;

                    int rowsAffected = db.Execute(sqlQuery);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Customer customer = new Customer();
            using (IDbConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["TutorialConnection"].ConnectionString))
            {
                customer = db.Query<Customer>("Select * From Customers WHERE CustomerID =" + id, new { id }).SingleOrDefault();
            }
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["TutorialConnection"].ConnectionString))
                {
                    string sqlQuery = "Delete From Customers WHERE CustomerID = " + id;

                    int rowsAffected = db.Execute(sqlQuery);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}