/*
*	<copyright file="Team.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/12/2024 6:50:44 PM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;

namespace trabalhoPOO_23010
{
    /// <summary>
    /// Represents a team of employees.
    /// </summary>
    /// <remarks>
    /// The <c>Team</c> class manages an array of <c>Employee</c> objects.
    /// </remarks>
    /// <example>
    /// <code>
    /// Team team = new Team();
    /// </code>
    /// </example>
    public class EmployeesProject
    {
        #region Attributes

        /// <summary>
        /// Array that stores instances of <c>Employee</c> objects.
        /// </summary>
        List<int> team;
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <c>Team</c> class.
        /// </summary>
        /// <remarks>
        /// This constructor initializes the <c>team</c> array with a predefined size.
        /// </remarks>
        public EmployeesProject()
        {
            team = new List<int>(5);
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods

        public bool AddEmployee(int id)
        {
            team.Add(id);
            return true;
        }
        #endregion

        #region Destructor
        /// <summary>
        ///  Destructor for the <c>Team</c> class.
        /// </summary>
        ~EmployeesProject()
        {
        }
        #endregion

        #endregion

    }
}
