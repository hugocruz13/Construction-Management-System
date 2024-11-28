/*
*	<copyright file="Client.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/20/2024 12:14:27 AM</date>
*	<description></description>
**/
using System;

namespace trabalhoPOO_23010
{

    public class ClientsProject
    {
        #region Attributes

        int[] client;

        #endregion

        #region Methods

        #region Properties

        public int[] Client
        {
            get { return (int[])client.Clone(); }

        }

        #endregion

        #region Constructors

        public ClientsProject(int x)
        {
            client = new int[x];
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
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
