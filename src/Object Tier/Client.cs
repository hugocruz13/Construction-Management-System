/*
*	<copyright file="Client.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/3/2024 7:20:50 PM</date>
*	<description>This file is focused on creating client objects.</description>
*/
using System;

namespace Object_Tier
{
    /// <summary>
    /// Represents a client in the system, inheriting from the Person class.
    /// </summary>
    [Serializable]
    public class Client : Person
    {
        #region Attributes

        /// <summary>
        /// Stores the contact information of the client.
        /// </summary>
        int contactInfo;

        /// <summary>
        /// Static counter to generate unique client IDs. Starts at 500.
        /// </summary>
        [NonSerialized]
        static int clientIdCounter = 500;
        #endregion

        #region Methods

        #region Properties
        /// <summary>
        /// Gets or sets the client’s contact information.
        /// One contact can only have 9 numbers
        /// </summary>
        public int ContactInfo
        {
            set
            {
                if (value >= 9)
                {
                    contactInfo = value;
                }
            }
            get { return contactInfo; }
        }
        #endregion

        #region Constructors

        /// <summary>
        ///  Initializes a new instance of the Client class with the specified name and contact.
        ///  Automatically assigns a unique ID.
        /// </summary>
        /// <param name="name">The name of the client.</param>
        /// <param name="contact">The contact information of the client.</param>
        public Client(string name, int contact) : base(clientIdCounter++, name) //Send to the construct person.
        {
            ContactInfo = contact;
        }
        #endregion

        #region Overrides

        /// <summary>
        ///  Determines whether the specified object is equal to the current client.
        ///  Clients are considered equal if their contact information matches.
        /// </summary>
        /// <param name="obj">The object to compare with the current client.</param>
        /// <returns>True if the objects are equal; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Client)
            {
                Client otherClient = obj as Client;

                if (contactInfo == otherClient.contactInfo)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns a string representation of the client, including ID, name, and contact.
        /// </summary>
        /// <returns>A string representation of the client.</returns>
        public override string ToString()
        {
            return Id + " " + Name + " " + ContactInfo;
        }
        #endregion

        #region OtherMethods

        /// <summary>
        /// Creates a new Client instance.
        /// </summary>
        /// <param name="name">The name of the client.</param>
        /// <param name="contact">The contact information of the client.</param>
        /// <returns>A new Client instance.</returns>
        public static Client CreateClient(string name, int contact)
        {
            return new Client(name, contact);
        }

        /// <summary>
        /// Checks if two clients are equal using the "-" operator.
        /// </summary>
        /// <param name="client1">The first client.</param>
        /// <param name="client2">The second client.</param>
        /// <returns>True if the clients are equal; otherwise, false.</returns>
        public static bool operator -(Client client1, Client client2)
        {
            if (client1.Equals(client2))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if two clients are not equal using the "+" operator.
        /// </summary>
        /// <param name="client1">The first client.</param>
        /// <param name="client2">The second client.</param>
        /// <returns>True if the clients are not equal; otherwise, false.</returns>
        public static bool operator +(Client client1, Client client2)
        {
            return !(client1 - client2);
        }

        /// <summary>
        /// Increments the static client ID counter.
        /// </summary>
        public static bool getNextClientId()
        {
            clientIdCounter++;
            return true;
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
