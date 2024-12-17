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
            //bool tester;

            ////try
            ////{
            //int c1 = Company.RegisterClient(Client.CreateClient("Ana Silva", 912345678));//500
            //int c2 = Company.RegisterClient(Client.CreateClient("Pedro Almeida", 963258741));//501
            //int c3 = Company.RegisterClient(Client.CreateClient("Maria Costa", 987654321));//502
            //int c4 = Company.RegisterClient(Client.CreateClient("João Pereira", 934567890));//503
            //int c5 = Company.RegisterClient(Client.CreateClient("Carlos Souza", 915678234));//504
            //////                                                                                //    //int c6 = Company.RegisterClient(Client.CreateClient("Carlos Souza", 915678234));//Erro
            //////                                                                                //    // int c7 = Company.RegisterClient(null);//Erro

            ////////}
            ////////catch (ConfigurationErrorException ex)
            ////////{
            ////////    string businessError = ex.Message;
            ////////}
            ////////catch (Exception ex)
            ////////{
            ////////    string error = ex.Message;
            ////////}

            ////////////tester = Company.DeleteClient(500);
            ////////////tester = Company.DeleteClient(520);

            ////////////tester = Company.IsClientRegistered(502);
            ////////////tester = Company.IsClientRegistered(515);

            //////////try
            //////////{
            //////////    Client c = Company.GetClientById(503);
            //////////    //Client c1 = Company.GetClientById(503); //Erro
            //////////}
            //////////catch (ConfigurationErrorException ex)
            //////////{
            //////////    string businessError = ex.Message;
            //////////}
            //////////catch (Exception ex)
            //////////{
            //////////    string error = ex.Message;
            //////////}



            ////////try
            ////////{
            ////////    tester = Company.UpdateClientContact(502, 968555830);
            ////////    //tester = Company.UpdateClientContact(512,968555830); //Erro

            ////////}
            ////////catch (ConfigurationErrorException ex)
            ////////{
            ////////    string businessError = ex.Message;
            ////////}
            ////////catch (Exception ex)
            ////////{
            ////////    string error = ex.Message;
            ////////}


            ////////try
            ////////{
            //int e1 = Company.RegistEmployee(Employee.CreateEmployee("Ana Silva", "Manager", 30.0));
            //int e2 = Company.RegistEmployee(Employee.CreateEmployee("Pedro Almeida", "Developer", 25.0));
            //int e3 = Company.RegistEmployee(Employee.CreateEmployee("Maria Costa", "Designer", 22.5));
            //int e4 = Company.RegistEmployee(Employee.CreateEmployee("João Pereira", "Tester", 20.0));
            //int e5 = Company.RegistEmployee(Employee.CreateEmployee("Carlos Souza", "Developer", 28.0));
            ////////    // int e6 = Company.RegisterEmployee(Employee.CreateEmployee("Carlos Souza", "Developer", 28.0)); // Error (Duplicate)
            ////////    // int e7 = Company.RegisterEmployee(null); // Error (Null)
            ////////}
            ////////catch (ConfigurationErrorException ex)
            ////////{
            ////////    string businessError = ex.Message;
            ////////}
            ////////catch (Exception ex)
            ////////{
            ////////    string error = ex.Message;
            ////////}

            ////////tester = Company.DeleteEmployee(201);
            ////////tester = Company.DeleteEmployee(220);

            ////////tester = Company.IsEmployeeRegistered(203);
            ////////tester = Company.IsEmployeeRegistered(271);

            ////////try
            ////////{
            ////////    Employee e = Company.GetEmployeeById(200);
            ////////    //Employee e1 = Company.GetEmployeeById(201);  // Error
            ////////}
            ////////catch (ConfigurationErrorException ex)
            ////////{
            ////////    string businessError = ex.Message;
            ////////}
            ////////catch (Exception ex)
            ////////{
            ////////    string error = ex.Message;
            ////////}

            ////////try
            ////////{
            ////////    tester = Company.UpdateEmployeeRole(204, "Senior Developer", 35.0);
            ////////    tester = Company.UpdateEmployeeRole(246, "Lead Developer", 40.0); // Error (Employee doesn't exist)
            ////////}
            ////////catch (ConfigurationErrorException ex)
            ////////{
            ////////    string businessError = ex.Message;
            ////////}
            ////////catch (Exception ex)
            ////////{
            ////////    string error = ex.Message;
            ////////}


            //////Company.RegisterMaterial(Material.CreateMaterial("Cimento", 4.8), 25);
            //////Company.UpdateStock(900, 30);

            //Company.RegisterMaterial(Material.CreateMaterial("Cimento", 4.8), 8);
            //Company.RegisterMaterial(Material.CreateMaterial("Arroz", 4.8), 8);
            //Company.RegisterMaterial(Material.CreateMaterial("Cola", 4.8), 8);


            //Company.RegistProject(new Project(Status.Completed));
            //Company.RegistProject(new Project(Status.InProgress));


            ////Company.AddClientToProject(300,500);

            //Company.SaveAllData(@"C:\data\data.dat");
            Company.LoadAllData();

            Company.RegisterClient(Client.CreateClient("h", 222));
            Company.RegistEmployee(Employee.CreateEmployee("VSKI","PEDRE",27.1));
            Company.RegisterMaterial(Material.CreateMaterial("csasad", 21.2), 12);
            Company.RegistProject(Project.CreateProject(Status.OnHold));
        }
    }
}
