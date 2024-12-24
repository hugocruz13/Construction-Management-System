/*
*	<copyright file="Data_Layer.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>12/10/2024 4:23:55 PM</date>
*	<description></description>
**/
using CustomExceptions;
using Object_Tier;
using System;
using System.Collections.Generic;

namespace Data_Layer
{
    /// <summary>
    /// Class for managing materials used in a project.
    /// </summary>
    [Serializable]
    class MaterialService
    {
        #region Attributes

        /// <summary>
        /// List of materials used in the project.
        /// </summary>
        List<MaterialQuantity> use;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the MaterialService class.
        /// </summary>
        public MaterialService()
        {
            use = new List<MaterialQuantity>(5);
        }

        #endregion

        #region OtherMethods

        /// <summary>
        /// Finds the material in the list of used materials.
        /// </summary>
        /// <param name="material">The material to find.</param>
        /// <returns>The material if found, otherwise null.</returns>
        MaterialQuantity FindMaterial(MaterialQuantity material)
        {
            foreach (MaterialQuantity materialQ in use)
            {
                if (ExistExistEmployee(material))
                {
                    return materialQ;
                }
            }

            return null;
        }

        /// <summary>
        /// Checks if the specified material exists in the list of used materials.
        /// </summary>
        /// <param name="material">The material to check for existence.</param>
        /// <returns>True if the material exists in the list, otherwise false.</returns>
        public bool ExistExistEmployee(MaterialQuantity material)
        {
            return use.Contains(material);
        }

        /// <summary>
        /// Adds a material to the list of used materials. If the material already exists, its quantity is updated.
        /// </summary>
        /// <param name="material">The material to add or update.</param>
        /// <returns>True if the material was added or updated successfully; otherwise, false.</returns>
        /// <exception cref="ConfigurationErrorException">Thrown if an error occurs during material addition.</exception>
        public bool AddMaterial(MaterialQuantity material)
        {
            try
            {
                if (!ExistExistEmployee(material))
                {
                    use.Add(material);
                    return true;
                }
                else
                {
                    MaterialQuantity materialQuantity = FindMaterial(material);
                    materialQuantity.Quantity += material.Quantity;
                    materialQuantity.Date = DateTime.Now;
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("814", ex);
            }
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
