using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperJobWPF
{
    public class Employee 
    {        
        public string Name { get; set; }

        public string LastName { get; set; }

        public Department EmployeeDep { get; set; }

        public string GetDepName 
        { 
            get { return EmployeeDep?.DepName; }
            set { EmployeeDep = new Department(value); } 
        }
    }
}
