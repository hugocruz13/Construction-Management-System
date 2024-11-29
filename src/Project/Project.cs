/*
*	<copyright file="Project.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/6/2024 2:25:57 PM</date>
*	<description>Class representing a Project with its status, client, team and materials used</description>
**/
using System;
using System.Xml.Linq;

namespace trabalhoPOO_23010
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
        short idProject;

        /// <summary>
        /// Current status of the project.
        /// </summary>
        Status status;

        /// <summary>
        /// Project start date.
        /// </summary>
        DateTime startDate;

        /// <summary>
        /// Project end date.
        /// </summary>
        DateTime endDate;

        /// <summary>
        /// Client associated with the project.
        /// </summary>
        ClientsProject clients; 

        /// <summary>
        ///  Team associated with the project.
        /// </summary>
        EmployeesProject team;

        /// <summary>
        /// 
        /// </summary>
        MaterialProject used;

        /// <summary>
        /// Static counter to assign unique IDs to project.
        /// </summary>
        static short projectIdCounter = 300;
        #endregion

        #region Methods

        #region Properties
        /// <summary>
        /// Property to access or modify the project ID.
        /// </summary>
        public short Id
        {
            set { idProject = value; }
            get { return idProject; }
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
        /// Gets the start date of the period or event.
        /// </summary>
        public DateTime StartDate
        {
            get { return startDate; }
        }

        /// <summary>
        /// Gets or sets the end date of the period or event.
        /// </summary>
        public DateTime EndDate
        {
            set { endDate = value; }
            get { return endDate; }
        }



        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <c>Project</c> class with specified status, client ID, and start date.
        /// </summary>
        /// <param name="status">The initial status of the project.</param>
        /// <param name="idClient">The unique identifier of the client associated with the project.</param>
        /// <param name="start">The start date of the project.</param>
        /// <remarks>
        /// The constructor automatically assigns a unique project ID using a static counter. 
        /// It also initializes the project's team as an empty <c>Team</c> object and sets the end date to the default value.
        /// </remarks>
        public Project(Status status)
        {
            Id = projectIdCounter++;
            Status = status;
            startDate = DateTime.Now;
            EndDate = new DateTime();
            clients = new ClientsProject();
            team = new EmployeesProject();
            used = new MaterialProject();
        }

        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Project)
            {
                Project otherproject = obj as Project;

                if (StartDate == otherproject.StartDate)
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return Id + " " + Status + " " +StartDate + " " + EndDate;
        }
        #endregion

        #region OtherMethods
        public bool AddMaterial(short idMaterial, int quantity)
        {
            used.AddMaterial(idMaterial, quantity);
            return true;
        }

        public bool AddClient(short idClient)
        {
            clients.AddClient(idClient);
            return true;
        }

        public bool AddEmployee(short idEmployee)
        {
            team.AddEmployee(idEmployee);
            return true;
        }

        public static bool operator -(Project project1, Project project2)
        {
            if (project1.Equals(project2))
            {
                return true;
            }

            return false;
        }

        public static bool operator +(Project project1, Project project2)
        {
            return !(project1 - project2);
        }
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
