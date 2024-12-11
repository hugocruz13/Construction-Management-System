/*
*	<copyright file="Company.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/12/2024 3:49:53 PM</date>
*	<description></description>
**/

using CustomExceptions;
using Data_Tier;
using Object_Tier;
using System;
using System.Collections.Generic;

namespace Business_Tier
{

    public class Company
    {

        #region Clients
        public static short RegisterClient(Client client)
        {
            if (client == null)
            {
                throw new ConfigurationErrorException("Client cannot be null");
            }

            if (Clients.Instance().ExistClient(client))
            {
                throw new ConfigurationErrorException("Customer already exists");
            }

            try
            {
                short idClient = Clients.Instance().AddClient(client);
                return idClient;
            }

            catch (Exception ex)
            {
                throw new ConfigurationErrorException("Error occurred while adding the client", ex);
            }
        }

        public static bool IsClientRegistered(short idClient)
        {
            bool exist = Clients.Instance().ExistClient(idClient);
            return exist;
        }

        public static bool UpdateClientContact(short idClient, int contact)
        {
            if (contact < 9)
            {
                throw new ConfigurationErrorException("The contact information must be at least 9 characters long");
            }

            try
            {
                bool update = Clients.Instance().UpdateContact(idClient, contact);
                return update;
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("Error occurred while adding the client", ex);
            }
        }
        #endregion

        #region Employees
        public static short RegistEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ConfigurationErrorException("Employee cannot be null");
            }

            if (Employees.Instance().EmployeeExist(employee))
            {
                throw new ConfigurationErrorException("Employee already exists");
            }

            try
            {
                short idEmployee = Employees.Instance().AddEmployee(employee);
                return idEmployee;
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("Error occurred while adding the employee", ex);
            }
        }

        public static bool IsEmployeeRegistered(short idEmployee)
        {
            bool exist = Employees.Instance().EmployeeExist(idEmployee);
            return exist;
        }

        public static bool UpdateEmployeeRole(short idEmployee, string role, double priceHourly)
        {
            if (!Employees.Instance().EmployeeExist(idEmployee))
            {
                throw new ConfigurationErrorException("The employee does not exist in the system.");
            }

            if (role == string.Empty || priceHourly <= 0)
            {
                throw new ConfigurationErrorException("The role cannot be empty, and the hourly price must be greater than zero.");
            }

            try
            {
                bool update = Employees.Instance().UpdateRole(idEmployee, role, priceHourly);
                return update;
            }

            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while updating the employee's role.", ex);
            }
        }

        #endregion 

        #region Materials
        public static short RegisterMaterial(Material material, int quantity)
        {
            short idM = AddMaterialToCatalog(material);
            short idMI = AddMaterialToInventory(idM, quantity);
            return idMI;
        }

        internal static short AddMaterialToCatalog(Material material)
        {
            if (material == null)
            {
                throw new ConfigurationErrorException("The material cannot be null.");
            }

            if (Materials.Instance().MaterialExist(material))
            {
                throw new ConfigurationErrorException("The material is already registered in the system.");
            }

            try
            {
                short idM = Materials.Instance().AddMaterial(material);
                
                return idM;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the material to the inventory.", ex);
            }
        }

        internal static short AddMaterialToInventory(short idMaterial, int quantity)
        {
            if (MaterialInventory.Instance().VerifyMaterialExistence(idMaterial))
            {
                throw new ConfigurationErrorException("The material already exists in the inventory.");
            }

            try
            {
               
                short idMI = MaterialInventory.Instance().AddMaterial(new MaterialQuantity(idMaterial, quantity));
                return idMI;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the material to the inventory.", ex);
            }
        }


        public static bool IsMaterialRegistered(short idMaterial)
        {
            bool exist = Materials.Instance().MaterialExist(idMaterial);

            if (exist)
            {
                exist = MaterialInventory.Instance().VerifyMaterialExistence(idMaterial);
                return exist;
            }

            return exist;
        }

        public static bool UpdateStock(short idMaterial, int quantity)
        {
            if (quantity < 0)
            {
                throw new ConfigurationErrorException("The quantity cannot be negative.");
            }

            if (!MaterialInventory.Instance().VerifyMaterialExistence(idMaterial))
            {
                throw new ConfigurationErrorException("The material already exists in the inventory.");
            }

            try
            {
                bool update = MaterialInventory.Instance().UpdateQuantity(idMaterial, quantity);
                return update;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the material quantity in the inventory.", ex);
            }

        }

        public static bool UpdatePrice(short idMaterial, double price)
        {
            if (price < 0)
            {
                throw new ConfigurationErrorException("The price cannot be negative.");
            }

            if (!Materials.Instance().MaterialExist(idMaterial))
            {
                throw new ConfigurationErrorException("The material already exists.");
            }

            try
            {
                bool update = Materials.Instance().UpdatePrice(idMaterial, price);
                return update;
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the material price.", ex);
            }

        }
        #endregion

        #region Projects
        public static short RegistProject(Project project)
        {
            if (project == null)
            {
                throw new ConfigurationErrorException("The project object cannot be null.");
            }

            if (Projects.Instance().ProjectExists(project))
            {
                throw new ConfigurationErrorException("A project with the same details already exists.");
            }

            try
            {
                System.Threading.Thread.Sleep(500); 
                short idProject = Projects.Instance().AddProject(project);
                return idProject;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while trying to register the project.", ex);
            }
        }

        public static bool IsProjectRegistered(short idProject)
        {
            bool r = Projects.Instance().ProjectExists(idProject);
            return r;
        }

        #region Clients
        public static bool AddClientToProject(short idProject, short idClient)
        {
            if (!Projects.Instance().ProjectExists(idProject))
            {
                throw new ConfigurationErrorException("The specified project does not exist.");
            }

            //if (!Clients.ExistClient(idClient))
            //{
            //    throw new ConfigurationErrorException("The specified client does not exist.");
            //}

            try
            {
                bool result = Projects.Instance().AddClient(idProject, idClient);
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while trying to add the client to the project.", ex);
            }

        }

        public static bool RemoveClientToProject(short idProject, short idClient)
        {
            if (!Projects.Instance().ProjectExists(idProject))
            {
                throw new ConfigurationErrorException("");
            }

            //if (!Clients.ExistClient(idClient))
            //{
            //    throw new ConfigurationErrorException("");
            //}

            try
            {
                bool r = Projects.Instance().RemoveClient(idProject, idClient);
                return r;
            }
            catch(Exception ex) 
            {
                throw new Exception("", ex);
            }
        }
        #endregion


        //Close project 
        //Calcular custos do project 
        #endregion

        #region Files
        //public static bool SaveClients() 
        //{
        //    bool t = Clients.Save(@"C:\s\s.dat");
        //    return t;
        //}

        //public static bool LoadClients()
        //{
        //    bool t = Clients.Load(@"C:\s\s.dat");
        //    return t;
        //}
        #endregion

        #region Destructor
        /// <summary>
        /// The destroyer of the Company class.
        /// </summary>
        ~Company()
        {
        }
        #endregion


    }

}
