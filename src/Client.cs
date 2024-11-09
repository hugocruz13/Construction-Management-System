/*
*	<copyright file="Client.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/3/2024 7:20:50 PM</date>
*	<description>This file is focused on creating client objects (Client).</description>
*/
using System;

namespace src
{
    /// <summary>
    /// The <c>Client</c> class allows you to create a client object
    /// with basic information such as ID, name and contact information.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="Person"/> and provides methods to access and modify 
    /// the client attributes, and assign an ID automatically using a static counter.
    /// </remarks>
    /// <example>
    /// Example of use
    /// <code>
    /// Client c = new Client("Maria Rodrigues", "9323423553")
    /// </code>
    /// </example>
    public class Client : Person
    {
        #region Attributes
        /// <summary>
        /// Customer contact information.
        /// </summary>
        string contactInfo;
        /// <summary>
        /// Static counter to assign unique IDs to clients.
        /// </summary>
        static int clientIdCounter = 500;
        #endregion

        #region Methods

        #region Properties
        /// <summary>
        /// Gets or sets the customer’s contact information.
        /// </summary>
        /// <value>The customer’s contact information</value>
        /// <permission>
        /// Public Access.
        /// </permission>
        public string ContactInfo
        {
            set  { contactInfo = value; }
            get { return contactInfo; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Default builder for the client.
        /// Automatically assigns an ID and initializes the other attributes with default values.
        /// </summary>
        /// <remarks>
        /// The ID is automatically generated with the static counter.
        /// The name and contact information are initialized as empty.
        /// </remarks>
        /// <permission>
        /// Public Access.
        /// </permission>
        public Client()
        {
            Id = clientIdCounter++;
            Name = string.Empty;
            ContactInfo = string.Empty;

        }

        /// <summary>
        /// Simple constructor to initialize or client with specific values.
        /// </summary>
        /// <param name="name">Name of customer.</param>
        /// <param name="contact">Customer contact information.</param>
        /// <remarks>
        /// Initializes the client with a given name and contact information.
        /// The ID is assigned automatically using the static counter.
        /// </remarks>
        /// <permission>
        /// Public Access.
        /// </permission>
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
        /// The destroyer of the Client class.
        /// </summary>
        ~Client()
        {
        }
        #endregion

        #endregion

    }
}
