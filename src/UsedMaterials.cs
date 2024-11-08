/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/8/2024 3:55:27 PM</date>
*	<description></description>
**/
using System;

namespace src
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 11/8/2024 3:55:27 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class UsedMaterials
    {
        #region Attributes
        const int sizeArrays = 20;
        static MaterialQuantity[] usedMaterials;
        static int total = 0;
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        static UsedMaterials()
        {
            usedMaterials = new MaterialQuantity[sizeArrays];
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        public static bool AddMaterial(Material m, int quantity) 
        {
            MaterialQuantity mq = new MaterialQuantity(m, quantity);
            usedMaterials[total++] = mq;
            return true;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~UsedMaterials()
        {
        }
        #endregion

        #endregion

    }
}
