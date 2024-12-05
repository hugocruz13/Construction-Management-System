using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


using Object_Tier;
using Business_Tier;
using CustomExceptions;

namespace Presentation_Tier
{
    internal class Program
    {
        //Documentos binario  /Documento text para defenir o caminho 
        static void Main(string[] args)
        {
            bool x;

            try
            {
                short idC1 = Company.RegisterClient(new Client(" Hugo Cruz  ", "967333980"));
                short idC2 = Company.RegisterClient(new Client("  hip crUZ  ", "966003884"));
                //short idC3 = Company.RegisterClient(new Client("  hip crUZ  ", "966003884"));
                //short idC3 = Company.RegisterClient(new Client(null);
                short idC4 = Company.RegisterClient(new Client("  Carlos Francisco  ", "9672378432"));

               
            }

            catch (Execeptions ex)
            {
                Console.WriteLine($"Business Logic Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }


            x = Company.IsClientRegistered(500);
            x = Company.IsClientRegistered(506);

            try
            {
                //x = Company.UpdateClientContact(500, "");
                //x = Company.UpdateClientContact(501, "967333");
                x = Company.UpdateClientContact(500, "966003885");
                x = Company.UpdateClientContact(501, "967333980");
                x = Company.UpdateClientContact(502, "666879876");
                x = Company.UpdateClientContact(503, "46567889677786");
            }
            catch (Execeptions ex)
            {
                Console.WriteLine($"Business Logic Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }




            //short idE1 = Company.RegistEmployee(new Employee("  Antonio Mendes", " Pedreiro   ", 5.6));
            //short idE2 = Company.RegistEmployee(new Employee("Augusto Mendes", "Madereiro", 6.2));
            //short idE5 = Company.RegistEmployee(new Employee("Augusto Mendes", "Madereiro", 6.2));
            //short idE3 = Company.RegistEmployee(new Employee("Ricardo Alves", "Madereiro", 7.2));
            //short idE4 = Company.RegistEmployee(new Employee("Zezinho", "Pedreiro", 5.3));
            //x = Company.UpdateEmployeeRole(200, "Calceteiro", 5.7);
            //x = Company.UpdateEmployeeRole(207, "Calceteiro", 5.7);
            //x = Company.ExistEmployee(213);
            //x = Company.ExistEmployee(201);
            //Company.ShowEmployees();


            //Materials.MaterialExist(900);
            //Materials.MaterialExist(907);
            //Materials.UpdatePrice(900, 5.2);
            //Materials.UpdatePrice(907, 5.2);
            //Materials.ShowMaterials();

            try
            {
                short idM1 = Company.RegisterMaterial(new Material("Cimento", 4.8), 7);
                short idM2 = Company.RegisterMaterial(new Material("Areia", 3.2), 15);
                short idM3 = Company.RegisterMaterial(new Material("Brita", 5.1), 10);
                short idM4 = Company.RegisterMaterial(new Material("Cal", 2.5), 20);
                short idM5 = Company.RegisterMaterial(new Material("Tijolo", 1.0), 200);
                //short idM6= Company.RegisterMaterial(null, 200);

            }
            catch (Execeptions ex)
            {
                Console.WriteLine($"Business Logic Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }

            //Company.ExistMaterial(idM13);
            //Company.ExistMaterial(917);
            //Company.UpdateStock(912, 10);
            //Company.UpdateStock(917, 10);
            //Company.UseMaterial(912, 10);
            //Company.UseMaterial(917, 10);
            //Company.ShowMaterial();
            //Company.ShowInventoryQuantity();


            //CLOSE PROJECT REVER Object_Tier

            short idP1 = Company.RegistProject(new Project(Status.InProgress));
            Company.AddClientToProject(300, 500);


            //Company.AddEmployeeToProject(307, idE1);
            //Company.AddEmployeeToProject(300, idE1);
            //Company.AddEmployeeToProject(300, idE2);
            //Company.UseMaterial(300, idM2, 5);
            //Company.UseMaterial(300, idM3, 17);
            //Company.UseMaterial(305, idM4, 20);
            //Company.ShowEmployees();
            //Company.CloseProject(300);


            short idP2 = Company.RegistProject(new Project(Status.InProgress));
            Company.AddClientToProject(301, 501);
            Company.AddClientToProject(301, 500);
            Company.AddClientToProject(301, 500);
            Company.Existe(301, 500);
            //Company.AddEmployeeToProject(301, idE3);
            //Company.AddEmployeeToProject(301, idE4);
            //Company.AddEmployeeToProject(301, idE2);
            //Company.AddClientToProject(300, idC2);
            //Company.ShowEmployees();
        }
    }
}
