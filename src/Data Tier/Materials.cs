/*
*	<copyright file="Material.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/20/2024 1:08:02 PM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using CustomExceptions;
using Object_Tier;
using Interface_Tier;

namespace Data_Tier
{
    /// <summary>
    /// Singleton class that manages the materials in the system. Allows adding, checking, updating, and retrieving materials.
    /// </summary>
    [Serializable]
    public class Materials : IMaterials
    {
        #region Attributes

        /// <summary>
        /// Singleton instance of the Materials class.
        /// </summary>
        static Materials instance;

        /// <summary>
        /// List of materials managed by the Materials class.
        /// </summary>
        static List<Material> materials;
        #endregion

        #region Methods

        #region Properties

        /// <summary>
        /// Gets the singleton instance of the Materials class.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the list of materials.
        /// </summary>
        internal List<Material> MaterialD
        {
            set { materials = value; }
            get { return materials; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Materials class with an empty list of materials.
        /// </summary>
        protected Materials()
        {
            materials = new List<Material>(5);
        }

        #endregion

        #region OtherMethods

        /// <summary>
        /// Finds a material in the list by its ID.
        /// </summary>
        /// <param name="materialId">The ID of the material to find.</param>
        /// <returns>The material if found, otherwise null.</returns>
        Material FindMaterial(int materialId)
        {
            foreach (Material mat in materials)
            {
                if (mat.Id == materialId)
                {
                    return mat;
                }
            }

            return null;
        }

        /// <summary>
        /// Adds a new material to the materials list.
        /// </summary>
        /// <param name="material">The material to add.</param>
        /// <returns>The ID of the added material.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if the material is null or any error occurs during the addition.
        /// </exception>
        public int AddMaterial(Material material)
        {
            if (material == null)
            {
                throw new ConfigurationErrorException("600");
            }
            try
            {
                materials.Add(material);
                return material.Id;
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("602", ex);
            }
        }

        /// <summary>
        /// Checks if a material already exists in the list.
        /// </summary>
        /// <param name="material">The material to check for existence.</param>
        /// <returns>True if the material exists, otherwise false.</returns>
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

        /// <summary>
        /// Checks if a material exists in the list based on its ID.
        /// </summary>
        /// <param name="idMaterial">The ID of the material to check.</param>
        /// <returns>True if the material exists, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the check.
        /// </exception>
        public bool MaterialExist(int idMaterial)
        {
            try
            {
                foreach (Material material in materials)
                {
                    if (material.Id == idMaterial)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("604", ex);
            }
        }

        /// <summary>
        /// Updates the price of a material in the list based on its ID.
        /// </summary>
        /// <param name="idMaterial">The ID of the material to update.</param>
        /// <param name="price">The new price to set.</param>
        /// <returns>True if the price was updated successfully, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the update.
        /// </exception>
        public bool UpdatePrice(int idMaterial, double price)
        {
            try
            {
                Material material = FindMaterial(idMaterial);

                if (material != null)
                {
                    material.UnitPrice = price;
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("606", ex);
            }

            return false;
        }

        /// <summary>
        /// Retrieves a material by its ID.
        /// </summary>
        /// <param name="idMaterial">The ID of the material to retrieve.</param>
        /// <returns>The material if found, otherwise null.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the retrieval.
        /// </exception>
        public Material GetMaterial(int idMaterial)
        {
            try
            {
                Material material = FindMaterial(idMaterial);

                if (material != null)
                {
                    return material;
                }
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("615", ex);
            }
            return null;
        }

        /// <summary>
        /// Sets the counter for materials to the next material ID.
        /// </summary>
        /// <returns>True if the counter is successfully updated, otherwise false.</returns>
        internal bool SetCounterEqualMaterial()
        {
            for (int i = 0; i < materials.Count; i++)
            {
                Material.getNextMaterialId();
            }

            return true;
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
