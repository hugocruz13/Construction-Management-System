/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/6/2024 2:25:57 PM</date>
*	<description></description>
**/
using System;

namespace src
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 11/6/2024 2:25:57 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>

    public enum Status
    {
        NotStart = 1, //In wait list 
        InProgress = 2, //In Progress
        OnHold = 3, //Stopped for a while 
        Completed = 4  //Complet
    }

    class Project
    {
        #region Attributes
        int id;
        string localization;
        double durationInHours;
        Status status;
        Client client;
        Employee[] team;
        Material[] materials;
        static int projectIdCounter = 300;
        static int total;
        #endregion

        #region Methods

        #region Properties
        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public string Localization
        {
            set { localization = value; }
            get { return localization; }
        }

        public double DurationInHours
        {
            set { durationInHours = value; }
            get { return durationInHours; }
        }

        public Status Status
        {
            set { status = value; }
            get { return status; }
        }

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
        public Project()
        {
        }

        public Project(string localization, double duration, Status status, Client client, int numEmployee)
        {
            Id = projectIdCounter++;
            Localization = localization;
            DurationInHours = duration;
            Status = status;
            Client = client;
            team = new Employee[numEmployee];
            materials = new Material[50];

        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        public void ADD(Employee ep) 
        {
            team[total++] = ep;
        }
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
