/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/12/2024 3:42:09 PM</date>
*	<description></description>
**/
using System;
using System.Net.Sockets;

namespace trabalhoPOO_23010
{
    /// <summary>
    /// Represents a collection of employee with a fixed maximum capacity.
    /// </summary>
    /// <remarks>
    /// This class is designed to store instances of the <c>Employee</c> class in a fixed-size array, defined by the constant <c>sizeArrays</c>.
    /// The array is statically initialized upon first access to the <c>Employees</c> class.
    /// </remarks>
    /// <example>
    /// Example of use
    /// <code>
    /// Employees employees 
    /// Employees.AddEmployee(new Employee employee("Antonio Pereira","Eletricista", 6.3))
    /// </code>
    /// </example>
    public class Employees
    {
        #region Attributes

        /// <summary>
        /// Array that stores instances of <c>Employee</c> objects.
        /// </summary>
        static Employee[] employees;
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Constructors


        /// <summary>
        /// Initializes the <c>Employees</c> class by setting up the client array.
        /// </summary>
        /// <remarks>
        /// This static constructor is called only once, when the <c>Employees</c> class is accessed for the first time. 
        /// It initializes the <c>employees</c> array with a predefined size.
        /// </remarks>
        /// <example>
        /// Accessing any member of the <c>Employees</c> class will trigger this constructor if it hasn't been initialized.
        /// </example>
        static Employees()
        {
            employees = new Employee[sizeArrays];
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        public static short AddEmployee(Employee employee)
        {
            if (!EmployeeExist(employee))
            {
                for (int i = 0; i < employees.Length; i++)
                {
                    if (employees[i] == null)
                    {
                        employees[i] = employee;
                        return employees[i].Id;
                    }
                }
            }
            return -11;
        }

        internal static bool EmployeeExist(Employee employee)
        {
            if (employee == null)
            {
                return false;
            }

            foreach (Employee e in employees)
            {
                if (e == null)
                {
                    return false;
                }
                if (employee - e)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool EmployeeExist(short idEmployee)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    break;
                }
                if (employees[i].Id == idEmployee)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool UpdateRole(short idEmployee, string role, double hourly)
        {
            int p = FindEmployee(idEmployee);
            if (p != -11)
            {
                employees[p].Role = role;
                employees[p].HourlyRate = hourly;
                return true;
            }

            return false;
        }

        public static int FindEmployee(short idEmployee)
        {
            if (EmployeeExist(idEmployee))
            {
                for (int i = 0; i < employees.Length; i++)
                {

                    if (employees[i].Id == idEmployee)
                    {
                        return i;
                    }

                }
            }

            return -11;
        }

        public static void ShowEmployees()
        {
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    break;
                }
                Console.WriteLine(employees[i].ToString());
            }
        }

        public static void ShowEmployees(short idEmployee)
        {
            if (EmployeeExist(idEmployee))
            {
                for (int i = 0; i < employees.Length; i++)
                {
                    if (employees[i] == null)
                    { 
                        break;
                    }
                    if (employees[i].Id == idEmployee)
                    {
                        Console.WriteLine(employees[i].ToString());
                        break;
                    }
                }
            }
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
