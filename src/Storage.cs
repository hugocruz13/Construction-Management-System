/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/6/2024 12:13:22 PM</date>
*	<description></description>
**/
using System;

namespace src
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 11/6/2024 12:13:22 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Storage
    {
        #region Attributes
        static Material[] storage;
        static int total;
        const int max = 30;
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        static Storage()
        {
            storage = new Material[max];
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        public static bool AddMaterial(Material m) 
        {
            storage[total++] = m;
            return true;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Storage()
        {
        }
        #endregion

        #endregion

    }
}
