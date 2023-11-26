using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul13.prak2
{
    public class Employee
    {
        public string FullName;
        public int Salary;

        public Employee(string data)
        {
            var parts = data.Split(',');
            FullName = parts[0];
            Salary = int.Parse(parts[1]);
        }
    }
}
