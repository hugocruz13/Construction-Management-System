/*
*	<copyright file="Company.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/12/2024 3:49:53 PM</date>
*	<description></description>
**/
using System;
using CustomExceptions;
using Object_Tier;
using Data_Tier;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

namespace Business_Tier
{

    public class Company
    {
        #region Files
        public static bool SaveAllData(string path)
        {
            Data data = new Data();
            data.CollectData();

            if (data == null)
            {
                throw new ConfigurationErrorException("550");
            }

            Stream fs = new FileStream(path, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fs, data);
            fs.Close();
            return true;
        }

        public static bool LoadAllData()
        {
            Data data = new Data();
            string x = @"C:\data\data.dat";

            Stream s = File.Open(x, FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            data = (Data)b.Deserialize(s);
            s.Close();

            data.PutData();

            return true;
        }
        #endregion

        #region Clients
        public static int RegisterClient(Client client)
        {
            if (client == null)
            {
                throw new ConfigurationErrorException("Client cannot be null");
            }

            if (Clients.Instance.ExistClient(client))
            {
                throw new ConfigurationErrorException("Client already exists.");
            }

            try
            {
                return Clients.Instance.AddClient(client);
            }

            catch (Exception ex)
            {
                throw new ConfigurationErrorException("Error occurred while adding the client", ex);
            }
        }

        public static bool DeleteClient(int idClient)
        {
            return Clients.Instance.RemoveClient(idClient);
        }

        public static bool IsClientRegistered(int idClient)
        {
            return Clients.Instance.ExistClient(idClient);
        }

        public static bool UpdateClientContact(int idClient, int contact)
        {
            if (contact < 9)
            {
                throw new ConfigurationErrorException("The contact information must be at least 9 characters long");
            }

            if (!Clients.Instance.ExistClient(idClient))
            {
                throw new ConfigurationErrorException("Client not found.");
            }

            try
            {
                return Clients.Instance.UpdateContact(idClient, contact);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("Error occurred while adding the client", ex);
            }
        }

        public static Client GetClientById(int idClient)
        {
            if (!Clients.Instance.ExistClient(idClient))
            {
                throw new ConfigurationErrorException("Client not found.");
            }

            try
            {
                return Clients.Instance.GetClient(idClient);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("Error occurred while adding the client", ex);
            }
        }
        #endregion

        #region Employees
        public static int RegistEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ConfigurationErrorException("Employee cannot be null");
            }

            if (Employees.Instance.EmployeeExist(employee))
            {
                throw new ConfigurationErrorException("Employee already exists");
            }

            try
            {
                return Employees.Instance.AddEmployee(employee);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("Error occurred while adding the employee", ex);
            }
        }

        public static bool DeleteEmployee(int idEmployee)
        {
            return Employees.Instance.RemoveEmployee(idEmployee);
        }
        public static bool IsEmployeeRegistered(int idEmployee)
        {
            return Employees.Instance.EmployeeExist(idEmployee);
        }

