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

namespace trabalhoPOO_23010
{

    public class Clients
    {
        #region Attributes

        static Dictionary<int, List<Client>> clients;

        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Constructors

        static Clients()
        {
            clients = new Dictionary<int, List<Client>>(11);
        }

        #endregion

        #region OtherMethods
        internal static int GenerateKey(short idClient)
        {
            return idClient % 11;
        }

        public static short AddClient(Client client)
        {
            if (!ClientExists(client))
            {
                int key = GenerateKey(client.Id);

                if (!clients.ContainsKey(key))
                {
                    clients[key] = new List<Client>(5);
                }

                clients[key].Add(client);
                return client.Id;
            }

            return -17;

        }

        //Com base no equals 
        internal static bool ClientExists(Client client)
        {
            foreach (List<Client> clientList in clients.Values)
            {
                foreach (Client existingClient in clientList)
                {
                    if (existingClient - client)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool ClientExists(short idCliente)
        {
            int key = GenerateKey(idCliente);

            if (clients.ContainsKey(key))
            {
                foreach (Client clientInstance in clients[key])
                {
                    if (clientInstance.Id == idCliente)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        public static bool UpdateContact(short idClient, string contacto)
        {
            int key = GenerateKey(idClient);

            if (clients.ContainsKey(key))
            {
                foreach (Client client in clients[key])
                {
                    if (client.Id == idClient)
                    {
                        client.ContactInfo = contacto;
                        return true;
                    }
                }
            }

            return false;
        }

        public static void ShowClients()
        {
            foreach (List<Client> clientList in clients.Values)
            {
                foreach (Client client in clientList)
                {
                    Console.WriteLine(client.ToString());
                }
            }
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
