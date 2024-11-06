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
<<<<<<< HEAD
            Employee p1 = new Employee("Hugo", "Engineering", 12.4);
            Employee p2 = new Employee();
            Employee p3 = new Employee();

            Material m1 = new Material();
            Material m2 = new Material();
            Material m3 = new Material();


            Storage.AddMaterial(m1);
            Storage.AddMaterial(m2);
            Storage.AddMaterial(m3);
=======
            Employee p1 = new Employee();
            Employee p2 = new Employee();
            Employee p3 = new Employee();
            Client c1 = new Client();   
            Project project = new Project("RUA DA POVOA",c1, Status.Cancelled, 3);
            project.PutEmployee(p1);
            project.PutEmployee(p1);
>>>>>>> 969c9cbb8d752322acd590eca6e0194657d8a968

        }
    }
}
