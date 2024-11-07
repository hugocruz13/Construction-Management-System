/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/7/2024 6:31:22 PM</date>
*	<description></description>
**/
using System;

namespace src
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 11/7/2024 6:31:22 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Inventory
    {
        #region Attributes
        const int x = 20;
        static MaterialQuantity[] inventory;
        static int contador = 0;
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        static Inventory()
        {
            inventory = new MaterialQuantity[x];
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        public static bool AddMaterial(Material mat, int quant)
        {
            MaterialQuantity mq = new MaterialQuantity(mat, quant);
            inventory[contador++] = mq;
            return true;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Inventory()
        {
        }
        #endregion

        #endregion

    }
}
