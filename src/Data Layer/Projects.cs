/*
*	<copyright file="Projects.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/12/2024 3:48:18 PM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;

using Object_Tier;

namespace Data_Tier
{
    /// <summary>
    /// The <c>Projects</c> class manages a collection of <c>Project</c> objects within a fixed-size array.
    /// </summary>
    /// <remarks>
    /// The class provides methods to add projects, add employees to a project, use materials in a project, 
    /// and verify if a project exists. It supports a limited number of projects defined by <c>sizeArrays</c>.
    /// </remarks>
    public class Projects
    {
        #region Attributes

        static Dictionary<int, List<Project>> projects;

        #endregion

        #region Methods

        #region Constructors

        static Projects()
        {
            projects = new Dictionary<int, List<Project>>(11);
        }

        #endregion

        #region OtherMethods
        internal static int GenerateKey(short idProject)
        {
            return idProject % 11;
        }

        public static short AddProject(Project project)
        {
            if (!ProjectExists(project))
            {
                int key = GenerateKey(project.Id);

                if (!projects.ContainsKey(key))
                {
                    projects[key] = new List<Project>(5);
                }

                projects[key].Add(project);
                return project.Id;
            }

            return -17;

        }

        internal static bool ProjectExists(Project project)
        {
            foreach (List<Project> projectList in projects.Values)
            {
                foreach (Project existingProject in projectList)
                {
                    if (existingProject - project)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool ProjectExists(short idProject)
        {
            int key = idProject % 11;

            if (projects.ContainsKey(key))
            {
                foreach (Project project in projects[key])
                {
                    if (project.Id == idProject)
                    {
                        return true;
                    }
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
