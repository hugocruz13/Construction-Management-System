/*
*	<copyright file="Employee.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/2/2024 3:20:10 PM</date>
*	<description>This file is focused on employees.</description>
**/
using System;

namespace Object_Tier
{

    /// <summary>
    /// Represents an employee in the system, inheriting from the Person class.
    /// </summary>
    [Serializable]
    public class Employee : Person, IComparable<Employee>
    {
        #region Attributes
        /// <summary>
        /// Stores the role of the employee.
        /// </summary>
        string role;

        /// <summary>
        /// Stores the hourly rate of the employee.
        /// </summary>
        double hourlyRate;


        /// <summary>
        /// Static counter to generate unique employee IDs. Starts at 200.
        /// </summary>
        [NonSerialized]
        static int employeeIdCounter = 200;
        #endregion

        #region Methods

        #region Properties

        /// <summary>
        /// Gets or sets the employee’s role.
        /// Ensures the role is not empty.
        /// </summary>
        public string Role
        {
            set
            {
                if (role != string.Empty)
                {
                    role = value;
                }
            }
            get { return role; }
        }

        /// <summary>
        /// Gets or sets the employee’s hourly rate.
        /// </summary>
        public double HourlyRate
        {
            set
            {
                if (value > hourlyRate)
                {
                    hourlyRate = value;
                }
            }
            get { return hourlyRate; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Employee class with the specified name, role, and hourly rate.
        /// Automatically assigns a unique ID.
        /// </summary>
        /// <param name="name">The name of the employee.</param>
        /// <param name="role">The role of the employee.</param>
        /// <param name="hourlyrate">The hourly rate of the employee.</param>
        public Employee(string name, string role, double hourlyrate) : base(employeeIdCounter++, name) // Send for constructor Person
        {
            Role = role.ToUpper().Trim();
            HourlyRate = hourlyrate;
        }
        #endregion

        #region Overrides

        /// <summary>
        /// Determines whether the specified object is equal to the current employee.
        /// Employees are equal if their name, role, and hourly rate match.
        /// </summary>
        /// <param name="obj">The object to compare with the current employee.</param>
        /// <returns>True if the objects are equal; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Employee)
            {
                Employee otherEmp = obj as Employee;

                if (Name == otherEmp.Name && Role == otherEmp.Role && HourlyRate == otherEmp.HourlyRate)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns a string representation of the employee, including ID, name, role, and hourly rate.
        /// </summary>
        /// <returns>A string representation of the employee.</returns>
        public override string ToString()
        {
            return Id + " " + Name + " " + Role + " " + HourlyRate;
        }
        #endregion

        #region OtherMethods

        /// <summary>
        /// Creates a new Employee instance.
        /// </summary>
        /// <param name="name">The name of the employee.</param>
        /// <param name="role">The role of the employee.</param>
        /// <param name="hourlyRate">The hourly rate of the employee.</param>
        /// <returns>A new Employee instance.</returns>
        public static Employee CreateEmployee(string name, string role, double hourlyRate)
        {
            return new Employee(name, role, hourlyRate);
        }

        /// <summary>
        /// Checks if two employees are equal using the "-" operator.
        /// </summary>
        /// <param name="employee1">The first employee.</param>
        /// <param name="employee2">The second employee.</param>
        /// <returns>True if the employees are equal; otherwise, false.</returns>
        public static bool operator -(Employee employee1, Employee employee2)
        {
            if (employee1.Equals(employee2))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if two employees are not equal using the "+" operator.
        /// </summary>
        /// <param name="employee1">The first employee.</param>
        /// <param name="employee2">The second employee.</param>
        /// <returns>True if the employees are not equal; otherwise, false.</returns>
        public static bool operator +(Employee employee1, Employee employee2)
        {
            return !(employee1 - employee2);
        }

        /// <summary>
        /// Compares the current employee to another employee based on their name.
        /// </summary>
        /// <param name="employee">The employee to compare to.</param>
        /// <returns>A value indicating the relative order of the employees.</returns>
        public int CompareTo(Employee employee)
        {
            return Name.CompareTo(employee.Name);
        }

        /// <summary>
        /// Increments the static employee ID counter.
        /// </summary>
        /// <returns>True after incrementing the counter.</returns>
        public static bool getNextEmployeeId()
        {
            employeeIdCounter++;
            return true;
        }
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
