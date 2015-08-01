using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1.ViewModels
{
    public class EmployeesViewModel
    {
        public EmployeesViewModel()
        {

        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private IEnumerable<EmployeeViewModel> _employees=Enumerable.Empty<EmployeeViewModel>();

        public IEnumerable<EmployeeViewModel> Employees
        {
            get
            {                
                return _employees;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _employees = value;
            }
        }
    }
}