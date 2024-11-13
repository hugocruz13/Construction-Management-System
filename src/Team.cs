/*
*	<copyright file="Team.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/12/2024 6:50:44 PM</date>
*	<description></description>
**/
using System;

namespace src
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
    public class Team
    {
        #region Attributes
        /// <summary>
        /// Fixed size of the <c>team</c> array, indicating the number of employees.
        /// </summary>
        const int sizeArrays = 3;

        /// <summary>
        /// Array that stores instances of <c>Employee</c> objects.
        /// </summary>
        Employee[] team;
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
        public Team()
        {
            team = new Employee[sizeArrays];
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        #endregion

        #region Destructor
        /// <summary>
        ///  Destructor for the <c>Team</c> class.
        /// </summary>
        ~Team()
        {
        }
        #endregion

        #endregion

    }
}
