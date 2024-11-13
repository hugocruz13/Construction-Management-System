/*
*	<copyright file="Project.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/6/2024 2:25:57 PM</date>
*	<description>Class representing a Project with its status, client, team and materials used</description>
**/
using System;

namespace src
{

    /// <summary>
    /// Enum that defines the possible status of a project.
    /// </summary>
    public enum Status
    {
        NotStart = 1, //In wait list 
        InProgress = 2, //In Progress
        OnHold = 3, //Stopped for a while 
        Completed = 4  //Complet
    }

    /// <summary>
    /// The <c>Project</c> class represents a project with details like its unique ID, status, 
    /// associated client, team of employees, and the materials used in the project. It allows 
    /// adding employees, materials, and displaying project information.
    /// </summary>
    /// <remarks>The <c>Project</c> class is designed to manage the essential aspects of a project. 
    /// It includes the project ID, status, client details, a list of employees working on the project,
    /// and a collection of materials used for the project. The class supports modifying project details 
    /// and provides methods for interacting with employees and materials. The project’s status can also 
    /// be updated to reflect its current state.
    /// </remarks>
    /// <example>
    /// Example of use:
    /// <code>
    /// Project.Id = 600;
    /// Project.Status = Status.NotStart;
    /// Project.Client = new Client("Antonio", "964563928");
    /// Project.AddEmployee("Nuno Jose", "Eletricista", 4.5);
    /// Project.AddMaterial(new Material("Tijolos", 0.37), 200);
    /// </code> 
    public class Project
    {
        #region Attributes
        /// <summary>
        /// Unique project ID.
        /// </summary>
        int id;

        /// <summary>
        /// Current status of the project.
        /// </summary>
        Status status;

        /// <summary>
        /// Client associated with the project.
        /// </summary>
        Client client;

        /// <summary>
        ///  Team associated with the project.
        /// </summary>
        Team team;

        /// <summary>
        /// Materials used in the project.
        /// </summary>
        static MaterialInventory usedMaterials;

        /// <summary>
        /// Static counter to assign unique IDs to project.
        /// </summary>
        static int projectIdCounter = 300;
        #endregion

        #region Methods

        #region Properties
        /// <summary>
        /// Property to access or modify the project ID.
        /// </summary>
        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        /// <summary>
        /// Property to access or modify the project status.
        /// </summary>
        public Status Status 
        {
            set { status = value; }
            get { return status; }
        }

        /// <summary>
        /// Property to access or modify the client associated with the project.
        /// </summary>
        public Client Client 
        {
            set { client = value; }
            get { return client; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Project(Status status, Client client)
        {
            Id = projectIdCounter++;
            Status = status;
            Client = client;
            team = new Team();
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods

        #endregion

        #region Destructor
        /// <summary>
        /// The destroyer of the Project class.
        /// </summary>
        ~Project()
        {
        }
        #endregion

        #endregion

    }
}
