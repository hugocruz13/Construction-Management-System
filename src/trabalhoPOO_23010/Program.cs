using System;


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
                short idC1 = Company.RegisterClient(new Client(" Hugo Cruz  ", 967333980));
                short idC2 = Company.RegisterClient(new Client("  hip crUZ  ", 966003884));
                ////short idC3 = Company.RegisterClient(new Client("  hip crUZ  ", "966003884"));
                ////short idC3 = Company.RegisterClient(new Client(null);
                short idC4 = Company.RegisterClient(new Client("  Carlos Francisco  ", 967278432));
            }

            catch (ConfigurationErrorException  ex)
            {
                string t = ex.Message;
            }
            catch (Exception ex)
            {
                string t = ex.Message;
            }

            //Company.SaveClients();
            //Company.LoadClients();

            try
            {
                short idE1 = Company.RegistEmployee(new Employee("  Antonio Mendes", " Engenheiro Civil   ", 5.6));
                short idE2 = Company.RegistEmployee(new Employee("Augusto Mendes", "Madereiro", 6.2));
                short idE3 = Company.RegistEmployee(new Employee("Ricardo Alves", "Gerente de Obras", 7.2));
                short idE4 = Company.RegistEmployee(new Employee("Zezinho", "Arquiteto", 5.3));
                //short idE5 = Company.RegistEmployee(new Employee("Augusto Mendes", "Madereiro", 6.2));
                //short idE6 = Company.RegistEmployee(null);

            }
            catch (ConfigurationErrorException ex)
            {
                Console.WriteLine($"Business Logic Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }


            try
            {
                short idM1 = Company.RegisterMaterial(new Material("Cimento", 4.8), 7);
                short idM2 = Company.RegisterMaterial(new Material("Areia", 3.2), 15);
                short idM3 = Company.RegisterMaterial(new Material("Brita", 5.1), 10);
                short idM4 = Company.RegisterMaterial(new Material("Tijolo", 1.0), 200);
                //short idM5 = Company.RegisterMaterial(new Material("Tijolo", 1.0), 200);
                //short idM6= Company.RegisterMaterial(null, 200);
            }
            catch (ConfigurationErrorException ex)
            {
                Console.WriteLine($"Business Logic Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }

            x = Company.IsClientRegistered(500);
            x = Company.IsClientRegistered(550);
            x = Company.IsMaterialRegistered(900);
            x = Company.IsMaterialRegistered(950);
            x = Company.IsEmployeeRegistered(200);
            x = Company.IsEmployeeRegistered(250);

            try
            {
                //x = Company.UpdateClientContact(500, "");
                //x = Company.UpdateClientContact(501, "967333");
                //x = Company.UpdateClientContact(500, 966003885);
                //x = Company.UpdateClientContact(501, 967333980);
                //x = Company.UpdateClientContact(502, 666879876);
                //x = Company.UpdateClientContact(503, 465678896);
            }
            catch (ConfigurationErrorException  ex)
            {
                Console.WriteLine($"Business Logic Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }

            try
            {
                Company.UpdateStock(900, 17);
                Company.UpdateStock(901, 17);
                Company.UpdateStock(902, 17);
                //Company.UpdateStock(902, -1);
                //Company.UpdateStock(950, 17);
            }
            catch (ConfigurationErrorException ex)
            {
                Console.WriteLine($"Business Logic Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }

            try
            {

                Company.UpdatePrice(900, 3.4);
                Company.UpdatePrice(901, 4.2);
                Company.UpdatePrice(902, 1);
                Company.UpdatePrice(903, 2.4);
                //Company.UpdatePrice(903, -12.3);
                //Company.UpdatePrice(950, 3.4);
            }
            catch (ConfigurationErrorException ex)
            {
                Console.WriteLine($"Business Logic Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }

            try
            {
                Company.UpdateEmployeeRole(200, "Arquiteto", 7.6);
                Company.UpdateEmployeeRole(201, "Programador", 7.6);
                Company.UpdateEmployeeRole(202, "Supervisor de Obras", 7.6);
                Company.UpdateEmployeeRole(203, "Engenheiro Civil", 7.6);
                //Company.UpdateEmployeeRole(250, "Engenheiro Civil", 7.6);
                //Company.UpdateEmployeeRole(200, "Engenheiro Civil", -1);
                //Company.UpdateEmployeeRole(200, "", 7.8);
            }
            catch (ConfigurationErrorException ex)
            {
                Console.WriteLine($"Business Logic Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }



            try
            {
                short idP1 = Company.RegistProject(new Project(Status.InProgress));
                short idP2 = Company.RegistProject(new Project(Status.InProgress));
                
            }
            catch (ConfigurationErrorException ex)
            {
                Console.WriteLine($"Business Logic Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }


            try
            {
                Company.AddClientToProject(300, 500);
                Company.AddClientToProject(300, 501);
                Company.AddClientToProject(300, 501);
                Company.AddClientToProject(350, 501);
                Company.AddClientToProject(300, 550);
            }
            catch (ConfigurationErrorException ex)
            {
                Console.WriteLine($"Business Logic Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }

            try
            {
                Company.RemoveClientToProject(300, 500);
                Company.RemoveClientToProject(300, 501);
                Company.RemoveClientToProject(300, 501);
                Company.RemoveClientToProject(350, 501);
                Company.RemoveClientToProject(300, 550);
            }
            catch (ConfigurationErrorException ex)
            {
                Console.WriteLine($"Business Logic Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }




            //Company.AddClientToProject(300, 500);
            //Company.AddEmployeeToProject(307, idE1);
            //Company.AddEmployeeToProject(300, idE1);
            //Company.AddEmployeeToProject(300, idE2);
            //Company.UseMaterial(300, idM2, 5);
            //Company.UseMaterial(300, idM3, 17);
            //Company.UseMaterial(305, idM4, 20);
            //Company.DisplayAllEmployees();
            //Company.CloseProject(300);



            //CLOSE PROJECT REVER Object_Tier
        }
    }
}
