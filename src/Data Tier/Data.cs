/*
*	<copyright file="Data_Tier.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>12/17/2024 5:09:50 PM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using Object_Tier;
using CustomExceptions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Data_Tier
{
    /// <summary>
    /// The `Data` class serves as a centralized data manager for the application. 
    /// It collects data from various parts of the system, organizes it into lists, 
    /// and provides methods for saving to and loading from a binary file.
    /// </summary>
    [Serializable]
    public class Data
    {
        /// <summary>
        /// List of clients in the system.
        /// </summary>
        List<Client> clients = null;

        /// <summary>
        /// List of employees in the system.
        /// </summary>
        List<Employee> employees = null;

        /// <summary>
        ///List of materials available in the system.
        /// </summary>
        List<Material> materials = null;

        /// <summary>
        /// List of current material inventory, including quantities and dates.
        /// </summary>
        List<MaterialQuantity> inventory = null;


        /// <summary>
        /// List of projects managed in the system.
        /// </summary>
        List<ProjectData> projects;

        /// <summary>
        /// Collects data from various system modules and stores it in the class
        /// </summary>
        /// <returns>Returns `true` if the data is collected successfully.</returns>
        /// <exception cref="ConfigurationErrorException">Thrown if data collection fails.</exception>
        public bool CollectData()
        {
            try
            {
                clients = Clients.Instance.ClientsD;
                employees = Employees.Instance.EmployeesD;
                materials = Materials.Instance.MaterialD;
                inventory = MaterialInventory.Instance.InventoryD;
                projects = Projects.Instance.ProjectsD;
                return true;
            }
            catch (Exception)
            {
                throw new ConfigurationErrorException("700");
            }
        }

        /// <summary>
        /// Updates the system modules with the data stored in the class's lists.
        /// </summary>
        /// <returns>Returns `true` if the data is successfully updated.</returns>
        /// <exception cref="Exception">Thrown if updating data fails.</exception>
        public bool PutData()
        {
            try
            {
                Clients.Instance.ClientsD = clients;
                Employees.Instance.EmployeesD = employees;
                MaterialInventory.Instance.InventoryD = inventory;
                Materials.Instance.MaterialD = materials;
                Projects.Instance.ProjectsD = projects;
                SetCounterEqual();

                return true;
            }
            catch (Exception)
            {
                throw new Exception("701");
            }

        }

        /// <summary>
        /// Synchronizes ID counters across all modules to maintain consistency.
        /// </summary>
        /// <returns>Returns `true` after synchronization.</returns>
        bool SetCounterEqual()
        {
            Clients.Instance.SetCounterEqualClient();
            Employees.Instance.SetCounterEqualEmployee();
            Materials.Instance.SetCounterEqualMaterial();
            Projects.Instance.SetCounterEqualProjects();

            return true;
        }

        /// <summary>
        /// Saves the current data to a binary file at the specified path.
        /// </summary>
        /// <param name="path">The file path where the data will be saved.</param>
        /// <returns>Returns `true` if the data is successfully saved.</returns>
        /// <exception cref="ConfigurationErrorException">Thrown if an error occurs during data saving.</exception>
        public static bool SaveData(string path)
        {
            try
            {
                Data data = new Data();

                if (!data.CollectData())
                {
                    throw new ConfigurationErrorException("702");
                }

                Stream fs = new FileStream(path, FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, data);
                fs.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("705" + ex.Message);
            }

        }

        /// <summary>
        /// Loads data from a binary file and updates the system with the loaded data.
        /// </summary>
        /// <param name="path">The file path from where the data will be loaded.</param>
        /// <returns>Returns `true` if the data is successfully loaded and updated.</returns>
        /// <exception cref="ConfigurationErrorException">Thrown if an error occurs during data loading.</exception>
        public static bool LoadData(string path)
        {
            try
            {
                Data data = new Data();
                Stream s = File.Open(path, FileMode.Open, FileAccess.Read);
                BinaryFormatter b = new BinaryFormatter();
                data = (Data)b.Deserialize(s);
                s.Close();

                if (!data.PutData())
                {
                    throw new Exception("700");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("706" + ex.Message);
            }

        }


        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Data()
        {
        }
        #endregion
    }
}
