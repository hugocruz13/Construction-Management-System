/*
*	<copyright file="Data_Tier.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>12/18/2024 10:24:24 PM</date>
*	<description></description>
**/
using Data_Layer;
using Object_Tier;
using System;
using CustomExceptions;

namespace Data_Tier
{
    /// <summary>
    /// Class that represents project data, including operations related to clients, employees, and materials.
    /// </summary>
    [Serializable]
    public class ProjectData : IComparable<ProjectData>
    {
        #region Attributes

        /// <summary>
        /// The project associated with this data.
        /// </summary>
        Project project;

        /// <summary>
        /// Manage clients associated with the project.
        /// </summary>
        ClientsService clientsService;

        /// <summary>
        /// Manage employees associated with the project.
        /// </summary>
        EmployeesService employeesService;

        /// <summary>
        /// Manage materials used in the project.
        /// </summary>
        MaterialService materialService;
        #endregion

        #region Methods

        #region Properties

        /// <summary>
        /// Gets or sets the project associated with this data.
        /// </summary>
        public Project Project
        {
            set { project = value; }
            get { return project; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ProjectData class with the specified project.
        /// </summary>
        /// <param name="project">The project to associate with this data.</param>
        public ProjectData(Project project)
        {
            Project = project;
            clientsService = new ClientsService();
            employeesService = new EmployeesService();
            materialService = new MaterialService();
        }

        #endregion

        #region OtherMethods

        /// <summary>
        /// Factory method to create a new ProjectData instance for a given project.
        /// </summary>
        /// <param name="project">The project to create data for.</param>
        /// <returns>A new ProjectData instance.</returns>
        public static ProjectData CreateProjectData(Project project)
        {
            return new ProjectData(project);
        }

        /// <summary>
        /// Compares this ProjectData instance with another one based on their project IDs.
        /// </summary>
        /// <param name="project">The other ProjectDatainstance to compare.</param>
        /// <returns>A value indicating the relative order of the projects.</returns>
        public int CompareTo(ProjectData project)
        {
            return project.Project.Id.CompareTo(project.project.Id);
        }

        /// <summary>
        /// Adds a client to the project.
        /// </summary>
        /// <param name="clientId">The ID of the client to add.</param>
        /// <returns>True if the client was added successfully; otherwise, false.</returns>
        /// <exception cref="ConfigurationErrorException">Throws an exception if an error occurs while adding the client.</exception>
        public bool AddClient(int clientId)
        {
            try
            {
                return clientsService.AddClient(clientId);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("830" + ex);
            }
        }

        /// <summary>
        /// Removes a client from the project.
        /// </summary>
        /// <param name="clientId">The ID of the client to remove.</param>
        /// <returns>True if the client was removed successfully; otherwise, false.</returns>
        /// <exception cref="ConfigurationErrorException">Throws an exception if an error occurs while removing the client.</exception>
        public bool RemoveClient(int clientId)
        {
            try
            {
                return clientsService.RemoveClient(clientId);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("831" + ex);
            }
        }

        /// <summary>
        /// Adds an employee to the project.
        /// </summary>
        /// <param name="employeeId">The ID of the employee to add.</param>
        /// <returns>True if the employee was added successfully; otherwise, false.</returns>
        /// <exception cref="ConfigurationErrorException">Throws an exception if an error occurs while adding the employee.</exception>
        public bool AddEmployee(int employeeId)
        {
            try
            {
                return employeesService.AddEmployee(employeeId);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("832" + ex);
            }
        }

        /// <summary>
        /// Removes an employee from the project.
        /// </summary>
        /// <param name="employeeId">The ID of the employee to remove.</param>
        /// <returns>True if the employee was removed successfully; otherwise, false.</returns>
        /// <exception cref="ConfigurationErrorException">Throws an exception if an error occurs while removing the employee.</exception>
        public bool RemoveEmployee(int employeeId)
        {
            try
            {
                return employeesService.RemoveEmployee(employeeId);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("833" + ex);
            }
        }

        /// <summary>
        /// Uses material in the project.
        /// </summary>
        /// <param name="material">The material and quantity to use.</param>
        /// <returns>True if the material was successfully used; otherwise, false.</returns>
        /// <exception cref="ConfigurationErrorException">Throws an exception if an error occurs while using the material.</exception>
        public bool UseMaterial(MaterialQuantity material)
        {
            try
            {
                return materialService.AddMaterial(material);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("834" + ex);
            }
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~ProjectData()
        {
        }
        #endregion

        #endregion

    }
}
