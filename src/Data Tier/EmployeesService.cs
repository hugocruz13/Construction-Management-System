/*
*	<copyright file="Data_Layer.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>12/5/2024 5:26:04 PM</date>
*	<description></description>
**/
using CustomExceptions;
using Object_Tier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Data_Tier
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 12/5/2024 5:26:04 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [Serializable]
    class EmployeesService
    {
        #region Attributes
        static EmployeesService instance;
        static Dictionary<int, List<int>> employees;
        #endregion

        #region Methods

        #region Properties
        public static EmployeesService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeesService();
                }

                return instance;
            }
        }
        #endregion

        #region Constructors
        protected EmployeesService()
        {
            employees = new Dictionary<int, List<int>>(17);
        }

        #endregion

        #region OtherMethods
        public bool ExistExistEmployee(int projectId, int employeeId)
        {
            return employees[projectId].Contains(employeeId);
        }

        public bool AddEmployee(int projectId, int employeeId)
        {
            if (!employees.ContainsKey(projectId))
            {
                employees[projectId] = new List<int>(5);
            }

            if (!ExistExistEmployee(projectId, employeeId))
            {
                employees[projectId].Add(employeeId);
                return true;
            }

            return false;
        }

        public bool RemoveEmployee(int projectId, int employeeId)
        {
            if (employees.ContainsKey(projectId))
            {
                if (ExistExistEmployee(projectId, employeeId))
                {
                    employees[projectId].Remove(employeeId);
                    return true;
                }
            }

            return false;
        }

        public bool Save(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ConfigurationErrorException("Caminho invalido");
            }

            try
            {
                Stream fs = new FileStream(path, FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, employees);
                fs.Close();
                employees.Clear();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Algo aconteceu ");
            }

        }


        public bool Load(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ConfigurationErrorException("Caminho invalido");
            }
            try
            {
                Stream s = File.Open(path, FileMode.Open, FileAccess.Read);
                BinaryFormatter b = new BinaryFormatter();
                employees = (Dictionary<int, List<int>>)b.Deserialize(s);
                s.Close();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Algo aconteceu ");
            }

        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~EmployeesService()
        {
        }
        #endregion

        #endregion

    }
}
