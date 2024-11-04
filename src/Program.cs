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
            Employee p1 = new Employee();
            Employee p2 = new Employee();
            Employee p3 = new Employee();
            Client c1 = new Client();   
            Project project = new Project("RUA DA POVOA",c1, Status.Cancelled, 3);
            project.PutEmployee(p1);
            project.PutEmployee(p1);

       
        }
    }
}
