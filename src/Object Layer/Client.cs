/*
*	<copyright file="Client.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/3/2024 7:20:50 PM</date>
*	<description>This file is focused on creating client objects.</description>
*/
using System;

namespace Object_Layer
{
    /// <summary>
    /// The <c>Client</c> class allows you to create a client object
    /// with basic information such as id, name and contact information.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="Person"/> and provides methods to access and modify 
    /// the client attributes, and assign an Id automatically using a static counter.
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

        string contactInfo;


        static short clientIdCounter = 500;

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
            set
            {
                if (value.Length >= 9)
                {
                    contactInfo = value;
                }
            }
            get { return contactInfo; }
        }
        #endregion

        #region Constructors
        public Client(string name, string contact) : base(clientIdCounter++, name) //Send to the construct person.
        {
            ContactInfo = contact.Trim();
        }

        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Client)
            {
                Client otherClient = obj as Client;

                if (contactInfo == otherClient.contactInfo && Name == otherClient.Name)
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return Id + " " + Name + " " + ContactInfo;
        }
        #endregion

        #region OtherMethods

        public static bool operator -(Client client1, Client client2)
        {
            if (client1.Equals(client2))
            {
                return true;
            }

            return false;
        }

        public static bool operator +(Client client1, Client client2)
        {
            return !(client1 - client2);
        }
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
