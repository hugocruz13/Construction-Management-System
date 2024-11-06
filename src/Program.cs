using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c1 = new Client();
            Employee emp1 = new Employee();
            Employee emp2 = new Employee();
            Employee emp3 = new Employee();
            Employee emp4 = new Employee();
            Employee emp5 = new Employee();

            Project project = new Project("Rua António Lopes", 12.3, Status.InProgress, c1, 5);
            project.ADD(emp1);
            project.ADD(emp3);
            project.ADD(emp2);
            project.ADD(emp4);
            project.ADD(emp5);

        }
    }
}
