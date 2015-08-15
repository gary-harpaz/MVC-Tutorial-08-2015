using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Lab1.Models;
using Lab1.ViewModels;
using System.Web.Mvc.Html;

namespace Lab1.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Test/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public string GetString()
        {
            return "Hello World is old now. It&rsquo;s time for wassup bro ;)";
        }

        public ActionResult Index()
        {
//            List<Employee> employess = new List<Employee>();

            //Employee emp = new Employee();
            //emp.FirstName = "Sukesh";
            //emp.LastName = "Marla";
            //emp.Salary = 20000;

            //employess.Add(emp);

            //emp = new Employee();
            //emp.FirstName = "Gary";
            //emp.LastName = "Harpaz";
            //emp.Salary = 12000;

            //employess.Add(emp);

            //emp = new Employee();
            //emp.FirstName = "Suzy";
            //emp.LastName = "Bracha";
            //emp.Salary = 10000;
            //employess.Add(emp);


            List<Employee3> employess = new List<Employee3>();

            using (var dc = new NDBContext())
            {
                employess = dc.Employees.ToList();
            }

            var employessvm = new EmployeesViewModel();
            employessvm.Employees = employess.Select(e => new EmployeeViewModel(e)).ToList();
            employessvm.UserName = "Admin";

            




            return View("Index", employessvm);
        }


        public ActionResult AddNew()
        {
            return View("CreateEmployee", new CreateEmployeeViewModel());
        }

        public ActionResult SaveEmployee(Employee3 e, string BtnSubmit)
        {
          
            switch (BtnSubmit)
            {

                case "Save Employee":
                    this.Validate(e);
                    if (ModelState.IsValid)
                    {
                      //  return RedirectToAction("Index");
                        using (var dc = new NDBContext())
                        {
                            dc.Save(e);
                        }
                        return RedirectToAction("Index");
                        
                    }
                    else
                    {

                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                        vm.FirstName = e.FirstName;
                        vm.LastName = e.LastName;
                       // if (e.Salary.HasValue)
                      //  {
                            vm.Salary = e.Salary.ToString();
                      //  }
                     //   else
                     //   {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                    //    }
                        return View("CreateEmployee", vm); // Day 4 Change - Passing e here
                    }
                    //return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
                   
                    return RedirectToAction("Index");
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            return new EmptyResult();
        }


    }
}