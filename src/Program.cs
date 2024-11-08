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
            Project.Id = 600;
            Project.Status = Status.NotStart;
            Project.Client = new Client("Antonio", "964563928");
            Project.AddEmployee("Dj8", "Eletricista", 4.5);
            Project.AddEmployee("Guita Pimpolho", "Pedreiro", 4.8);
            Project.AddMaterial(new Material("Cimento", 4.80), 5);
            Project.AddMaterial(new Material("Cola", 6), 2);
            Project.AddMaterial(new Material("Tijolos", 0.37), 200);

        }
    }
}
