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
using CustomExceptions;
using Object_Tier;
using Interface_Tier;

namespace Data_Tier
{
    /// <summary>
    /// Singleton class that manages the projects in the system. Allows adding, removing, updating, and retrieving projects.
    /// </summary>
    [Serializable]
    public class Projects : IProjects
    {
        #region Attributes

        /// <summary>
        /// Singleton instance of the Projects class.
        /// </summary>
        static Projects instance;

        /// <summary>
        /// List of projects managed by the Projects class.
        /// </summary>
        static List<ProjectData> projects;
        #endregion

        #region Methods

        #region Properties

        /// <summary>
        /// Gets the singleton instance of the Projects class.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the list of projects.
        /// </summary>
        internal List<ProjectData> ProjectsD
        {
            set { projects = value; }
            get { return projects; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Projects class with an empty list of projects.
        /// </summary>
        protected Projects()
        {
            projects = new List<ProjectData>(5);
        }

        #endregion

        #region OtherMethods

        /// <summary>
        /// Finds a project by its ID.
        /// </summary>
        /// <param name="projectId">The ID of the project to find.</param>
        /// <returns>The project if found, otherwise null.</returns>
        internal ProjectData FindProject(int projectId)
        {
            foreach (ProjectData project in projects)
            {
                if (project.Project.Id == projectId)
                {
                    return project;
                }
            }

            return null;
        }

        /// <summary>
        /// Checks if a project exists by its ID.
        /// </summary>
        /// <param name="projectId">The ID of the project to check.</param>
        /// <returns>True if the project exists, otherwise false.</returns>
        internal bool ProjectExist(int projectId)
        {
            foreach (ProjectData project in projects)
            {
                if (project.Project.Id == projectId)
                {
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// Adds a new project to the projects list.
        /// </summary>
        /// <param name="project">The project to add.</param>
        /// <returns>The ID of the added project.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if the project is null or any error occurs during the addition.
        /// </exception>
        public int AddProject(ProjectData project)
        {
            if (project == null)
            {
                throw new ConfigurationErrorException("800");
            }

            try
            {
                projects.Add(project);
                projects.Sort();
                return project.Project.Id;
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("801" + ex);
            }
        }

        /// <summary>
        /// Removes a project from the projects list by its ID.
        /// </summary>
        /// <param name="idProject">The ID of the project to remove.</param>
        /// <returns>True if the project was successfully removed, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the removal.
        /// </exception>
        public bool RemoveProject(int idProject)
        {
            try
            {
                ProjectData project = FindProject(idProject);

                if (project != null)
                {
                    projects.Remove(project);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("802" + ex);
            }

            return false;
        }

        /// <summary>
        /// Checks if a project exists by its ID.
        /// </summary>
        /// <param name="projectId">The ID of the project to check.</param>
        /// <returns>True if the project exists, otherwise false.</returns>
        public bool ProjectExists(Project project2)
        {
            foreach (ProjectData project1 in projects)
            {
                if (project1.Project - project2)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if a project already exists based on its ID.
        /// </summary>
        /// <param name="idProject">The ID of the project to check.</param>
        /// <returns>True if the project exists, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the check.
        /// </exception>
        public bool ProjectExists(int idProject)
        {
            try
            {
                return ProjectExist(idProject);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("803" + ex);
            }
        }

        /// <summary>
        /// Updates the status of a project by its ID.
        /// </summary>
        /// <param name="idProject">The ID of the project to update.</param>
        /// <param name="status">The new status of the project.</param>
        /// <returns>True if the status was updated successfully, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the update.
        /// </exception>
        public bool UpdateStatus(int idProject, Status status)
        {
            try
            {
                ProjectData project = FindProject(idProject);

                if (project != null)
                {
                    project.Project.Status = status;
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("804" + ex);
            }

            return false;
        }

        /// <summary>
        /// Closes a project by setting its end date and status to completed.
        /// </summary>
        /// <param name="idProject">The ID of the project to close.</param>
        /// <returns>True if the project was successfully closed, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the closure.
        /// </exception>
        public bool CloseProject(int idProject)
        {
            try
            {
                ProjectData project = FindProject(idProject);

                if (project != null)
                {
                    project.Project.EndDate = DateTime.Now;
                    project.Project.Status = Status.Completed;
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("805" + ex);
            }

            return false;
        }

        #region Clients
        /// <summary>
        /// Adds a client to a project.
        /// </summary>
        /// <param name="idProject">The ID of the project to add the client to.</param>
        /// <param name="idClient">The ID of the client to add.</param>
        /// <returns>True if the client was added successfully, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the addition.
        /// </exception>
        public bool AddClient(int idProject, int idClient)
        {
            try
            {
                ProjectData project = FindProject(idProject);
                return project.AddClient(idClient);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("808" + ex);
            }
        }

        /// <summary>
        /// Removes a client from a project.
        /// </summary>
        /// <param name="idProject">The ID of the project to remove the client from.</param>
        /// <param name="idClient">The ID of the client to remove.</param>
        /// <returns>True if the client was removed successfully, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the removal.
        /// </exception>
        public bool RemoveClient(int idProject, int idClient)
        {
            try
            {
                ProjectData project = FindProject(idProject);
                return project.RemoveClient(idClient);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("809" + ex);
            }
        }

        #endregion

        #region Employees

        /// <summary>
        /// Adds an employee to a project.
        /// </summary>
        /// <param name="idProject">The ID of the project to add the employee to.</param>
        /// <param name="idEmployee">The ID of the employee to add.</param>
        /// <returns>True if the employee was added successfully, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the addition.
        /// </exception>
        public bool AddEmployee(int idProject, int idEmployee)
        {
            try
            {
                ProjectData project = FindProject(idProject);
                return project.AddEmployee(idEmployee);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("812" + ex);
            }
        }

        /// <summary>
        /// Removes an employee from a project.
        /// </summary>
        /// <param name="idProject">The ID of the project to remove the employee from.</param>
        /// <param name="idEmployee">The ID of the employee to remove.</param>
        /// <returns>True if the employee was removed successfully, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the removal.
        /// </exception>
        public bool RemoveEmployee(int idProject, int idEmployee)
        {
            try
            {
                ProjectData project = FindProject(idProject);
                return project.RemoveEmployee(idEmployee);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("813" + ex);
            }
        }
        #endregion

        #region MaterialUse

        /// <summary>
        /// Uses material in a project.
        /// </summary>
        /// <param name="idProject">The ID of the project to use material in.</param>
        /// <param name="idMaterial">The ID of the material to use.</param>
        /// <param name="quantity">The quantity of the material to use.</param>
        /// <returns>True if the material was used successfully, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the material use.
        /// </exception>
        public bool UseMaterial(int idProject, int idMaterial, int quantity)
        {
            try
            {
                ProjectData project = FindProject(idProject);
                return project.UseMaterial(MaterialQuantity.CreateMaterialQuantity(idMaterial, quantity));
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("805" + ex);
            }
        }

        internal bool SetCounterEqualProjects()
        {
            for (int i = 0; i < projects.Count; i++)
            {
                Project.getNextProjectId();
            }

            return true;
        }
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
