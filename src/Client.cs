/*
*	<copyright file="Person.cs" company="IPCA">
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

        public string ContactInfo
        {
            set { contactInfo = value; }
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

        public Client(string name, string contact)
        {
            Id = clientIdCounter++;
            Name = name;
            ContactInfo = contact;

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
