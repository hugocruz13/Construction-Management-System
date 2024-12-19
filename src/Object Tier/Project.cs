/*
*	<copyright file="Project.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/6/2024 2:25:57 PM</date>
*	<description>Class representing a Project with its status, client, team and materials used</description>
**/
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;


namespace Object_Tier
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
    /// Represents a project with information about its status, start date, end date, and ID management.    
    /// </summary>
    [Serializable]
    public class Project 
    {
        #region Attributes

        /// <summary>
        /// Project ID.
        /// </summary>
        int idProject;

        /// <summary>
        /// Current status of the project.
        /// </summary>
        Status status;

        /// <summary>
        /// Start date of the project.
        /// </summary>
        DateTime startDate;

        /// <summary>
        /// End date of the project.
        /// </summary>
        DateTime endDate;

        /// <summary>
        /// Static counter for generating unique project IDs.
        /// </summary>
        [NonSerialized]
        static int projectIdCounter = 300;
        #endregion

        #region Methods

        #region Properties

        /// <summary>
        /// Gets or sets the project ID.
        /// </summary>
        public int Id
        {
            set { idProject = value; }
            get { return idProject; }
        }

        /// <summary>
        /// Gets or sets the project status.
        /// </summary>
        public Status Status
        {
            set { status = value; }
            get { return status; }
        }

        /// <summary>
        /// Gets the start date of the project.
        /// </summary>
        public DateTime StartDate
        {
            get { return startDate; }
        }

        /// <summary>
        /// Gets or sets the end date of the project.
        /// </summary>
        public DateTime EndDate
        {
            set { endDate = value; }
            get { return endDate; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Project class with a specified status.
        /// The start date is set to the current date, and the end date is initialized to the default value.
        /// </summary>
        /// <param name="status">The initial status of the project.</param>
        public Project(Status status)
        {
            Id = projectIdCounter++;
            Status = status;
            startDate = DateTime.Now;
            EndDate = new DateTime();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Determines whether the specified object is equal to the current project.
        /// </summary>
        /// <param name="obj">The object to compare with the current project.</param>
        /// <returns>True if the objects are equal; otherwise, false.</returns>
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

        /// <summary>
        /// Returns a string representation of the project.
        /// </summary>
        /// <returns>A string containing the project ID, status, start date, and end date.</returns>
        public override string ToString()
        {
            return Id + " " + Status + " " +StartDate + " " + EndDate;
        }
        #endregion

        #region OtherMethods

        /// <summary>
        /// Creates a new project with the specified status.
        /// </summary>
        /// <param name="status">The status of the new project.</param>
        /// <returns>A new Project instance.</returns>
        public static Project CreateProject(Status status)
        {
            return new Project(status);
        }


        /// <summary>
        /// Compares two projects for equality based on their properties.
        /// </summary>
        /// <param name="project1">The first project.</param>
        /// <param name="project2">The second project.</param>
        /// <returns>True if the projects are equal; otherwise, false.</returns>
        public static bool operator -(Project project1, Project project2)
        {
            if (project1.Equals(project2))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether two projects are not equal.
        /// </summary>
        /// <param name="project1">The first project.</param>
        /// <param name="project2">The second project.</param>
        /// <returns>True if the projects are not equal; otherwise, false.</returns>
        public static bool operator +(Project project1, Project project2)
        {
            return !(project1 - project2);
        }

        /// <summary>
        /// Increments the static project ID counter.
        /// </summary>
        /// <returns>True after incrementing the counter.</returns>
        public static bool getNextProjectId()
        {
            projectIdCounter++;
            return true;
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
