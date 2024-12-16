using System;
using System.Collections.Generic;
using Business_Tier;
using CustomExceptions;
using Object_Tier;

namespace Presentation_Tier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company.RegisterClient(Client.CreateClient("Hugo Cruz", 967333980));
            Company.RegisterClient(Client.CreateClient("Ana Silva", 914567890));
            Company.RegisterClient(Client.CreateClient("Carlos Martins", 912345678));

            // Funcionários
            Company.RegistEmployee(new Employee("Antonio Mendes", "Pedreiro", 8.1));
            Company.RegistEmployee(new Employee("Joana Almeida", "Carpinteira", 9.5));
            Company.RegistEmployee(new Employee("Rui Costa", "Eletricista", 7.8));

            // Materiais
            Company.RegisterMaterial(new Material("Cimento", 4.8), 8);
            Company.RegisterMaterial(new Material("Tijolo", 0.5), 500);
            Company.RegisterMaterial(new Material("Madeira", 12.0), 20);

            // Projetos
            Company.RegistProject(new Project(Status.NotStart));
            Company.RegistProject(new Project(Status.InProgress));
            Company.RegistProject(new Project(Status.Completed));

            Company.AddClientToProject(300,500);
            Company.AddClientToProject(300,501);
            Company.AddClientToProject(300,502);
            //Company

            Company.AddClientToProject(301, 500);
            Company.AddClientToProject(302, 501);



            Company.SaveAllData();
            Company.LoadAllData();

        }
    }
}
