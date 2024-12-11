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
using Data_Layer;

namespace Data_Tier
{

    public class Clients : IClients
    {
        #region Attributes
        static Clients instance;
        List<Client> clients;
        #endregion

        #region Methods
        #region Constructors

        protected Clients()
        {
            clients = new List<Client>(5);
        }

        #endregion


        #region OtherMethods
        public static Clients Instance()
        {
            if (instance == null)
            {
                instance = new Clients();
            }

            return instance;

        }

        public short AddClient(Client client)
        {
            clients.Add(client);
            clients.Sort();
            return client.Id;
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

        public bool ExistClient(short idCliente)
        {
            foreach (Client clientInstance in clients)
            {
                if (clientInstance.Id == idCliente)
                {
                    return true;
                }
            }

            return false;
        }

        public bool UpdateContact(short idClient, int contacto)
        {
            foreach (Client client in clients)
            {
                if (client.Id == idClient)
                {
                    client.ContactInfo = contacto;
                    return true;
                }
            }

            return false;
        }

        //public bool Save(string path)
        //{
        //    Stream fs = new FileStream(path, FileMode.Create);
        //    BinaryFormatter binaryFormatter = new BinaryFormatter();
        //    binaryFormatter.Serialize(fs, clients);
        //    clients.Clear();
        //    return true;
        //}

        //public static bool Load(string path)
        //{
        //    Stream s = File.Open(path, FileMode.Open, FileAccess.Read);
        //    BinaryFormatter b = new BinaryFormatter();
        //    clients = b.Deserialize(s) as List<Client>;
        //    return true;
        //}

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