        public static bool UpdateEmployeeRole(int idEmployee, string role, double priceHourly)
        {
            if (!Employees.Instance.EmployeeExist(idEmployee))
            {
                throw new ConfigurationErrorException("The employee does not exist in the system.");
            }

            if (role == string.Empty)
            {
                throw new ConfigurationErrorException("The role cannot be empty");
            }

            if (priceHourly <= 0)
            {
                throw new ConfigurationErrorException("Hourly price must be greater than zero.");
            }

            try
            {
                return Employees.Instance.UpdateRole(idEmployee, role, priceHourly);
            }

            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while updating the employee's role.", ex);
            }
        }

        public static Employee GetEmployeeById(int idEmployee)
        {
            if (!Employees.Instance.EmployeeExist(idEmployee))
            {
                throw new ConfigurationErrorException("The employee does not exist in the system.");
            }

            try
            {
                return Employees.Instance.GetEmployee(idEmployee);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("Error occurred while adding the employee", ex);
            }
        }
        #endregion

        #region Materials
        public static int RegisterMaterial(Material material, int quantity)
        {
            int idM = AddMaterialToCatalog(material);
            int idMI = AddMaterialToInventory(idM, quantity);
            return idMI;
        }

        internal static int AddMaterialToCatalog(Material material)
        {
            if (material == null)
            {
                throw new ConfigurationErrorException("The material cannot be null.");
            }

            if (Materials.Instance.MaterialExist(material))
            {
                throw new ConfigurationErrorException("The material is already registered in the system.");
            }

            try
            {
                int idM = Materials.Instance.AddMaterial(material);

                return idM;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the material to the inventory.", ex);
            }
        }

        internal static int AddMaterialToInventory(int idMaterial, int quantity)
        {
            if (MaterialInventory.Instance.VerifyMaterialExistence(idMaterial))
            {
                throw new ConfigurationErrorException("The material already exists in the inventory.");
            }

            try
            {

                int idMI = MaterialInventory.Instance.AddMaterial(MaterialQuantity.CreateMaterialQuantity(idMaterial, quantity));
                return idMI;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the material to the inventory.", ex);
            }
        }

        public static bool IsMaterialRegistered(int idMaterial)
        {
            bool exist = Materials.Instance.MaterialExist(idMaterial);

            if (exist)
            {
                exist = MaterialInventory.Instance.VerifyMaterialExistence(idMaterial);
                return exist;
            }

            return exist;
        }

        public static bool UpdateStock(int idMaterial, int quantity)
        {
            if (quantity < 0)
            {
                throw new ConfigurationErrorException("The quantity cannot be negative.");
            }

            if (!MaterialInventory.Instance.VerifyMaterialExistence(idMaterial))
            {
                throw new ConfigurationErrorException("The material already exists in the inventory.");
            }

            try
            {
                bool update = MaterialInventory.Instance.UpdateQuantity(idMaterial, quantity);
                return update;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the material quantity in the inventory.", ex);
            }

        }

        public static bool UpdatePrice(int idMaterial, double price)
        {
            if (price < 0)
            {
                throw new ConfigurationErrorException("The price cannot be negative.");
            }

            if (!Materials.Instance.MaterialExist(idMaterial))
            {
                throw new ConfigurationErrorException("The material already exists.");
            }

            try
            {
                bool update = Materials.Instance.UpdatePrice(idMaterial, price);
                return update;
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the material price.", ex);
            }

        }
        #endregion

        #region Projects
        ////Close project 
        ////Calcular custos do project 

        public static int RegistProject(Project project)
        {
            if (project == null)
            {
                throw new ConfigurationErrorException("The project object cannot be null.");
            }

            if (Projects.Instance.ProjectExists(project))
            {
                throw new ConfigurationErrorException("A project with the same details already exists.");
            }

            try
            {
                System.Threading.Thread.Sleep(500);
                int idProject = Projects.Instance.AddProject(project);
                return idProject;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while trying to register the project.", ex);
            }
        }

        public static bool IsProjectRegistered(int idProject)
        {
            bool r = Projects.Instance.ProjectExists(idProject);
            return r;
        }

        #region Clients
        public static bool AddClientToProject(int idProject, int idClient)
        {
            if (!Projects.Instance.ProjectExists(idProject))
            {
                throw new ConfigurationErrorException("The specified project does not exist.");
            }

            if (!Clients.Instance.ExistClient(idClient))
            {
                throw new ConfigurationErrorException("Client does not exist.");
            }

            try
            {
                bool result = Projects.Instance.AddClient(idProject, idClient);
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while trying to add the client to the project.", ex);
            }

        }

        public static bool RemoveClientToProject(int idProject, int idClient)
        {
            if (!Projects.Instance.ProjectExists(idProject))
            {
                throw new ConfigurationErrorException("");
            }

            if (!Clients.Instance.ExistClient(idClient))
            {
                throw new ConfigurationErrorException("Client does not exist.");
            }

            try
            {
                bool r = Projects.Instance.RemoveClient(idProject, idClient);
                return r;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }
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


    }

}
