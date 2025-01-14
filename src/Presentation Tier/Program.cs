/*
*	<copyright file="Company.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/12/2024 3:49:53 PM</date>
*	<description></description>
**/

using Business_Tier;
using CustomExceptions;
using Object_Tier;
using System;

namespace Presentation_Tier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool t = false;

            #region LoadData
            try
            {
                Company.LoadAllData(@"C:\Data\data.dat");
            }
            catch (ConfigurationErrorException ex)
            {
                string msg = ex.Message;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            #endregion

            #region RegistClient
            try
            {
                //int c1 = Company.RegisterClient(Client.CreateClient("João Lima", 306272228));//500
                //int c2 = Company.RegisterClient(Client.CreateClient("Ana Costa", 445590028));//501
                //int c3 = Company.RegisterClient(Client.CreateClient("Tiago Souza", 554878030));//502
                //int c4 = Company.RegisterClient(Client.CreateClient("Cláudia Lima", 121452875));//503
                //int c5 = Company.RegisterClient(Client.CreateClient("Luís Mendes", 626051462));//504

                int c1 = Company.RegisterClient(Client.CreateClient("Pedro Martins", 123456789));//505
                int c2 = Company.RegisterClient(Client.CreateClient("Rita Silva", 987654321));//506
                int c3 = Company.RegisterClient(Client.CreateClient("Bruno Costa", 192837465));//507
                int c4 = Company.RegisterClient(Client.CreateClient("Carla Ferreira", 564738291));//508
                int c5 = Company.RegisterClient(Client.CreateClient("Miguel Oliveira", 837291546));//509

            }
            catch (ConfigurationErrorException ex)
            {
                string msg = ex.Message;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            #endregion

            #region RegistEmployee
            try
            {
                //int e1 = Company.RegistEmployee(Employee.CreateEmployee("João Lima", "Pedreiro", 6.4));//200
                //int e2 = Company.RegistEmployee(Employee.CreateEmployee("Ana Costa", "Engenheira Civil", 6.4));//201
                //int e3 = Company.RegistEmployee(Employee.CreateEmployee("Tiago Souza", "Mestre de Obras", 6.4));//202
                //int e4 = Company.RegistEmployee(Employee.CreateEmployee("Cláudia Lima", "Técnica de Segurança", 6.4));//203
                //int e5 = Company.RegistEmployee(Employee.CreateEmployee("Luís Mendes", "Carpinteiro", 6.4));//204

                int e1 = Company.RegistEmployee(Employee.CreateEmployee("Pedro Martins", "Eletricista", 6.4));//205
                int e2 = Company.RegistEmployee(Employee.CreateEmployee("Rita Silva", "Arquiteta", 6.4));//206
                int e3 = Company.RegistEmployee(Employee.CreateEmployee("Bruno Costa", "Pintor", 6.4));//207
                int e4 = Company.RegistEmployee(Employee.CreateEmployee("Carla Ferreira", "Encanadora", 6.4));//208
                int e5 = Company.RegistEmployee(Employee.CreateEmployee("Miguel Oliveira", "Gesseiro", 6.4));//209

            }
            catch (ConfigurationErrorException ex)
            {
                string msg = ex.Message;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            #endregion

            #region RegistMaterial
            try
            {
                //int m1 = Company.RegisterMaterial(Material.CreateMaterial("Cimento", 4.80), 20);//900
                //int m2 = Company.RegisterMaterial(Material.CreateMaterial("Cola", 7.80), 17);//901
                //int m3 = Company.RegisterMaterial(Material.CreateMaterial("Areia", 3.50), 15);//902
                //int m4 = Company.RegisterMaterial(Material.CreateMaterial("Tijolos", 0.80), 100);//903
                //int m5 = Company.RegisterMaterial(Material.CreateMaterial("Aditivo", 10.20), 50);//904

                int m1 = Company.RegisterMaterial(Material.CreateMaterial("Betão", 5.00), 25);//905
                int m2 = Company.RegisterMaterial(Material.CreateMaterial("Fita Adesiva", 2.50), 30);//906
                int m3 = Company.RegisterMaterial(Material.CreateMaterial("Gravilha", 4.00), 18);//907
                int m4 = Company.RegisterMaterial(Material.CreateMaterial("Blocos de Concreto", 1.20), 90);//908
                int m5 = Company.RegisterMaterial(Material.CreateMaterial("Isolamento Térmico", 8.50), 40);//909

            }
            catch (ConfigurationErrorException ex)
            {
                string msg = ex.Message;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            #endregion

            #region ManageProject1

            try
            {  
                //300
                t = Company.AddClientToProject(300, 507); //Add client 500 to the project  
                t = Company.AddEmployeeToProject(300, 206); //Add employee 200 to the project
                t = Company.AddEmployeeToProject(300, 205); //Add employee 201 to the project
                t = Company.UseMaterial(300, 907, 3); //Use 17 of quantity material 900 in project 300 
                t = Company.UseMaterial(300, 905, 20); //Use 72 of quantity material 903 in project 300 
            }
            catch (ConfigurationErrorException ex)
            {
                string msg = ex.Message;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            #endregion

            #region ManageProject2
            try
            {
                //301
                t = Company.AddClientToProject(301, 503); //Add client 503 to the project  
                t = Company.AddClientToProject(301, 505); //Add client 505 to the project  
                t = Company.AddEmployeeToProject(301, 203); //Add employee 203 to the project
                t = Company.AddEmployeeToProject(301, 202); //Add employee 202 to the project
                t = Company.UseMaterial(301, 902, 12); //Use 12 of quantity material 900 in project 300 
                t = Company.UseMaterial(301, 900, 3); //Use 3 of quantity material 903 in project 300 

            }
            catch (ConfigurationErrorException ex)
            {
                string msg = ex.Message;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            #endregion

            #region SaveData
            try
            {
                Company.SaveAllData(@"C:\Data\data.dat");
            }
            catch (ConfigurationErrorException ex)
            {
                string msg = ex.Message;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            #endregion

        }
    }
}
