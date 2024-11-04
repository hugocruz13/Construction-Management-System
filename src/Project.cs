/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/3/2024 9:11:21 PM</date>
*	<description></description>
**/
using System;
using System.Xml.Linq;

namespace src
{
    public enum Status 
    {
        Progress = 1,
        Completed = 2,
        NotStarted = 3,
        Cancelled = 5
    }

    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 11/3/2024 9:11:21 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Project
    {
        #region Attributes
        int id;
        string location;
        Status status;
        static int projectIdCounter = 700;
        #endregion

        #region Methods
        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public string Location
        {
            set { location = value; }
            get { return location; }
        }

        public Client Client 
        {
            set {  client = value; }
            get { return client; }
        }

        public Status Status 
        {
            set { status = value; }
            get { return status; }
        }
        #region Properties

        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Project()
        {
            Id = projectIdCounter++;
            Location = string.Empty;
            Client = new Client();
            employees = new Employee[8];
            Status = Status.NotStarted;
        }

        public Project(string loc, Client c, Status s, int numEmployee)
        {
            Id = projectIdCounter++;
            Location = loc;
            Client = c;
            employees = new Employee[numEmployee];
            Status = s;
        }
        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Project()
        {
        }
        #endregion

        #endregion

    }
}
