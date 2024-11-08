/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/8/2024 4:52:56 PM</date>
*	<description></description>
**/
using System;

namespace src
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 11/8/2024 4:52:56 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Team
    {
        #region Attributes
        const int sizeArrays = 20;
        static Employee[] team;
        static int total = 0;
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        static Team()
        {
            team = new Employee[sizeArrays];
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        public static bool AddEmployee(string name, string role, double hourlyrate)
        {
            Employee emp = new Employee(name, role, hourlyrate);
            team[total++] = emp;
            return true;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Team()
        {
        }
        #endregion

        #endregion

    }
}
