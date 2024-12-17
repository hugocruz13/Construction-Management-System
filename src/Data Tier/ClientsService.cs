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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CustomExceptions;
using Object_Tier;

namespace Data_Tier
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 12/5/2024 4:38:45 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [Serializable]
    internal class ClientsService
    {
        #region Attributes
        static ClientsService instance;
        static Dictionary<int, List<int>> clients;
        #endregion

        #region Methods

        #region Properties
        public static ClientsService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClientsService();
                }

                return instance;
            }
        }

        internal Dictionary<int, List<int>> ClientsDS
        {
            set { clients = value; }
        }
        #endregion

        #region Constructors

        protected ClientsService()
        {
            clients = new Dictionary<int, List<int>>(17);
        }

        #endregion

        #region OtherMethods

        public bool ExistClient(int projectId, int clientId)
        {
            return clients[projectId].Contains(clientId);
        }

        public bool AddClient(int projectId, int clientId)
        {
            if (!clients.ContainsKey(projectId))
            {
                clients[projectId] = new List<int>(5);
            }

            if (!ExistClient(projectId, clientId))
            {
                clients[projectId].Add(clientId);
                return true;
            }

            return false;
        }

        public bool RemoveClient(int projectId, int clientId)
        {
            if (clients.ContainsKey(projectId))
            {
                if (ExistClient(projectId, clientId))
                {
                    clients[projectId].Remove(clientId);
                    return true;
                }
            }

            return false;
        }

        public bool Save(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ConfigurationErrorException("Caminho invalido");
            }

            try
            {
                Stream fs = new FileStream(path, FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, clients);
                fs.Close();
                clients.Clear();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Algo aconteceu ");
            }

        }


        public bool Load(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ConfigurationErrorException("Caminho invalido");
            }
            try
            {
                Stream s = File.Open(path, FileMode.Open, FileAccess.Read);
                BinaryFormatter b = new BinaryFormatter();
                clients = (Dictionary<int, List<int>>)b.Deserialize(s);
                s.Close();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Algo aconteceu ");
            }
        }

        internal Dictionary<int, List<int>> GetDataToSave()
        {
            return clients;
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
