/*
*	<copyright file="Clients.cs" company="IPCA">
*		Copyright (clientInstance) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/12/2024 3:44:27 PM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;

using Object_Tier;
using CustomExceptions;
using Interface_Tier;

namespace Data_Tier
{
    /// <summary>
    /// Singleton class that manages the list of clients. Allows adding, removing, updating and retrieving clients.
    /// </summary>
    [Serializable]
    public class Clients : IClients
    {
        #region Attributes

        /// <summary>
        /// Singleton instance of the Clients class.
        /// </summary>
        static Clients instance;

        /// <summary>
        /// List of clients stored in memory.
        /// </summary>
        static List<Client> clients;
        #endregion

        #region Methods

        #region Properties

        /// <summary>
        /// Gets the singleton instance of the Clients class.
        /// </summary>
        public static Clients Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Clients();
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets or sets the list of clients.
        /// </summary>
        internal List<Client> ClientsD
        {
            get { return clients; }
            set { clients = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Clients class, with an empty list of clients.
        /// </summary>
        protected Clients()
        {
            clients = new List<Client>(5);
        }
        #endregion

        #region OtherMethods

        /// <summary>
        /// Finds a client in the list based on the client ID.
        /// </summary>
        /// <param name="idClient">The ID of the client to find.</param>
        /// <returns>Returns the client if found, otherwise null.</returns>
        Client FindClient(int idClient)
        {
            foreach (Client client in clients)
            {
                if (client.Id == idClient)
                {
                    return client;
                }
            }

            return null;
        }

        /// <summary>
        /// Adds a new client to the list of clients and sorts the list.
        /// </summary>
        /// <param name="client">he client to add to the list.</param>
        /// <returns>The ID of the added client.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if the client is null or if any error occurs during the addition.
        /// </exception>
        public int AddClient(Client client)
        {
            if (client == null)
            {
                throw new ConfigurationErrorException("100");
            }

            try
            {
                clients.Add(client);
                clients.Sort();
                return client.Id;
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("101", ex);
            }
        }

        /// <summary>
        /// Removes a client from the list based on the client ID.
        /// </summary>
        /// <param name="idClient">The ID of the client to remove.</param>
        /// <returns>Returns true if the client is successfully removed, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the removal of the client.
        /// </exception>
        public bool RemoveClient(int idClient)
        {
            try
            {
                Client client = FindClient(idClient);

                if (client != null)
                {
                    clients.Remove(client);
                    clients.Sort();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("102", ex);
            }

            return false;
        }

        /// <summary>
        /// Checks if a specific client exists in the list by comparing with another client object.
        /// </summary>
        /// <param name="client">The client to check for existence in the list.</param>
        /// <returns>Returns true if the client exists, otherwise false.</returns></returns>
        public bool ExistClient(Client client)
        {
            foreach (Client existingClient in clients)
            {
                if (existingClient - client)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if a client exists in the list based on the client ID.
        /// </summary>
        /// <param name="idClient">The ID of the client to check for existence.</param>
        /// <returns>Returns true if the client exists, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs while checking for existence.
        /// </exception>
        public bool ExistClient(int idClient)
        {
            try
            {
                foreach (Client client in clients)
                {
                    if (client.Id == idClient)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("103", ex);
            }
        }

        /// <summary>
        /// Updates the contact information of a client based on the client ID.
        /// </summary>
        /// <param name="idClient">The ID of the client to update.</param>
        /// <param name="contacto">The new contact information to set for the client.</param>
        /// <returns>Returns true if the contact information was updated successfully, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the update process.
        /// </exception>
        public bool UpdateContact(int idClient, int contacto)
        {
            try
            {
                Client client = FindClient(idClient);

                if (client != null)
                {
                    client.ContactInfo = contacto;
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("105", ex);
            }

            return false;
        }

        /// <summary>
        /// Retrieves a client from the list based on the client ID.
        /// </summary>
        /// <param name="idClient">The ID of the client to retrieve.</param>
        /// <returns>Returns the client object with the specified ID, or null if the client is not found.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs while retrieving the client.
        /// </exception>
        public Client GetClient(int idClient)
        {
            try
            {
                return FindClient(idClient);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("115", ex);
            }
        }

        /// <summary>
        /// Resets the client ID counter to ensure all clients have unique IDs by calling the `getNextClientId()` method for each client.
        /// </summary>
        /// <returns>Returns true if the client ID counter was successfully updated for all clients.</returns>
        internal bool SetCounterEqualClient()
        {
            for (int i = 0; i < clients.Count; i++)
            {
                Client.getNextClientId();
            }

            return true;
        }

        #endregion

        #region Destructor
        /// <summary>
        /// The destroyer of the Clients class.
        /// </summary>
        ~Clients()
        {
        }
        #endregion

        #endregion

    }
}
