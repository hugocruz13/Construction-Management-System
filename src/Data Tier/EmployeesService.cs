/*
*	<copyright file="Data_Layer.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>12/5/2024 5:26:04 PM</date>
*	<description></description>
**/
using CustomExceptions;
using System;
using System.Collections.Generic;

namespace Data_Tier
{
    /// <summary>
    /// Class that manages employees associated with projects.
    /// </summary>
    [Serializable]
    class EmployeesService
    {
        #region Attributes

        /// <summary>
        /// List of employee IDs associated with a project.
        /// </summary>
        List<int> employees;
        #endregion

        #region Methods

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the EmployeesService class.
        /// </summary>
        public EmployeesService()
        {
            employees = new List<int>(5);
        }

        #endregion

        #region OtherMethods

        /// <summary>
        /// Checks if an employee exists in the list of employees for the project.
        /// </summary>
        /// <param name="employeeId">The ID of the employee to check.</param>
        /// <returns>True if the employee exists in the list; otherwise, false.</returns>
        public bool ExistExistEmployee(int employeeId)
        {
            return employees.Contains(employeeId);
        }

        /// <summary>
        /// Adds an employee to the list of employees for the project.
        /// </summary>
        /// <param name="employeeId">The ID of the employee to add.</param>
        /// <returns>True if the employee was added successfully; otherwise, false.</returns>
        /// <exception cref="ConfigurationErrorException">Thrown if an error occurs during the addition of the employee.</exception>
        public bool AddEmployee(int employeeId)
        {
            try
            {
                if (!ExistExistEmployee(employeeId))
                {
                    employees.Add(employeeId);
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("810", ex);
            }
            return false;
        }

        /// <summary>
        /// Removes an employee from the list of employees for the project.
        /// </summary>
        /// <param name="employeeId">The ID of the employee to remove.</param>
        /// <returns>True if the employee was removed successfully; otherwise, false.</returns>
        /// <exception cref="ConfigurationErrorException">Thrown if an error occurs during the removal of the employee.</exception>
        public bool RemoveEmployee(int employeeId)
        {
            try
            {
                if (ExistExistEmployee(employeeId))
                {
                    employees.Remove(employeeId);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("811", ex);
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
