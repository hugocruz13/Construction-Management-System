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
        static int id;
        static Status status;
        static Client client;
        static Team team;
        static UsedMaterials usedMaterials;
        #endregion

        #region Methods

        #region Properties
        public static int Id
        {
            set { id = value; }
            get { return id; }
        }

        public static Status Status 
        {
            set { status = value; }
            get { return status; }
        }

        public static Client Client 
        {
            set { client = value; }
            get { return client; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        static Project()
        {

        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        public static bool AddMaterial(Material m , int quantity) 
        {
            UsedMaterials.AddMaterial(m, quantity);
            return true;
        }
        public static bool AddEmployee(string name, string role, double hourlyrate)
        {
            Team.AddEmployee(name, role, hourlyrate);
            return true;
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
