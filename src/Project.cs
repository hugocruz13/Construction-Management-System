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
        static Inventory inventory;
        #endregion

        #region Methods

        #region Properties
        public static int Id
        {
            set { id = value; }
            get { return id; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        static Project()
        {
            Id = 600;
            
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        public static bool InserirMaterial() 
        {          
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
