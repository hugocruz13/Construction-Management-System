using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Projects.AddProject(new Project());
            Projects.AddProject(new Project());
            Projects.AddEmployee(300, new Employee("hugo", "teste", 7.5));
            Projects.AddEmployee(300, new Employee("anti", "teste", 7.5));
            Projects.AddEmployee(301, new Employee("sd", "teste", 7.5));
            Projects.AddClient(300,new Client("Hugo", "73246"));
            Projects.AddClient(301,new Client("df", "7dfdsf6"));
            Projects.ChangeStatus(301, Status.Completed);


        }
    }
}
