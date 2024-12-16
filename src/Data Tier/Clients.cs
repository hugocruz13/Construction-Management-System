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

namespace Data_Tier
{
    [Serializable]
    public class Clients
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
        #endregion

        #region Constructors
        protected Clients()
        {
            clients = new List<Client>(5);
        }
        #endregion

        #region OtherMethods
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
                clients = (List<Client>)b.Deserialize(s);
                s.Close();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Algo aconteceu ");
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
