using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


using Object_Layer;
using Business_Logic_Layer;
using CustomExceptions;

namespace trabalhoPOO_23010
{
    internal class Program
    {
        //Documentos binario  /Documento text para defenir o caminho 
        static void Main(string[] args)
        {

            try
            {
                short idC1 = Company.RegistClient(new Client(" Hugo Cruz  ", "967333980"));
                short idC3 = Company.RegistClient(new Client(" Hugo Cruz  ", "967333980"));
                short idC2 = Company.RegistClient(new Client("  hip crUZ  ", "966003884"));
                short idC4 = Company.RegistClient(null);
            }

            catch (Execeptions ex)
            {
                Console.WriteLine($"Business Logic Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }


            bool x = Company.ExistClient(500);
            x = Company.ExistClient(506);


            short idE1 = Company.RegistEmployee(new Employee("  Antonio Mendes", " Pedreiro   ", 5.6));
            short idE2 = Company.RegistEmployee(new Employee("Augusto Mendes", "Madereiro", 6.2));
            short idE5 = Company.RegistEmployee(new Employee("Augusto Mendes", "Madereiro", 6.2));
            short idE3 = Company.RegistEmployee(new Employee("Ricardo Alves", "Madereiro", 7.2));
            short idE4 = Company.RegistEmployee(new Employee("Zezinho", "Pedreiro", 5.3));
            //x = Company.UpdateRole(200, "Calceteiro", 5.7);
            //x = Company.UpdateRole(207, "Calceteiro", 5.7);
            //x = Company.ExistEmployee(213);
            //x = Company.ExistEmployee(201);
            //Company.ShowEmployees();


            //Materials.MaterialExist(900);
            //Materials.MaterialExist(907);
            //Materials.UpdatePrice(900, 5.2);
            //Materials.UpdatePrice(907, 5.2);
            //Materials.ShowMaterials();

            short idM1 = Company.RegistMaterial("Cimento", 4.8, 7);
            short idM2 = Company.RegistMaterial("Areia", 3.2, 15);
            short idM3 = Company.RegistMaterial("Brita", 5.1, 10);
            short idM4 = Company.RegistMaterial("Cal", 2.5, 20);
            short idM5 = Company.RegistMaterial("Tijolo", 1.0, 200);
            //short idM6 = Company.RegistMaterial("Bloco", 1.8, 150);
            //short idM7 = Company.RegistMaterial("Azulejo", 3.5, 30);
            //short idM8 = Company.RegistMaterial("Piso", 4.0, 25);
            //short idM9 = Company.RegistMaterial("Madeira", 12.0, 50);
            //short idM10 = Company.RegistMaterial("Telha", 9.5, 40);
            //short idM11 = Company.RegistMaterial("Viga", 7.5, 20);
            //short idM12 = Company.RegistMaterial("Tubo", 5.5, 70);
            //short idM13 = Company.RegistMaterial("Arame", 0.8, 300);
            //Company.ExistMaterial(idM13);
            //Company.ExistMaterial(917);
            //Company.UpdateStock(912, 10);
            //Company.UpdateStock(917, 10);
            //Company.UseMaterial(912, 10);
            //Company.UseMaterial(917, 10);
            //Company.ShowMaterial();
            //Company.ShowInventoryQuantity();


            //CLOSE PROJECT REVER Object_Layer

            short idP1 = Company.RegistProject(new Project(Status.InProgress));
            //Company.AddClientToProject(300, idC1);
            Company.AddEmployeeToProject(307, idE1);
            Company.AddEmployeeToProject(300, idE1);
            Company.AddEmployeeToProject(300, idE2);
            Company.UseMaterial(300, idM2, 5);
            Company.UseMaterial(300, idM3, 17);
            Company.UseMaterial(305, idM4, 20);
            Company.ShowEmployees();
            Company.CloseProject(300);


            short idP2 = Company.RegistProject(new Project(Status.InProgress));
            Company.AddEmployeeToProject(301, idE3);
            Company.AddEmployeeToProject(301, idE4);
            Company.AddEmployeeToProject(301, idE2);
            //Company.AddClientToProject(300, idC2);
            //Company.ShowEmployees();
        }
    }
}
