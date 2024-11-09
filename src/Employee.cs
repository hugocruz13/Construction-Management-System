/*
*	<copyright file="Employee.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/2/2024 3:20:10 PM</date>
*	<description>This file is focused on employees.</description>
**/
using System;

namespace src
{
    /// <summary>
    /// Class <c>Employee</c> allows to create an employee object with basic 
    /// information such as their Id, name, role, and hourly role.
    /// </summary>
    /// <remarks>
    /// This class allows to create an employee and provide methedos to access and modify the employee's attributes.
    /// </remarks>
    /// <example>
    /// Example of use
    /// <code>
    /// Employee emp = new Employee();
    /// emp.Name = "Hugo Cruz";
    /// emp.Role = "Engineering";
    /// emp.HourlyRate = 12.3;
    /// </code>
    /// <code> 
    /// Employee emp = new Employee("Hugo Cruz", "Engineering", 12.3);
    /// </code>
    /// </example>
    public class Employee : Person
    {
        #region Attributes
        /// <summary>
        /// The position of employee.
        /// </summary>
        string role;
        /// <summary>
        /// The hourly rate of the employee.
        /// </summary>
        double hourlyRate;
        /// <summary>
        /// Static counter to assign unique IDs to employees.
        /// </summary>
        static int employeeIdCounter = 200;
        #endregion

        #region Methods

        #region Properties

        /// <summary>
        /// Obtain or define the position of the employee.
        /// </summary>
        /// <value>The position of employee.</value>
        /// <permission>
        /// Public Access
        /// </permission>
        public string Role
        {
            set { role = value; }
            get { return role; }
        }

        /// <summary>
        /// Gets or sets the employee’s hourly rate
        /// </summary>
        /// <value>The hourly rate of the employee.</value>
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
        /// Default constructor for the employee. Automatically assigns an ID 
        /// and initializes the other attributes with default values.
        /// </summary>
        /// <remarks>
        /// The ID is automatically generated with the static counter.
        /// The name, position and hourly rate are initialized as string empty or zero.
        /// </remarks>
        /// <permission>
        /// Public Access
        /// </permission>
        public Employee() : base(employeeIdCounter++, string.Empty)
        {
            Role = string.Empty;
            HourlyRate = 0;
        }

        /// <summary>
        /// Simple constructor to initialize the employee with specific values.
        /// </summary>
        /// <param name="name">Employee Name</param>
        /// <param name="role">Employee Role</param>
        /// <param name="hourlyrate">Employee Hourly Rate</param>
        /// <remarks>
        /// Initializes the employee with a given name, job title and hourly rate.
        /// The ID is assigned automatically using the static counter.
        /// </remarks>
        public Employee(string name, string role, double hourlyrate) : base(employeeIdCounter++, name)
        {
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
        /// The destroyer of the Employee class.
        /// </summary>
        ~Employee()
        {
        }
        #endregion

        #endregion

    }
}
