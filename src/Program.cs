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
            Inventory.AddMaterial(new Material("Cimento", 0.5), 20);
        }
    }
}
