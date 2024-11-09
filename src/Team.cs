/*
*	<copyright file="Team.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/8/2024 4:52:56 PM</date>
*	<description>Class to manage the team of employees of a project.</description>
**/
using System;

namespace src
{
    /// <summary>
    ///  The <c>Team</c> class represents a collection of employees working 
    ///  on a project. It manages adding new employees  to the team and displaying 
    ///  their information.
    /// </summary>
    /// <remarks>
    /// The <c>Team</c> class is designed to store a list of employees working on a 
    /// specific project. It provides methods  to add employees to the team and display 
    /// the information of all the employees. The team is stored in an array with a fixed 
    /// size, and the total number of employees is tracked. The class allows employees to 
    /// be added dynamically,  but there is a limit based on the predefined size of the array.
    /// </remarks>
    /// <example>
    /// Example of use:
    /// <code>
    /// Team.AddEmployee("John Doe", "Engineer", 15.5);
    /// Team.AddEmployee("Jane Smith", "Manager", 20.0);
    /// Team.ShowEmployee();
    /// </code>
    /// </example>
    public class Team
    {
        #region Attributes
        /// <summary>
        /// Sets the maximum size of the array to store employees
        /// </summary>
        const int sizeArrays = 20;
        /// <summary>
        /// Static array to store staff employees
        /// </summary>
        static Employee[] team;
        /// <summary>
        /// Counter to control the number of added employees
        /// </summary>
        static int total = 0;
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// The static class constructor. Initializes the 'team' array to store the employees of the team.
        /// </summary>
        static Team()
        {
            //Initializes the employee array with size set in 'sizeArrays'
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

        public static void ShowEmployee() 
        {
            for (int i = 0; i < total; i++)
            {
                Console.WriteLine("{0} {1} {2} {3}", team[i].Id, team[i].Name, team[i].Role, team[i].HourlyRate);
            }
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
