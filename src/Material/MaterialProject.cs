/*
*	<copyright file="Material.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/22/2024 6:13:24 PM</date>
*	<description></description>
**/
using System;

namespace trabalhoPOO_23010
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 11/22/2024 6:13:24 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class MaterialProject
    {
        #region Attributes
        MaterialQuantity[] use; 
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public MaterialProject()
        {
            use = new MaterialQuantity[10];
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
        ~MaterialProject()
        {
        }
        #endregion

        #endregion

    }
}
