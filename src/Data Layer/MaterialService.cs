/*
*	<copyright file="Data_Layer.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>12/10/2024 4:23:55 PM</date>
*	<description></description>
**/
using Object_Tier;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Layer
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 12/10/2024 4:23:55 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    class MaterialService
    {
        #region Attributes
        static MaterialService instance;
        Dictionary<int, List<MaterialQuantity>> use;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        protected MaterialService()
        {
            use = new Dictionary<int, List<MaterialQuantity>>(11);
        }

        #endregion

        #region OtherMethods
        public static MaterialService Instance() 
        {
            if(instance== null)
            {
                instance = new MaterialService();
            }
            return instance;
        }

        public bool AddMaterial(short idProject, MaterialQuantity material)
        {
            if (!use.ContainsKey(idProject))
            {
                use[idProject] = new List<MaterialQuantity>(5);
            }

            use[idProject].Add(material);
            return true;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~MaterialService()
        {
        }
        #endregion

        #endregion

    }
}
