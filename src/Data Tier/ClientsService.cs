/*
*	<copyright file="Data_Tier.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>12/5/2024 4:38:45 PM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using CustomExceptions;

namespace Data_Tier
{
    /// <summary>
    /// Service class that manages clients associated with a project.
    /// </summary>
    [Serializable]
    internal class ClientsService
    {
        #region Attributes

        /// <summary>
        /// List of client IDs associated with a project.
        /// </summary>
        List<int> clients;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientsService"/> class.
        /// </summary>
        public ClientsService()
        {
            clients = new List<int>(5);
        }

        #endregion

        #region OtherMethods

        /// <summary>
        /// Checks if a client is already associated with the project.
        /// </summary>
        /// <param name="clientId">The ID of the client to check.</param>
        /// <returns>True if the client is already associated; otherwise, false.</returns>
        bool ExistClient(int clientId)
        {
            return clients.Contains(clientId);
        }

        /// <summary>
        /// Adds a client to the list of clients for the project.
        /// </summary>
        /// <param name="clientId">The ID of the client to add.</param>
        /// <returns>True if the client was added successfully; otherwise, false.</returns>
        /// <exception cref="ConfigurationErrorException">Thrown if an error occurs during the addition of the client.</exception>
        public bool AddClient(int clientId)
        {
            try
            {
                if (!ExistClient(clientId))
                {
                    clients.Add(clientId);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("806", ex);
            }

            return false;
        }

        /// <summary>
        /// Removes a client from the list of clients for the project.
        /// </summary>
        /// <param name="clientId">The ID of the client to remove.</param>
        /// <returns>True if the client was removed successfully; otherwise, false.</returns>
        /// <exception cref="ConfigurationErrorException">Thrown if an error occurs during the removal of the client.</exception>
        public bool RemoveClient(int clientId)
        {
            try
            {
                if (ExistClient(clientId))
                {
                    clients.Remove(clientId);
                    return true;
                }
            }

            catch (Exception ex)
            {
                throw new ConfigurationErrorException("807", ex);
            }

            return false;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~ClientsService()
        {
        }
        #endregion

        #endregion

    }
}
