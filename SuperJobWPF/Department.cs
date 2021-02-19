using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperJobWPF
{    
    public class Department : IComparable
    {        
        public string DepName { get; set; }

        public Department(string DepName)
        {
            this.DepName = DepName;
        }

        public override string ToString()
        {
            return DepName;
        }
        
        public int CompareTo(object obj)
        {
            return string.Compare(this.DepName, (obj as Department)?.DepName);
        }

        public Department()
        {

        }
    }
}
