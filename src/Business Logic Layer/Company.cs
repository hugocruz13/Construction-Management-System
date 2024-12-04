/*
*	<copyright file="Company.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/12/2024 3:49:53 PM</date>
*	<description></description>
**/

using System;
using System.Diagnostics;
using System.Xml.Linq;

using Object_Layer;
using Data_Layer;
using CustomExceptions;

namespace Business_Logic_Layer
{
    /// <summary>
    /// Represents a company with static attributes for managing clients, material inventory, employees, and projects.
    /// </summary>
    /// <remarks>
    /// The <c>Company</c> class provides a centralized, static structure for managing the core entities of a business.
    /// As all members are static, no instances are required.
    /// </remarks>
    /// <example>
    /// Example of use
    /// <code>
    /// Company.ProjectCreate; 
    /// Company.EmployeeRegister;
    /// </code>
    /// </example>
    public class Company
    {

        #region Clients
        public static short RegistClient(Client client)
        {
            if (client == null)
            {
                throw new Execeptions("Client cannot be null");
            }

            if (Clients.ClientExists(client))
            {
                throw new Execeptions("Customer already exists");
            }

            try
            {
                short idClient = Clients.AddClient(client);
                return idClient;
            }

            catch(Exception ex)
            {
                throw new Execeptions("Error occurred while adding the client", ex);
            }


        }

        public static bool ExistClient(short idClient)
        {
            try
            {
                bool exist = Clients.ClientExists(idClient);
                return exist;
            }

            catch(Exception ex)
            {
                 throw new Execeptions("Error occurred while adding the client", ex);
            }
        }

        public static void ShowClients()
        {
            Clients.ShowClients();
        }

        public static bool UpdateContact(short idClient, string contact)
        {
            bool update = Clients.UpdateContact(idClient, contact);
            return update;
        }
        #endregion

        #region Employees
        public static short RegistEmployee(Employee employee)
        {
            short idEmployee = Employees.AddEmployee(employee);
            return idEmployee;
        }

        public static bool ExistEmployee(short idEmployee)
        {
            bool exist = Employees.EmployeeExist(idEmployee);
            return exist;
        }

        public static void ShowEmployees()
        {
            Employees.ShowEmployees();
        }

        public static bool UpdateRole(short idEmployee, string role, double priceHourly)
        {
            bool update = Employees.UpdateRole(idEmployee, role, priceHourly);
            return update;
        }
        #endregion

        #region Materials
        public static short RegistMaterial(string name, double price, int quantity)
        {
            short id = Materials.AddMaterial(new Material(name, price));
            id = MaterialInventory.AddMaterial(new MaterialQuantity(id, quantity));
            return id;
        }

        public static bool ExistMaterial(short idMaterial)
        {
            bool exist = Materials.MaterialExist(idMaterial);
            exist = MaterialInventory.VerifyMaterialExistence(idMaterial);
            return exist;
        }

        public static bool UpdateStock(short idMaterial, int quantity)
        {
            bool update = MaterialInventory.UpdateQuantity(idMaterial, quantity);
            return update;
        }

        public static void ShowInventoryQuantity()
        {
            MaterialInventory.ShowInventory();
        }

        public static void ShowMaterial()
        {
            Materials.ShowMaterials();
        }
        #endregion

        #region Projects
        public static short RegistProject(Project project)
        {
            short idProject = Projects.AddProject(project);
            return idProject;
        }

        public static bool AddClientToProject(short idProject, short idClient)
        {
            if (Clients.ClientExists(idClient))
            {
                bool r = Projects.AddClientProject(idProject, idClient);
                return r;
            }

            return false;
        }

        public static bool AddEmployeeToProject(short idProject, short idEmployee)
        {
            if (Employees.EmployeeExist(idEmployee))
            {
                bool r = Projects.AddEmployeeProject(idProject, idEmployee);
                return r;
            }

            return false;
        }

        public static bool UseMaterial(short idProject, short idMaterial, int quantity)
        {
            if (MaterialInventory.UseMaterial(idMaterial, quantity))
            {
                bool r = Projects.AddMaterialProject(idProject, idMaterial, quantity);
                return r;
            }

            return false;
        }

        public static bool CloseProject(short idProject) 
        {
            Projects.Close(idProject);
            return true;
        }
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
