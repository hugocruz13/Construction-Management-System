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
using System.Collections.Generic;

namespace Data_Tier
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 12/5/2024 5:26:04 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    class EmployeesService
    {
        #region Attributes
        static EmployeesService instance;
        Dictionary<int, List<int>> employees;
        #endregion

        #region Methods

        #region Constructors
        protected EmployeesService()
        {
            employees = new Dictionary<int, List<int>>(17);
        }

        #endregion

        #region OtherMethods
        public static EmployeesService Instance() 
        {
            if (instance == null)
            {
                instance = new EmployeesService();
            }
            return instance;
        }

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
