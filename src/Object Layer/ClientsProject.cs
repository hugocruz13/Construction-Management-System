/*
*	<copyright file="Client.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/20/2024 12:14:27 AM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;


namespace Object_Layer
{

    public class ClientsProject
    {
        #region Attributes
        List<int> client;
        #endregion

        #region Methods

        #region Properties


        #endregion

        #region Constructors

        public ClientsProject()
        {
            client = new List<int>(5);
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        public bool AddClient(int idClient)
        {
            if (!ExistClient(idClient))
            {
                client.Add(idClient);
                return true;
            }

            return false;
        }

        private bool ExistClient(int idClient)
        {
            for (int i = 0; i < client.Count; i++)
            {
                if (client[i] == idClient)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~ClientsProject()
        {
        }
        #endregion

        #endregion

    }
}
