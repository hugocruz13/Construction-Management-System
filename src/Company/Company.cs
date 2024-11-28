/*
*	<copyright file="Company.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/12/2024 3:49:53 PM</date>
*	<description></description>
**/

using System;

namespace trabalhoPOO_23010
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
        #region Attributes
        /// <summary>
        /// Static instance of the <c>Clients</c> class, managing the company's clients.
        /// </summary>
        static Clients clients;

        /// <summary>
        /// Static instance of the <c>MaterialInventory</c> class, managing the company's inventory of materials.
        /// </summary>
        static MaterialInventory inventory;

        /// <summary>
        /// Static instance of the <c>Employees</c> class, managing the company's employees.
        /// </summary>
        static Employees employees;

        /// <summary>
        /// Static instance of the <c>Projects</c> class, managing the company's projects.
        /// </summary> 
        static Projects projects;
        
        /// <summary>
        /// 
        /// </summary>
        static Materials materials;

        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Overrides
        #endregion

        #region OtherMethods


        #region Clients
        public static short RegistClient(Client client) 
        {
            short idClient = Clients.AddClient(client);
            return idClient;
        }

        public static bool ExistClient(short idClient)
        {
            bool exist = Clients.ClientExists(idClient);
            return exist;
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

        #region Employee
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

        public static void ShowEmployees(short idEmployee)
        {
            Employees.ShowEmployees(idEmployee);
        }

        public static bool UpdateRole(short idEmployee, string role, double priceHourly)
        {
            bool update = Employees.UpdateRole(idEmployee, role, priceHourly);
            return update;
        }
        #endregion

        #region Employees

        #endregion

        #endregion

        #region Destructor
        /// <summary>
        /// The destroyer of the Company class.
        /// </summary>
        ~Company()
        {
        }
        #endregion

        #endregion

    }

}
