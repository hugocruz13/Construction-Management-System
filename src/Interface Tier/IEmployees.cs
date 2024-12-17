using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Object_Tier;

namespace Interface_Tier
{
    public interface IEmployees
    {
        int AddEmployee(Employee employee);
        bool RemoveEmployee(int idEmployee);
        bool EmployeeExist(int idEmployee);
        bool UpdateRole(int idEmployee, string role, double hourly);
        Employee GetEmployee(int idEmployee);
        bool Save(string path);
        bool Load(string path);
    }
}
