/*
*	<copyright file="Team.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/12/2024 6:50:44 PM</date>
*	<description></description>
**/
using System;

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
        int[] team;
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
        public EmployeesProject(int numEmployee)
        {
            team = new int[numEmployee];
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        /// <summary>
        /// Adds an employee to the project team if there is an available slot.
        /// </summary>
        /// <param name="id">The unique ID of the employee to be added.</param>
        /// <remarks>
        /// The method iterates through the <c>team</c> array to find an empty slot. 
        /// Once an empty slot is found, the employee ID is assigned to that slot, and the method returns <c>true</c>. 
        /// If no slots are available, the method returns <c>false</c>.
        /// </remarks>
        /// <returns>
        /// <c>true</c> if the employee was successfully added to the team; otherwise, <c>false</c>.
        /// </returns>
        public bool AddEmployee(int id)
        {
            for (int i = 0; i < team.Length; i++)
            {
                while (team[i] == 0)
                {
                    team[i] = id;
                    return true;
                }
            }

            return false;
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
