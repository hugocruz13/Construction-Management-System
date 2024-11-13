/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/12/2024 3:42:09 PM</date>
*	<description></description>
**/
using System;

namespace src
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
        /// The fixed size of the <c>employees</c> array.
        /// </summary>
        const int sizeArrays = 15;

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
