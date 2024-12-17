﻿/*
*	<copyright file="Material.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/20/2024 1:08:02 PM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CustomExceptions;
using Object_Tier;

namespace Data_Tier
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 11/20/2024 1:08:02 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [Serializable]
    public class Materials
    {
        #region Attributes
        static Materials instance;
        static List<Material> materials;
        #endregion

        #region Methods

        #region Properties
        public static Materials Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Materials();
                }

                return instance;
            }
        }

        internal List<Material> MaterialD
        {
            set { materials = value; }
            get { return materials; }
        }
        #endregion

        #region Constructors

        protected Materials()
        {
            materials = new List<Material>(5);
        }

        #endregion

        #region OtherMethods
        public int AddMaterial(Material material)
        {
            materials.Add(material);
            return material.Id;
        }

        public bool MaterialExist(Material material)
        {

            foreach (Material existingMaterial in materials)
            {
                if (existingMaterial - material)
                {
                    return true;
                }
            }
            return false;
        }

        public bool MaterialExist(int idMaterial)
        {

            foreach (Material materialInstance in materials)
            {
                if (materialInstance.Id == idMaterial)
                {
                    return true;
                }
            }
            return false;
        }

        public bool UpdatePrice(int idMaterial, double price)
        {

            foreach (Material materialInstance in materials)
            {
                if (materialInstance.Id == idMaterial)
                {
                    materialInstance.UnitPrice = price;
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
        ~Materials()
        {
        }
        #endregion

        #endregion

    }
}
