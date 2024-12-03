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
using System.Net.Sockets;

using Object_Layer;

namespace Data_Layer
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

        static Dictionary<int, List<Employee>> employees;
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Constructors
        static Employees()
        {
            employees= new Dictionary<int, List<Employee>>(11);
        }

        #endregion


        #region OtherMethods
        internal static int GenerateKey(short idEmployee)
        {
            return idEmployee % 11;
        }

        public static short AddEmployee(Employee employee)
        {
            if (!EmployeeExist(employee))
            {
                int key = GenerateKey(employee.Id);

                if (!employees.ContainsKey(key))
                {
                    employees[key] = new List<Employee>(5);
                }

                employees[key].Add(employee);
                return employee.Id;
            }

            return -11; /// QUESTIONAR PROF MANUAL DE ERROS?
        }

        internal static bool EmployeeExist(Employee employee)
        {
            foreach (List<Employee> employeeList in employees.Values)
            {
                foreach (Employee existingEmployee in employeeList)
                {
                    if (existingEmployee - employee)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool EmployeeExist(short idEmployee)
        {
            int key = GenerateKey(idEmployee);

            if (employees.ContainsKey(key))
            {
                foreach (Employee employeeInstance in employees[key])
                {
                    if (employeeInstance.Id == idEmployee)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool AvailableEmployees(short idEmployee)
        {
            int key = GenerateKey(idEmployee);

            if (employees.ContainsKey(key))
            {
                foreach (Employee employeeInstance in employees[key])
                {
                    if (employeeInstance.Id == idEmployee)
                    {
                        if (employeeInstance.StatusEmployee == StatusEmployee.Enable)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static bool ChangeStatus(short idEmployee)
        {
            int key = GenerateKey(idEmployee);

            if (employees.ContainsKey(key))
            {
                foreach (Employee employeeInstance in employees[key])
                {
                    if (employeeInstance.StatusEmployee == StatusEmployee.Enable)
                    {
                        employeeInstance.StatusEmployee = StatusEmployee.Disable;
                        return true;
                    }
                    else
                    {
                        employeeInstance.StatusEmployee = StatusEmployee.Enable;
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool UpdateRole(short idEmployee, string role, double hourly)
        {
            int key = GenerateKey(idEmployee);

            if (employees.ContainsKey(key))
            {
                foreach (Employee employeeInstance in employees[key])
                {
                    if (employeeInstance.Id == idEmployee)
                    {
                        employeeInstance.Role = role;
                        employeeInstance.HourlyRate = hourly;
                        return true;
                    }
                }
            }

            return false;
        }

        public static void ShowEmployees()
        {
            foreach (List<Employee> employeeList in employees.Values)
            {
                foreach (Employee employeeInstance in employeeList)
                {
                    Console.WriteLine(employeeInstance.ToString());
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
