/*
*	<copyright file="Data_Layer.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>12/5/2024 5:26:04 PM</date>
*	<description></description>
**/
using CustomExceptions;
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
    public class EmployeesService
    {
        #region Attributes
        static Dictionary<int, List<int>> employees;
        #endregion

        #region Methods

        #region Constructors

        static EmployeesService()
        {
            employees = new Dictionary<int, List<int>>(17);
        }

        #endregion

        #region OtherMethods
        public static bool AddEmployee(int projectId, int clientId)
        {
            if (!employees.ContainsKey(projectId))
            {
                employees[projectId] = new List<int>(5);
            }

            if (!ExistEmployee(projectId, clientId))
            {
                employees[projectId].Add(clientId);
                return true;
            }

            return false;
        }

        public static bool ExistEmployee(int projectId, int employeeId)
        {
            if (!employees.ContainsKey(projectId))
            {
                throw new Execeptions("Project não existe");
            }

            return employees[projectId].Contains(employeeId);
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
