using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Business_Tier;
using CustomExceptions;
using Object_Tier;

namespace Presentation_Tier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //bool tester;

            Company.LoadAllData(@"C:\Data\data.dat");


            //try
            //{
            //    Company.RegisterClient(Client.CreateClient("Luis VSKI", 7432324));
            //    Company.RegisterClient(Client.CreateClient("Dani Cruz", 324));
            //    Company.RegisterClient(Client.CreateClient("Hugo Cruz", 24));
            //    Company.RegisterClient(Client.CreateClient("DJ8", 34234));
            //}
            //catch (Exception ex)
            //{
            //    string e = ex.Message;
            //}


            //try
            //{
            //    Company.RegistEmployee(Employee.CreateEmployee("Ze Pereira", "Contrutor", 7.3));
            //    Company.RegistEmployee(Employee.CreateEmployee("Ze Ribeiro", "Contrutor", 5.3));
            //    Company.RegistEmployee(Employee.CreateEmployee("Chico da Tina", "Contrutor", 6.3));
            //    Company.RegistEmployee(Employee.CreateEmployee("Yuri", "Contrutor", 9.3));
            //}
            //catch (Exception ex)
            //{
            //    string e = ex.Message;
            //}
            //try
            //{
            //    Company.RegisterMaterial(Material.CreateMaterial("Cimento", 4.8), 20);
            //    Company.RegisterMaterial(Material.CreateMaterial("Cola", 3.1), 72);
            //    Company.RegisterMaterial(Material.CreateMaterial("Ferro", 12), 10);
            //    Company.RegisterMaterial(Material.CreateMaterial("Tubos", 60.3), 17);
            //}
            //catch (Exception ex)
            //{
            //    string e = ex.Message;
            //}


            Company.RegistProject(Project.CreateProject(Status.NotStart));
            //Company.UpdateStatusProject(300, Status.OnHold);
            //Company.AddClientToProject(300, 500);
            //Company.AddClientToProject(300, 501);
            //Company.AddEmployeeToProject(300, 200);
            //Company.AddEmployeeToProject(300, 201);
            //Company.UseMaterial(300, 901, 17);
            //Company.UseMaterial(300, 903, 17);

            //Company.SaveAllData(@"C:\Data\data.dat");


            //Company.RegisterMaterial(Material.CreateMaterial("tt", 3.1), 18);
            //Company.RegistEmployee(Employee.CreateEmployee("dsasdaf", "Cosdantrutor", 8.3));
            //Company.RegisterClient(Client.CreateClient("DsdJ8", 3422334));
            //Company.RegistProject(Project.CreateProject(Status.NotStart));
            //Company.RegistEmployee(Employee.CreateEmployee("Ze Pereira", "Contrutor", 7.3));




            //Company.UseMaterial(300, 900, 19);
            //Company.UseMaterial(300, 900, 1);

            //Company.CloseProject(300);



        }
    }
}
