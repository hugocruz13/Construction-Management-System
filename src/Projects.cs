/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/12/2024 3:48:18 PM</date>
*	<description></description>
**/
using System;

namespace src
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 11/12/2024 3:48:18 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Projects
    {
        #region Attributes
        const int sizeArrays = 5;
        static Project[] projects;
        static int total = 0;
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        static Projects()
        {
            projects = new Project[sizeArrays];
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        public static bool AddProject(Project p) 
        {
            if (p == null || total >5)
                return false;
            projects[total++] = p;
            return true;
        }

        public static bool AddEmployee(int idProject,Employee employee) 
        {
            for (int i = 0; i < projects.Length; i++)
            {
                if (projects[i].Id == idProject)
                {
                    projects[i].AddEmployee(employee);
                    return true;
                }
            }
            return false;
        }

        public static bool AddClient(int idProject, Client client) 
        {
            for (int i = 0; i < projects.Length; i++)
            {
                if (projects[i].Id == idProject)
                {
                    projects[i].Client = client;
                    return true;
                }
            }
            return false;
        }

        public static bool ChangeStatus(int idProject, Status status)
        {
            for (int i = 0; i < projects.Length; i++)
            {
                if (projects[i].Id == idProject)
                {
                    projects[i].Status = status;
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Projects()
        {
        }
        #endregion

        #endregion

    }
}
