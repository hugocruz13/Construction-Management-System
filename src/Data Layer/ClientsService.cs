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
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 12/5/2024 4:38:45 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ClientsService
    {
        #region Attributes
        static Dictionary<int, List<int>> clients;
        #endregion

        #region Methods


        #region Constructors

        static ClientsService()
        {
            clients = new Dictionary<int, List<int>>(17);
        }

        #endregion

        #region OtherMethods
        public static bool AddClient(int projectId, int clientId)
        {
            if (!clients.ContainsKey(projectId))
            {
                clients[projectId] = new List<int>(5);
            }

            if (!ExistClient(projectId,clientId))
            {
                clients[projectId].Add(clientId);
                return true;
            }

            return false;
        }

        public static bool ExistClient(int projectId, int clientId) 
        {
            if (!clients.ContainsKey(projectId))
            {
                throw new Execeptions("Project não existe");
            }

            return clients[projectId].Contains(clientId);
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
