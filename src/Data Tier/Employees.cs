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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Data_Tier
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
    [Serializable]
    public class Employees
    {
        #region Attributes
        static Employees instance;
        static List<Employee> employees;
        #endregion

        #region Methods

        #region Properties
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
        #endregion

        #region Constructors
        protected Employees()
        {
            employees = new List<Employee>(5);
        }

        #endregion

        #region OtherMethods
        public short AddEmployee(Employee employee)
        {
            employees.Add(employee);
            employees.Sort();
            return employee.Id;

        }

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

        public bool EmployeeExist(short idEmployee)
        {
            foreach (Employee employeeInstance in employees)
            {
                if (employeeInstance.Id == idEmployee)
                {
                    return true;
                }
            }

            return false;
        }

        public bool UpdateRole(short idEmployee, string role, double hourly)
        {

            foreach (Employee employeeInstance in employees)
            {
                if (employeeInstance.Id == idEmployee)
                {
                    employeeInstance.Role = role;
                    employeeInstance.HourlyRate = hourly;
                    return true;
                }
            }

            return false;
        }

        public bool Save(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ConfigurationErrorException("Caminho invalido");
            }

            try
            {
                Stream fs = new FileStream(path, FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, employees);
                fs.Close();
                employees.Clear();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Algo aconteceu ");
            }

        }


        public bool Load(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ConfigurationErrorException("Caminho invalido");
            }
            try
            {
                Stream s = File.Open(path, FileMode.Open, FileAccess.Read);
                BinaryFormatter b = new BinaryFormatter();
                employees = (List<Employee>)b.Deserialize(s);
                s.Close();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Algo aconteceu ");
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
