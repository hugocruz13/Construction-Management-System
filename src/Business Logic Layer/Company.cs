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

namespace Business_Tier
{

    public class Company
    {

        #region Clients
        public static short RegisterClient(Client client)
        {
            if (client == null)
            {
                throw new Execeptions("Client cannot be null");
            }

            if (Clients.ExistClient(client))
            {
                throw new Execeptions("Customer already exists");
            }

            try
            {
                short idClient = Clients.AddClient(client);
                return idClient;
            }

            catch (Exception ex)
            {
                throw new Execeptions("Error occurred while adding the client", ex);
            }


        }

        public static bool UpdateClientContact(short idClient, string contact)
        {
            if (contact == string.Empty)
            {
                throw new Execeptions("Contact information cannot be an empty sequence");
            }

            if (contact.Length < 9)
            {
                throw new Execeptions("The contact information must be at least 9 characters long");
            }

            try
            {
                bool update = Clients.UpdateContact(idClient, contact);
                return update;
            }
            catch (Exception ex)
            {
                throw new Execeptions("Error occurred while adding the client", ex);
            }
        }

        public static bool IsClientRegistered(short idClient)
        {
            bool exist = Clients.ExistClient(idClient);
            return exist;
        }

        public static void DisplayAllClients()
        {
            Clients.ShowClients();
        }

        #endregion

        #region Employees EM FALTA ERROS
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

        public static bool UpdateEmployeeRole(short idEmployee, string role, double priceHourly)
        {
            bool update = Employees.UpdateRole(idEmployee, role, priceHourly);
            return update;
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
                throw new Execeptions("The material cannot be null.");
            }

            if (Materials.MaterialExist(material))
            {
                throw new Execeptions("The material is already registered in the system.");
            }

            try
            {
                short idM = Materials.AddMaterial(material);
                return idM;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the material to the inventory.", ex);
            }
        }

        internal static short AddMaterialToInventory(short idMaterial, int quantity)
        {
            if (MaterialInventory.VerifyMaterialExistence(idMaterial))
            {
                throw new Execeptions("The material already exists in the inventory.");
            }

            try
            {
                short idMI = MaterialInventory.AddMaterial(new MaterialQuantity(idMaterial, quantity));
                return idMI;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the material to the inventory.", ex);
            }
        }


        public static bool ExistMaterial(short idMaterial) // continuar
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
            if (Clients.ExistClient(idClient))
            {
                bool r = ClientsService.AddClient(idProject, idClient);
                return r;
            }

            return false;
        }

        public static bool Existe(short idProject, short idClient)
        {
            if (Clients.ExistClient(idClient))
            {
                bool r = ClientsService.ExistClient(idProject, idClient);
                return r;
            }
            return false;
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
