/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/12/2024 3:42:09 PM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using Object_Tier;
using CustomExceptions;
using Interface_Tier;

namespace Data_Tier
{
    /// <summary>
    /// Singleton class that manages a list of employees. Allows adding, removing, updating and retrieving employees.
    /// </summary>
    [Serializable]
    public class Employees : IEmployees
    {
        #region Attributes
        /// <summary>
        /// Singleton instance of the <c>Employees</c> class.
        /// </summary>
        static Employees instance;

        /// <summary>
        /// List of employees stored in memory.
        /// </summary>
        static List<Employee> employees;
        #endregion

        #region Methods

        #region Properties

        /// <summary>
        /// Gets the singleton instance of the <c>Employees</c> class.
        /// </summary>
        public static Employees Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Employees();
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets or sets the list of employees.
        /// </summary>
        internal List<Employee> EmployeesD
        {
            get { return employees; }
            set { employees = value; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <c>Employees</c> class, with an empty list of employees.
        /// </summary>
        protected Employees()
        {
            employees = new List<Employee>(5);
        }

        #endregion

        #region OtherMethods

        /// <summary>
        /// Finds an employee by their ID.
        /// </summary>
        /// <param name="employeeId">The ID of the employee to find.</param>
        /// <returns>The employee object if found, otherwise <c>null</c>.</returns>
        Employee FindEmployee(int employeeId)
        {
            foreach (Employee employee in employees)
            {
                if (employee.Id == employeeId)
                {
                    return employee;
                }
            }

            return null;
        }

        /// <summary>
        /// Adds a new employee to the list and sorts the list.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        /// <returns>The ID of the added employee.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws if the employee is null or if an error occurs during the addition.
        /// </exception>
        public int AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ConfigurationErrorException("400");
            }
            try
            {
                employees.Add(employee);
                employees.Sort();
                return employee.Id;
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("401", ex);
            }

        }

        /// <summary>
        /// Removes an employee by their ID from the list.
        /// </summary>
        /// <param name="idEmployee">The ID of the employee to remove.</param>
        /// <returns><c>true</c> if the employee was removed, otherwise <c>false</c>.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws if an error occurs during the removal.
        /// </exception>
        public bool RemoveEmployee(int idEmployee)
        {
            try
            {
                Employee employee = FindEmployee(idEmployee);

                if (employee != null)
                {
                    employees.Remove(employee);
                    employees.Sort();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("402", ex);
            }
            return false;
        }

        /// <summary>
        /// Checks if a specific employee exists in the list based on the employee object.
        /// </summary>
        /// <param name="employee">The employee to check for existence.</param>
        /// <returns><c>true</c> if the employee exists, otherwise <c>false</c>.</returns>
        public bool EmployeeExist(Employee employee)
        {
            foreach (Employee existingEmployee in employees)
            {
                if (existingEmployee - employee)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if an employee exists in the list based on their ID.
        /// </summary>
        /// <param name="idEmployee">The ID of the employee to check.</param>
        /// <returns><c>true</c> if the employee exists, otherwise <c>false</c>.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws if an error occurs during the existence check.
        /// </exception>
        public bool EmployeeExist(int idEmployee)
        {
            try
            {
                foreach (Employee employee in employees)
                {
                    if (employee.Id == idEmployee)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("403", ex);
            }

        }

        /// <summary>
        /// Updates an employee's role and hourly rate.
        /// </summary>
        /// <param name="idEmployee">The ID of the employee to update.</param>
        /// <param name="role">The new role of the employee.</param>
        /// <param name="hourly">The new hourly rate of the employee.</param>
        /// <returns><c>true</c> if the update was successful, otherwise <c>false</c>.</returns>
        /// <exception cref="ConfigurationErrorException">Throws if the update fails.</exception>
        public bool UpdateRole(int idEmployee, string role, double hourly)
        {
            try
            {
                Employee employee = FindEmployee(idEmployee);

                if (employee != null)
                {
                    employee.Role = role;
                    employee.HourlyRate = hourly;
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("404", ex);
            }

            return false;
        }

        /// <summary>
        /// Retrieves an employee based on their ID.
        /// </summary>
        /// <param name="idEmployee">The ID of the employee to retrieve.</param>
        /// <returns>The employee object if found, otherwise <c>null</c>.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws if the retrieval fails.
        /// </exception>
        public Employee GetEmployee(int idEmployee)
        {
            try
            {
                return FindEmployee(idEmployee);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("403", ex);
            }
        }

        // <summary>
        /// Synchronizes the employee counter with the number of employees in the list.
        /// </summary>
        /// <returns><c>true</c> if synchronization was successful, otherwise <c>false</c>.</returns>
        internal bool SetCounterEqualEmployee()
        {
            for (int i = 0; i < employees.Count; i++)
            {
                Employee.getNextEmployeeId();
            }

            return true;
        }

        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Employees()
        {
        }
        #endregion

        #endregion

    }
}
