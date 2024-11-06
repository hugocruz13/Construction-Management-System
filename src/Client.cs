/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/3/2024 7:20:50 PM</date>
*	<description></description>
*/
using System;

namespace src
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 11/3/2024 7:20:50 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>

    class Client : Person
    {
        #region Attributes
        string contactInfo;
        static int clientIdCounter = 500;
        #endregion

        #region Methods

        #region Properties
<<<<<<< HEAD
        public string ContactInfo
        {
            set { contactInfo = value; }
=======
        public string ContactInfo 
        {
            set { contactInfo = value; }    
>>>>>>> 969c9cbb8d752322acd590eca6e0194657d8a968
            get { return contactInfo; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Client()
        {
            Id = clientIdCounter++;
            Name = string.Empty;
            ContactInfo = string.Empty;

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
        ~Client()
        {
        }
        #endregion

        #endregion

    }
}
