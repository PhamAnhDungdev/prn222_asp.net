using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodInjectionPatternDemo.Model
{
    internal class Employee
    {
        public int EmployeeId;
        public string EmployeeName;
        private IDepartment _employeeDept;
        public Employee(){}

        public Employee(int employeeId, string employeeName)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
        }

        public void AssignDepartment(IDepartment department)
        {
            _employeeDept = department ?? throw new ArgumentNullException("Null");
        }

        public override string ToString()
        {
            return $"EmpID: {EmployeeId}, EmpName: {EmployeeName}" + $"Department: {_employeeDept.DeptName}";
        }
    }
}
