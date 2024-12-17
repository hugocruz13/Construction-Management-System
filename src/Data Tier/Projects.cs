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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CustomExceptions;
using Data_Layer;
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
    [Serializable]
    public class Projects
    {
        #region Attributes
        static Projects instance;
        static List<Project> projects;
        #endregion

        #region Methods

        #region Properties
        public static Projects Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Projects();
                }

                return instance;
            }
        }

        internal List<Project> ProjectsD
        {
            set { projects = value; }
            get { return projects; }
        }
        #endregion

        #region Constructors

        protected Projects()
        {
            projects = new List<Project>(5);
        }

        #endregion

        #region OtherMethods
        public int AddProject(Project project)
        {
            if (!ProjectExists(project))
            {
                projects.Add(project);
                projects.Sort();
                return project.Id;
            }

            return -17;

        }

        public bool ProjectExists(Project project)
        {

            foreach (Project existingProject in projects)
            {
                if (existingProject - project)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ProjectExists(int idProject)
        {

            foreach (Project project in projects)
            {
                if (project.Id == idProject)
                {
                    return true;
                }
            }

            return false;
        }



        #region Clients
        public bool AddClient(int idProject, int idClient)
        {
            bool r = ClientsService.Instance.AddClient(idProject, idClient);
            return r;
        }

        public bool RemoveClient(int idProject, int idClient)
        {
            bool r = ClientsService.Instance.RemoveClient(idProject, idClient);
            return r;
        }


        internal List<Project> GetDataToSave()
        {
            return projects;
        }
        #endregion

        #region Employees

        #endregion

        #region MaterialUse

        #endregion

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
