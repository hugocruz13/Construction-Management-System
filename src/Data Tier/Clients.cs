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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Object_Tier;
using CustomExceptions;
using Interface_Tier;
using System.Diagnostics.Contracts;
using System.Net.Sockets;
using System.Linq;

namespace Data_Tier
{
    [Serializable]
    public class Clients : IClients
    {
        #region Attributes
        static Clients instance;
        static List<Client> clients;
        #endregion

        #region Methods

        #region Properties
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

        internal List<Client> ClientsD
        {
            set { clients = value; }
        }
        #endregion

        #region Constructors
        protected Clients()
        {
            clients = new List<Client>(5);
        }
        #endregion

        #region OtherMethods
        public int AddClient(Client client)
        {
            clients.Add(client);
            clients.Sort();
            return client.Id;
        }

        public bool RemoveClient(int idClient)
        {
            Client client = clients.FirstOrDefault(c => idClient == c.Id);

            if (client != null)
            {
                clients.Remove(client);
                clients.Sort();
                return true;
            }


            return false;
        }

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

        public bool ExistClient(int idClient)
        {
            return clients.Any(client => client.Id == idClient);
        }

        public bool UpdateContact(int idClient, int contacto)
        {
            Client client = clients.FirstOrDefault(c => c.Id == idClient);

            if (client != null)
            {
                client.ContactInfo = contacto;
                return true;
            }

            return false;
        }

        public Client GetClient(int idClient)
        {
            return clients.FirstOrDefault(c => c.Id == idClient);
        }

        internal List<Client> GetListToSave() 
        {
            return clients;
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
