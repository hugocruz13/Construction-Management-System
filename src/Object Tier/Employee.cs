/*
*	<copyright file="Employee.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/2/2024 3:20:10 PM</date>
*	<description>This file is focused on employees.</description>
**/
using System;
using System.Runtime.Serialization;

namespace Object_Tier
{

    /// <summary>
    /// Class <c>Employee</c> allows to create an employee object with basic 
    /// information such as their Id, name, role, and hourly role.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="Person"/> and provides methods to access and modify 
    /// the employee attributes, and assign an Id automatically using a static counter.
    /// </remarks>
    /// <example>
    /// Example of use
    /// <code> 
    /// Employee emp = new Employee("Hugo Cruz", "Engineering", 12.3);
    /// </code>
    /// </example>
    [Serializable]
    public class Employee : Person, IComparable<Employee>
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


        double salary;

        /// <summary>
        /// Static counter to assign unique IDs to employees.
        /// </summary>
        [ NonSerialized]
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
        /// Gets or sets the employee’s hourly rate
        /// </summary>
        /// <value>The hourly rate of the employee.</value>
        /// <permission>
        /// Public Access
        /// </permission>
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

        public double Salary 
        {
            get { return salary; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor to initialize the employee with specific values.
        /// </summary>
        /// <param name="name">Employee Name</param>
        /// <param name="role">Employee Role</param>
        /// <param name="hourlyrate">Employee Hourly Rate</param>
        /// <remarks>
        /// Initializes the employee with a given name, job title and hourly rate.
        /// The ID is assigned automatically using the static counter.
        /// </remarks>
        public Employee(string name, string role, double hourlyrate) : base(employeeIdCounter++, name) // Send for constructor Person
        {
            Role = role.ToUpper().Trim();
            HourlyRate = hourlyrate;
            this.salary = Math.Round(CalculaSalario(),2);
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Determines whether the specified object is equal to the current employee.
        /// </summary>
        /// <param name="obj">The object to compare with the current employee.</param>
        /// <returns>
        /// <c>true</c> if the specified object is equal to the current employee; otherwise, <c>false</c>.
        /// </returns>
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

        public override string ToString()
        {
            return Id + " " + Name + " " + Role + " " + HourlyRate;
        }
        #endregion

        #region OtherMethods
        public static Employee CreateEmployee(string name, string role, double hourlyRate)
        {
            return new Employee(name, role,hourlyRate);
        }

        public static bool operator -(Employee employee1, Employee employee2)
        {
            if (employee1.Equals(employee2))
            {
                return true;
            }

            return false;
        }

        public static bool operator +(Employee employee1, Employee employee2)
        {
            return !(employee1 - employee2);
        }

        public int CompareTo(Employee employee)
        {
            return Name.CompareTo(employee.Name);
        }

        private double CalculaSalario() 
        {
            return HourlyRate * 8 * 22;
        }

        [OnDeserialized]
        public void Colocaigual(StreamingContext context)
        {
            if (Id >= employeeIdCounter)
            {
                employeeIdCounter = Id + 1;

            }
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
