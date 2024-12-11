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


    public class Project : IComparable<Project>
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
        /// 
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


        public Project(Status status)
        {
            Id = projectIdCounter++;
            Status = status;
            startDate = DateTime.Now;
            EndDate = new DateTime();
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

        public int CompareTo(Project project)
        {
            return Id.CompareTo(project.Id);
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
