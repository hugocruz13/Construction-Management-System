/*
*	<copyright file="Material.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/22/2024 6:13:24 PM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;



namespace t
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
        List<MaterialQuantity> use;
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
            use = new List<MaterialQuantity>(5);
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        public bool AddMaterial(short id, int quantity) 
        {
            if (!ExisteMaterial(id))
            {
                use.Add(new MaterialQuantity(id, quantity));
                return true;
            }

            return false;
        }

        private bool ExisteMaterial(short id) 
        {
            for (int i = 0; i < use.Count; i++)
            {
                if (use[i].IdMaterial == id)
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
        ~MaterialProject()
        {
        }
        #endregion

        #endregion

    }
}
