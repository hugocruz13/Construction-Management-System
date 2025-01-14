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
using System.IO;

namespace Business_Tier
{
    /// <summary>
    /// The Enterprise class manages operations related to customers employees, materials and 
    /// projects.It handles tasks such as registration, update and removal, manages project states 
    /// and resource usage.Ensures proper validation and exception handling for each action.
    /// </summary>
    public class Company
    {
        #region Files

        /// <summary>
        /// Saves all application data to the specified file path.
        /// </summary>
        /// <param name="path">The file path where the data will be saved.</param>
        /// <returns>Returns `true` if the data is saved successfully.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Thrown if the data cannot be collected or the file operation fails.
        /// </exception>
        public static bool SaveAllData(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException("703");
                }

                return Data.SaveData(path);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("700" + ex);
            }
        }

        /// <summary>
        /// Loads all application data from the specified file path.
        /// </summary>
        /// <param name="path">The file path from which the data will be loaded.</param>
        /// <returns>Returns `true` if the data is loaded successfully.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Thrown if the file does not exist, data deserialization fails, or data cannot be updated in the system.
        /// </exception>
        public static bool LoadAllData(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    throw new ConfigurationErrorException("703");
                }

                return Data.LoadData(path);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("701 " + ex);
            }
        }
        #endregion

        #region Clients

        /// <summary>
        /// Registers a new client in the system.
        /// </summary>
        /// <param name="client">The client object to be registered.</param>
        /// <returns>The unique ID of the newly registered client.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "106" if the client object is null.
        /// Throws "107" if the client already exists in the system.
        /// Throws "108" for any unexpected error during registration.
        /// </exception>
        public static int RegisterClient(Client client)
        {
            if (client.Name == string.Empty)
            {
                throw new ConfigurationErrorException("116");
            }

            if (client == null)
            {
                throw new ConfigurationErrorException("106");
            }

            if (Clients.Instance.ExistClient(client))
            {
                throw new ConfigurationErrorException("107");
            }

            try
            {
                return Clients.Instance.AddClient(client);
            }

            catch (Exception ex)
            {
                throw new ConfigurationErrorException("108" + ex);
            }
        }

        /// <summary>
        /// Deletes an existing client based on their unique ID.
        /// </summary>
        /// <param name="idClient">The ID of the client to be removed.</param>
        /// <returns>True if the client was successfully deleted.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "112" if the client does not exist.
        /// Throws "109" for any unexpected error during deletion.
        /// </exception>
        public static bool DeleteClient(int idClient)
        {
            if (!Clients.Instance.ExistClient(idClient))
            {
                throw new ConfigurationErrorException("112");
            }

            try
            {
                return Clients.Instance.RemoveClient(idClient);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("109" + ex);
            }
        }

        /// <summary>
        /// Checks whether a client is registered in the system using their unique ID.
        /// </summary>
        /// <param name="idClient">The ID of the client to check.</param>
        /// <returns>True if the client is registered, false otherwise.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "109" for any unexpected error during the operation.
        /// </exception>
        public static bool IsClientRegistered(int idClient)
        {
            try
            {
                return Clients.Instance.ExistClient(idClient);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("110" + ex);
            }
        }

        /// <summary>
        /// Updates the contact information of an existing client.
        /// </summary>
        /// <param name="idClient">The ID of the client whose contact information needs updating.</param>
        /// <param name="contact">The new contact number.</param>
        /// <returns>True if the update was successful.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "111" if the contact number is invalid
        /// Throws "112" if the client does not exist.
        /// Throws "113" for any unexpected error during the update.
        /// </exception>
        public static bool UpdateClientContact(int idClient, int contact)
        {
            if (contact < 9)
            {
                throw new ConfigurationErrorException("111");
            }

            if (!Clients.Instance.ExistClient(idClient))
            {
                throw new ConfigurationErrorException("112");
            }

            try
            {
                return Clients.Instance.UpdateContact(idClient, contact);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("113" + ex);
            }
        }

        /// <summary>
        /// Retrieves the details of a specific client using their unique ID.
        /// </summary>
        /// <param name="idClient">The ID of the client to retrieve.</param>
        /// <returns>A Client object containing the client’s details.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "112" if the client does not exist.
        /// Throws "114" for any unexpected error during retrieval.
        /// </exception>
        public static Client GetClientById(int idClient)
        {
            if (!Clients.Instance.ExistClient(idClient))
            {
                throw new ConfigurationErrorException("112");
            }
            try
            {
                return Clients.Instance.GetClient(idClient);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("114" + ex);
            }
        }
        #endregion

        #region Employees
        /// <summary>
        /// Registers a new employee in the system.
        /// </summary>
        /// <param name="employee">The employee object to be registered.</param>
        /// <returns>The unique ID of the newly registered employee.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "405" if the employee object is null.
        /// Throws "407" if the employee already exists in the system.
        /// Throws "408" for any unexpected error during registration.
        /// </exception>
        public static int RegistEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ConfigurationErrorException("405");
            }

            if (Employees.Instance.EmployeeExist(employee))
            {
                throw new ConfigurationErrorException("407");
            }

            try
            {
                return Employees.Instance.AddEmployee(employee);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("408" + ex);
            }
        }

        /// <summary>
        /// Deletes an existing employee based on their unique ID.
        /// </summary>
        /// <param name="idEmployee">The ID of the employee to be removed.</param>
        /// <returns>True if the employee was successfully deleted.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "412" if the employee does not exist.
        /// Throws "409" for any unexpected error during deletion.
        /// </exception>
        public static bool DeleteEmployee(int idEmployee)
        {

            if (!Employees.Instance.EmployeeExist(idEmployee))
            {
                throw new ConfigurationErrorException("412");
            }
            try
            {
                return Employees.Instance.RemoveEmployee(idEmployee);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("409" + ex);
            }
        }

        /// <summary>
        /// Checks whether an employee is registered in the system using their unique ID.
        /// </summary>
        /// <param name="idEmployee">The ID of the employee to check.</param>
        /// <returns>True if the employee is registered, false otherwise.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "410" for any unexpected error during the operation.
        /// </exception>
        public static bool IsEmployeeRegistered(int idEmployee)
        {
            try
            {
                return Employees.Instance.EmployeeExist(idEmployee);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("410" + ex);
            }

        }

        /// <summary>
        /// Updates the role and hourly price of an existing employee.
        /// </summary>
        /// <param name="idEmployee">The ID of the employee whose role and price need updating.</param>
        /// <param name="role">The new role of the employee.</param>
        /// <param name="priceHourly">The new hourly price for the employee.</param>
        /// <returns>True if the update was successful.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "412" if the employee does not exist.
        /// Throws "411" if the role is empty.
        /// Throws "413" if the hourly price is less than or equal to zero.
        /// Throws "414" for any unexpected error during the update.
        /// </exception>
        public static bool UpdateEmployeeRole(int idEmployee, string role, double priceHourly)
        {
            if (!Employees.Instance.EmployeeExist(idEmployee))
            {
                throw new ConfigurationErrorException("412");
            }

            if (role == string.Empty)
            {
                throw new ConfigurationErrorException("411");
            }

            if (priceHourly <= 0)
            {
                throw new ConfigurationErrorException("413");
            }

            try
            {
                return Employees.Instance.UpdateRole(idEmployee, role, priceHourly);
            }

            catch (Exception ex)
            {
                throw new ConfigurationErrorException("414" + ex);
            }
        }

        /// <summary>
        /// Retrieves the details of a specific employee using their unique ID.
        /// </summary>
        /// <param name="idEmployee">The ID of the employee to retrieve.</param>
        /// <returns>An Employee object containing the employee’s details.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "412" if the employee does not exist.
        /// Throws "415" for any unexpected error during retrieval.
        /// </exception>
        public static Employee GetEmployeeById(int idEmployee)
        {
            if (!Employees.Instance.EmployeeExist(idEmployee))
            {
                throw new ConfigurationErrorException("412");
            }

            try
            {
                return Employees.Instance.GetEmployee(idEmployee);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("415", ex);
            }
        }
        #endregion

        #region Materials

        /// <summary>
        /// Registers a material by adding it to the catalog and inventory.
        /// </summary>
        /// <param name="material">The material to be registered.</param>
        /// <param name="quantity">The initial quantity of the material.</param>
        /// <returns>The unique ID of the material in the inventory.</returns>
        public static int RegisterMaterial(Material material, int quantity)
        {
            int idM = AddMaterialToCatalog(material);
            int idMI = AddMaterialToInventory(idM, quantity);
            return idMI;
        }

        /// <summary>
        /// Adds a material to the catalog.
        /// </summary>
        /// <param name="material">The material to be added.</param>
        /// <returns>The unique ID of the material in the catalog.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "609" if the material is null.
        /// Throws "610" if the material already exists in the catalog.
        /// Throws "611" for any unexpected error during the addition process.
        /// </exception>
        internal static int AddMaterialToCatalog(Material material)
        {
            if (material == null)
            {
                throw new ConfigurationErrorException("609");
            }

            if (Materials.Instance.MaterialExist(material))
            {
                throw new ConfigurationErrorException("610");
            }

            try
            {
                int idM = Materials.Instance.AddMaterial(material);

                return idM;
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("611" + ex);
            }
        }

        /// <summary>
        /// Adds a material to the inventory with a specified quantity.
        /// </summary>
        /// <param name="idMaterial">The unique ID of the material to be added.</param>
        /// <param name="quantity">The quantity of the material to be added.</param>
        /// <returns>The unique ID of the material in the inventory.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "610" if the material already exists in the inventory.
        /// Throws "611" for any unexpected error during the addition process.
        /// </exception>
        internal static int AddMaterialToInventory(int idMaterial, int quantity)
        {
            if (MaterialInventory.Instance.VerifyMaterialExistence(idMaterial))
            {
                throw new ConfigurationErrorException("610");
            }

            try
            {
                int idMI = MaterialInventory.Instance.AddMaterial(MaterialQuantity.CreateMaterialQuantity(idMaterial, quantity));
                return idMI;
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("611" + ex);
            }
        }

        /// <summary>
        /// Checks if a material is registered in the system.
        /// </summary>
        /// <param name="idMaterial">The unique ID of the material to check.</param>
        /// <returns>True if the material is registered, false otherwise.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "612" for any unexpected error during the verification process.
        /// </exception>
        public static bool IsMaterialRegistered(int idMaterial)
        {
            try
            {
                if (Materials.Instance.MaterialExist(idMaterial))
                {
                    bool r = MaterialInventory.Instance.VerifyMaterialExistence(idMaterial);
                    return r;
                }
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("612" + ex);
            }

            return false;
        }

        /// <summary>
        /// Updates the stock quantity of a material in the inventory.
        /// </summary>
        /// <param name="idMaterial">The unique ID of the material to update.</param>
        /// <param name="quantity">The new quantity to be set.</param>
        /// <returns>True if the stock update was successful.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "613" if the quantity is less than zero.
        /// Throws "610" if the material does not exist in the inventory.
        /// Throws "614" for any unexpected error during the update process.
        /// </exception>
        public static bool UpdateStock(int idMaterial, int quantity)
        {
            if (quantity < 0)
            {
                throw new ConfigurationErrorException("613");
            }

            if (!MaterialInventory.Instance.VerifyMaterialExistence(idMaterial))
            {
                throw new ConfigurationErrorException("610");
            }

            try
            {
                bool update = MaterialInventory.Instance.UpdateQuantity(idMaterial, quantity);
                return update;
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("618" + ex);
            }

        }

        /// <summary>
        /// Updates the price of a material in the catalog.
        /// </summary>
        /// <param name="idMaterial">The unique ID of the material to update.</param>
        /// <param name="price">The new price to be set.</param>
        /// <returns>True if the price update was successful.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "615" if the price is less than zero.
        /// Throws "610" if the material does not exist in the catalog.
        /// Throws "616" for any unexpected error during the update process.
        /// </exception>
        public static bool UpdatePrice(int idMaterial, double price)
        {
            if (price < 0)
            {
                throw new ConfigurationErrorException("615");
            }

            if (!Materials.Instance.MaterialExist(idMaterial))
            {
                throw new ConfigurationErrorException("610");
            }

            try
            {
                bool update = Materials.Instance.UpdatePrice(idMaterial, price);
                return update;
            }

            catch (Exception ex)
            {
                throw new ConfigurationErrorException("614." + ex);
            }

        }

        /// <summary>
        /// Retrieves the details of a material from the catalog.
        /// </summary>
        /// <param name="idMaterial">The unique ID of the material to retrieve.</param>
        /// <returns>A Material object containing the material's details.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "616" for any unexpected error during the retrieval process.
        /// </exception>
        public static Material GetMaterial(int idMaterial)
        {
            try
            {
                return Materials.Instance.GetMaterial(idMaterial);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("616" + ex);
            }
        }

        /// <summary>
        /// Retrieves the quantity details of a material in the inventory.
        /// </summary>
        /// <param name="idMaterial">The unique ID of the material to retrieve.</param>
        /// <returns>A MaterialQuantity object containing the material's inventory details.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "616" for any unexpected error during the retrieval process.
        /// </exception>
        public static MaterialQuantity GetQuantityOfMaterial(int idMaterial)
        {
            try
            {
                return MaterialInventory.Instance.GetMaterialQuantity(idMaterial);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("616" + ex);
            }
        }

        #endregion

        #region Projects

        /// <summary>
        /// Registers a new project.
        /// </summary>
        /// <param name="project">The project to be registered.</param>
        /// <returns>The unique ID of the registered project.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "815" if the project is null.
        /// Throws "820" if the project already exists.
        /// Throws "817" for any unexpected error during the registration process.
        /// </exception>
        public static int RegistProject(Project project)
        {
            if (project == null)
            {
                throw new ConfigurationErrorException("815");
            }

            if (Projects.Instance.ProjectExists(project))
            {
                throw new ConfigurationErrorException("816");
            }

            try
            {
                System.Threading.Thread.Sleep(500);
                int idProject = Projects.Instance.AddProject(ProjectData.CreateProjectData(project));
                return idProject;
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("817" + ex);
            }
        }

        /// <summary>
        /// Checks if a project is registered in the system.
        /// </summary>
        /// <param name="idProject">The unique ID of the project.</param>
        /// <returns>True if the project is registered, false otherwise.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "818" for any unexpected error during the check process.
        /// </exception>
        public static bool IsProjectRegistered(int idProject)
        {
            try
            {
                return Projects.Instance.ProjectExists(idProject);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("818" + ex);
            }
        }

        /// <summary>
        /// Updates the status of a project.
        /// </summary>
        /// <param name="idProject">The unique ID of the project.</param>
        /// <param name="status">The new status of the project.</param>
        /// <returns>True if the status update was successful.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "819" for any unexpected error during the update process.
        /// </exception>
        public static bool UpdateStatusProject(int idProject, Status status)
        {
            try
            {
                return Projects.Instance.UpdateStatus(idProject, status);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("819" + ex);
            }
        }


        /// <summary>
        /// Closes a project.
        /// </summary>
        /// <param name="idProject">The unique ID of the project to close.</param>
        /// <returns>True if the project was successfully closed.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "819" for any unexpected error during the closing process.
        /// </exception>
        public static bool CloseProject(int idProject)
        {
            try
            {
                return Projects.Instance.CloseProject(idProject);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("819" + ex);
            }
        }

        #region Clients

        /// <summary>
        /// Adds a client to a project.
        /// </summary>
        /// <param name="idProject">The unique ID of the project.</param>
        /// <param name="idClient">The unique ID of the client to add.</param>
        /// <returns>True if the client was successfully added to the project.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "820" if the project does not exist.
        /// Throws "821" if the client does not exist.
        /// Throws "822" for any unexpected error during the addition process.
        /// </exception>
        public static bool AddClientToProject(int idProject, int idClient)
        {
            if (!Projects.Instance.ProjectExists(idProject))
            {
                throw new ConfigurationErrorException("820");
            }

            if (!Clients.Instance.ExistClient(idClient))
            {
                throw new ConfigurationErrorException("821");
            }

            try
            {
                return Projects.Instance.AddClient(idProject, idClient);

            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("822." + ex);
            }

        }

        /// <summary>
        /// Removes a client from a project.
        /// </summary>
        /// <param name="idProject">The unique ID of the project.</param>
        /// <param name="idClient">The unique ID of the client to remove.</param>
        /// <returns>True if the client was successfully removed from the project.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "820" if the project does not exist.
        /// Throws "821" if the client does not exist.
        /// Throws "823" for any unexpected error during the removal process.
        /// </exception>
        public static bool DeleteClientToProject(int idProject, int idClient)
        {
            if (!Projects.Instance.ProjectExists(idProject))
            {
                throw new ConfigurationErrorException("820");
            }

            if (!Clients.Instance.ExistClient(idClient))
            {
                throw new ConfigurationErrorException("821");
            }

            try
            {
                bool r = Projects.Instance.RemoveClient(idProject, idClient);
                return r;
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("823" + ex);
            }
        }
        #endregion

        #region Employees

        /// <summary>
        /// Adds an employee to a project.
        /// </summary>
        /// <param name="idProject">The unique ID of the project.</param>
        /// <param name="idEmployee">The unique ID of the employee to add.</param>
        /// <returns>True if the employee was successfully added to the project.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "820" if the project does not exist.
        /// Throws "824" if the employee does not exist.
        /// Throws "825" for any unexpected error during the addition process.
        /// </exception>
        public static bool AddEmployeeToProject(int idProject, int idEmployee)
        {
            if (!Projects.Instance.ProjectExists(idProject))
            {
                throw new ConfigurationErrorException("820");
            }

            if (!Employees.Instance.EmployeeExist(idEmployee))
            {
                throw new ConfigurationErrorException("824");
            }

            try
            {
                bool result = Projects.Instance.AddEmployee(idProject, idEmployee);
                return result;

            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("825" + ex);
            }

        }

        /// <summary>
        /// Removes an employee from a project.
        /// </summary>
        /// <param name="idProject">The unique ID of the project.</param>
        /// <param name="idEmployee">The unique ID of the employee to remove.</param>
        /// <returns>True if the employee was successfully removed from the project.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "820" if the project does not exist.
        /// Throws "824" if the employee does not exist.
        /// Throws "826" for any unexpected error during the removal process.
        /// </exception>
        public static bool DeleteEmplyeeToProject(int idProject, int idEmployee)
        {
            if (!Projects.Instance.ProjectExists(idProject))
            {
                throw new ConfigurationErrorException("820");
            }

            if (!Employees.Instance.EmployeeExist(idEmployee))
            {
                throw new ConfigurationErrorException("824");
            }

            try
            {
                bool r = Projects.Instance.RemoveEmployee(idProject, idEmployee);
                return r;
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("826" + ex);
            }
        }
        #endregion

        #region Material

        /// <summary>
        /// Uses a specified quantity of a material for a project.
        /// </summary>
        /// <param name="idProject">The unique ID of the project.</param>
        /// <param name="idMaterial">The unique ID of the material to use.</param>
        /// <param name="quantity">The quantity of the material to use.</param>
        /// <returns>True if the material was successfully used.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws "820" if the project does not exist.
        /// Throws "827" if the material does not exist.
        /// Throws "828" if the quantity is insufficient.
        /// Throws "829" for any unexpected error during the process.
        /// </exception>
        public static bool UseMaterial(int idProject, int idMaterial, int quantity)
        {
            if (!Projects.Instance.ProjectExists(idProject))
            {
                throw new ConfigurationErrorException("820");
            }

            if (!MaterialInventory.Instance.VerifyMaterialExistence(idMaterial))
            {
                throw new ConfigurationErrorException("827");
            }

            if (!MaterialInventory.Instance.VerifyMaterialQuantity(idMaterial, quantity))
            {
                throw new ConfigurationErrorException("828");
            }

            try
            {
                bool result = MaterialInventory.Instance.UseMaterial(idMaterial, quantity);
                bool result1 = Projects.Instance.UseMaterial(idProject, idMaterial, quantity);
                return result1;

            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("829" + ex);
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
