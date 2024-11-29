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

namespace trabalhoPOO_23010
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
        public bool AddClient(int id) 
        {
            client.Add(id);
            return true;
        }

        public void ShowClient()
        {
            foreach (int id in client)
            {
                Console.WriteLine(id.ToString());
            }
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
