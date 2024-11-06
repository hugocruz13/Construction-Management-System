/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/3/2024 7:20:40 PM</date>
*	<description></description>
**/
using System;

namespace src
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 11/3/2024 7:20:40 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    class Person
    {
        #region Attributes
        int id;
        string name;
        #endregion

        #region Methods

        #region Properties
        /// <summary>
        /// Employee unique id.
        /// </summary>
        /// <permission>
        /// Public Access
        /// </permission>
        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        /// <summary>
        /// Employee name.
        /// </summary>
        /// <permission>
        /// Public Access
        /// </permission>
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Person()
        {
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
        ~Person()
        {
        }
        #endregion

        #endregion
    }
}
