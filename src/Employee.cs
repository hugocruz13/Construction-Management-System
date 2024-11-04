/*
*	<copyright file="Employee.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/2/2024</date>
*	<description>This file is focused on employees.</description>
**/
using System;

namespace src
{
    /// <summary>
    /// Purpose: Class <c>Employee</c> allows to create an employee object with basic 
    /// information such as their Id, name, role, and hourly role.
    /// </summary>
    /// <remarks>
    /// This class allows to create an employee and provide methedos to access and modify the employee's attributes.
    /// </remarks>
    /// <example>
    /// Example of use
    /// <code>
    /// Employee emp = new Employee();
    /// emp.Id = 1;
    /// emp.Name = "Hugo";
    /// emp.Role= "Engineering";
    /// emp.HourlyRate = "12.3";
    /// </code>
    /// </example>
    public class Employee : Person
    {
        #region Attributes
        string role;
        double hourlyRate;
        static int employeeIdCounter = 200;
        #endregion

        #region Methods

        #region Properties

        /// <summary>
        /// Employee Role.
        /// </summary>
        /// <permission>
        /// Public Access
        /// </permission>
        public string Role
        {
            set { role = value; }
            get { return role; }
        }

        /// <summary>
        /// Employee Hourly Rate
        /// </summary>
        /// <permission>
        /// Public Access
        /// </permission>
        public double HourlyRate
        {
            set { hourlyRate = value; }
            get { return hourlyRate; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        /// <permission>
        /// Public Access
        /// </permission>
        public Employee()
        {
            Id = employeeIdCounter++;
            Name = null;
            Role = null;
            HourlyRate = 0;
        }

        /// <summary>
        /// Simple constructor for employees.
        /// </summary>
        /// <param name="name">Employee Name</param>
        /// <param name="role">Employee Role</param>
        /// <param name="hourlyrate">Employee Hourly Rate</param>
        /// <remarks>
        /// Initializes an object 'Employee' with the specified values 
        /// for name, role, and hourly rate. The ID is assigned automatically
        /// using the static counter.
        /// </remarks>
        public Employee(string name, string role, double hourlyrate)
        {
            Id = employeeIdCounter++;
            Name = name;
            Role = role;
            HourlyRate = hourlyrate;
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Employee()
        {
        }
        #endregion

        #endregion

    }
}
