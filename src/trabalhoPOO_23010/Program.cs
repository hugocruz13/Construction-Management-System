using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhoPOO_23010
{
    internal class Program
    {
        /// FORMATAR A STRING 
        /// APENAS NO REGISTO PRINCIPAL É que recebo o id depois trabalhar com o ID.

        static void Main(string[] args)
        {
            bool x;

            short idC1 = Company.RegistClient(new Client(" Hugo Cruz  ", "967333980"));
            short idC2 = Company.RegistClient(new Client("  hip crUZ  ", "966003884"));
            short idC3 = Company.RegistClient(new Client("  hip crUZ  ", "966003884"));
            Clients.ClientExists(502);
            Clients.ClientExists(501);
            Clients.ShowClients();
            Clients.UpdateContact(507, "967333890");
            Clients.UpdateContact(501, "966003885");



            short idE1 = Company.RegistEmployee(new Employee("  Antonio Mendes", " Pedreiro   ", 5.6));
            short idE2 = Company.RegistEmployee(new Employee("Augusto Mendes", "Madereiro", 6.2));
            short idE3 = Company.RegistEmployee(new Employee("    Augusto Mendes", "Madereiro", 6.2));
            x = Company.UpdateRole(200, "Calceteiro", 5.7);
            x = Company.UpdateRole(207, "Calceteiro", 5.7);
            x = Company.ExistEmployee(213);
            x = Company.ExistEmployee(201);
            Company.ShowEmployees();
            Company.ShowEmployees(201);

            short idM1 = Materials.AddMaterial(new Material("Cimento", 4.80));
            short idM2 = Materials.AddMaterial(new Material("Cola", 3.2));
            Materials.MaterialExist(900);
            Materials.MaterialExist(907);
            Materials.UpdatePrice(900, 5.2);
            Materials.UpdatePrice(907, 5.2);
            Materials.ShowMaterials(900);
            Materials.ShowMaterials();



        }
    }
}
