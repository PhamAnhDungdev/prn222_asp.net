using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyInjectionPatternDemo.Model
{
    public class Employee
    {
        public int EmployeeId;
        public string EmployeeName;
        private IDepartment _employeeDept;
        public Employee(int employeeId, string employeeName)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
        }

        public IDepartment EmployeeDept
        {
            get {
                if (this._employeeDept == null) {
                    this.EmployeeDept = new Engineering();
                }
                return this._employeeDept; 
            } 
            set { 
                if ( value == null)
                {
                    throw new ArgumentException("Null");
                }
                if (this._employeeDept != null)
                {
                    throw new InvalidOperationException();
                }
                this.EmployeeDept = value;
            }
        }
        public override string ToString()
        {
            return $"EmpID: {EmployeeId}, EmpName: {EmployeeName}" + $"Department: {_employeeDept.DeptName}";
        }
    }
}
