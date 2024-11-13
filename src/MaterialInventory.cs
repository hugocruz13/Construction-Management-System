/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/12/2024 3:46:54 PM</date>
*	<description></description>
**/
using System;

namespace src
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 11/12/2024 3:46:54 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class MaterialInventory
    {
        #region Attributes
        const int sizeArrays = 20;
        static MaterialQuantity[] inventory;
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        static MaterialInventory()
        {
            inventory = new MaterialQuantity[sizeArrays];
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
        ~MaterialInventory()
        {
        }
        #endregion

        #endregion

    }
}
