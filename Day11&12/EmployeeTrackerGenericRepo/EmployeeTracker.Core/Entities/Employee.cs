using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Core.Entities
{
public class Employee
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Designation {  get; set; }
        public int DepartmentId {  get; set; }
        public decimal Salary {  get; set; }

    }
}
