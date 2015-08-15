using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab1.Models;

namespace Lab1.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel(Employee emp)
        {
            EmployeeName = emp.FirstName + " " + emp.LastName;
            Salary = emp.Salary.ToString("C");
            if (emp.Salary > 15000)
            {
                SalaryColor = "yellow";
            }
            else
            {
                SalaryColor = "green";
            }
        }
        public EmployeeViewModel(Employee2 emp)
        {
            EmployeeName = emp.FirstName + " " + emp.LastName;
            Salary = emp.Salary.ToString("C");
            if (emp.Salary > 15000)
            {
                SalaryColor = "yellow";
            }
            else
            {
                SalaryColor = "green";
            }
        }
        public EmployeeViewModel(Employee3 emp)
        {
            EmployeeName = emp.FirstName + " " + emp.LastName;
            Salary = emp.Salary.ToString("C");
            if (emp.Salary > 15000)
            {
                SalaryColor = "yellow";
            }
            else
            {
                SalaryColor = "green";
            }
        }
        public string EmployeeName { get; set; }
        public string Salary { get; set; }
        public string SalaryColor { get; set; }
      //  public string UserName { get; set; }
    }
}