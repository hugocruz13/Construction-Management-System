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
            Employee p1 = new Employee("Hugo", "Engineering", 12.4);
            Employee p2 = new Employee();
            Employee p3 = new Employee();

            Material m1 = new Material();
            Material m2 = new Material();
            Material m3 = new Material();


            Storage.AddMaterial(m1);
            Storage.AddMaterial(m2);
            Storage.AddMaterial(m3);

        }
    }
}
