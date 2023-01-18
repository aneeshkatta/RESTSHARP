using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1RestSharp
{
    internal class Employees
    {
        public int id;
        public string name;
        public int salary;
        public Employees(string name,int salary)
        {
            this.name = name;
            this.salary = salary;
        }      
    }
}
