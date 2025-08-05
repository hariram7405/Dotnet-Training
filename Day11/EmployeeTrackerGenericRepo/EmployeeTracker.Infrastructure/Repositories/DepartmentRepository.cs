using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTracker.Core.Interfaces;
using EmployeeTracker.Core.Entities;

namespace EmployeeTracker.Infrastructure.Repositories
{
   public class DepartmentRepository:IDepartmentRepository
    {
        private readonly List<Department> _departments=new();
      public  void Add(Department entity) {
            _departments.Add(entity);

        }
        public void Update(Department entity)
        {
            var deptid = GetById(entity.DeptId);
            if (deptid != null)
            {
                deptid.DeptId=entity.DeptId;
                deptid.DeptName = entity.DeptName;
            }
            else
            {
                Console.WriteLine("Invalid Id");
            }
        }
        public void Delete(int id)
        {
            var deptid = GetById(id);
            if (deptid != null)
            {
                _departments.Remove(deptid);
            }
            else
            {
                Console.WriteLine("Invalid Id");
            }
        }
        public Department? GetById(int id)
        {
            return _departments.FirstOrDefault(t => t.DeptId == id);
        }
        public IEnumerable<Department> GetAll()
        {
            return _departments;
        }
        public int  Counts()
        {
            return _departments.Count;
        }

        public void Display()
        {
            if (_departments == null)
            {
                Console.WriteLine("Departments list is Empty");
            }
            else
            {
                Console.WriteLine("\n--- Department List ---\n");
                Console.WriteLine("{0,-10} {1,-20}", "Dept ID", "Department Name");
                Console.WriteLine(new string('-', 35));

                foreach (var dept in _departments)
                {
                    Console.WriteLine("{0,-10} {1,-20}", dept.DeptId, dept.DeptName);
                }
            }
        }

    }
}
