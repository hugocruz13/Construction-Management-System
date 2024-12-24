/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/12/2024 3:46:54 PM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using CustomExceptions;
using Interface_Tier;
using Object_Tier;

namespace Data_Tier
{
    /// <summary>
    /// Singleton class that manages the material inventory. Allows adding, removing, updating, and retrieving materials.
    /// </summary>
    [Serializable]
    public class MaterialInventory : IMaterialInventory
    {
        #region Attributes

        /// <summary>
        /// Singleton instance of the MaterialInventory class.
        /// </summary>
        static MaterialInventory instance;

        /// <summary>
        /// List of materials stored in inventory.
        /// </summary>
        static List<MaterialQuantity> inventory;
        #endregion

        #region Methods

        #region Properties
        /// <summary>
        /// Gets the singleton instance of the MaterialInventory class.
        /// </summary>
        public static MaterialInventory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MaterialInventory();
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets or sets the list of materials in the inventory.
        /// </summary>
        internal List<MaterialQuantity> InventoryD
        {
            get { return inventory; }
            set { inventory = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the MaterialInventory class with an empty inventory.
        /// </summary>
        protected MaterialInventory()
        {
            inventory = new List<MaterialQuantity>(5);
        }

        #endregion

        #region OtherMethods

        /// <summary>
        /// Finds a material in the inventory based on the material ID.
        /// </summary>
        /// <param name="idMaterial">The ID of the material to find.</param>
        /// <returns>The material if found, otherwise null.</returns>
        MaterialQuantity FindMaterial(int idMaterial)
        {
            foreach (MaterialQuantity material in inventory)
            {
                if (material.IdMaterial == idMaterial)
                {
                    return material;
                }
            }

            return null;
        }

        /// <summary>
        /// Adds a new material to the inventory.
        /// </summary>
        /// <param name="inventoryQuantity">The material quantity to add to the inventory.</param>
        /// <returns>The ID of the added material.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if the material is null or if any error occurs during the addition.
        /// </exception>
        public int AddMaterial(MaterialQuantity inventoryQuantity)
        {
            if (inventoryQuantity == null)
            {
                throw new ConfigurationErrorException("601");
            }
            try
            {
                inventory.Add(inventoryQuantity);
                return inventoryQuantity.IdMaterial;
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("603", ex);
            }
        }

        /// <summary>
        /// Verifies if a material exists in the inventory based on the material ID.
        /// </summary>
        /// <param name="idMaterial">The ID of the material to verify.</param>
        /// <returns>Returns true if the material exists, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the verification process.
        /// </exception>
        public bool VerifyMaterialExistence(int idMaterial)
        {
            try
            {
                foreach (MaterialQuantity material in inventory)
                {
                    if (material.IdMaterial == idMaterial)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("605", ex);
            }
        }

        /// <summary>
        /// Verifies if there is enough quantity of a material in the inventory.
        /// </summary>
        /// <param name="idMaterial">The ID of the material to check.</param>
        /// <param name="quantity">The quantity of material to check for.</param>
        /// <returns>Returns true if there is enough quantity, otherwise false.</returns>
        public bool VerifyMaterialQuantity(int idMaterial, int quantity)
        {
            MaterialQuantity material = FindMaterial(idMaterial);

            if (material != null)
            {
                if (material.Quantity >= quantity)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Updates the quantity of a material in the inventory.
        /// </summary>
        /// <param name="idMaterial">The ID of the material to update.</param>
        /// <param name="quantityUpdate">The new quantity of the material.</param>
        /// <returns>Returns true if the quantity was updated successfully, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the update process.
        /// </exception>
        public bool UpdateQuantity(int idMaterial, int quantityUpdate)
        {
            try
            {
                MaterialQuantity material = FindMaterial(idMaterial);

                if (material != null)
                {
                    material.Quantity = quantityUpdate;
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("607", ex);
            }

            return false;
        }

        /// <summary>
        /// Decreases the quantity of a material in the inventory when it is used.
        /// </summary>
        /// <param name="idMaterial">The ID of the material to use.</param>
        /// <param name="quantity">The quantity of material to use.</param>
        /// <returns>Returns true if the material quantity was successfully decreased, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the use process.
        /// </exception>
        public bool UseMaterial(int idMaterial, int quantity)
        {
            try
            {
                MaterialQuantity material = FindMaterial(idMaterial);

                if (material != null)
                {
                    material.Quantity -= quantity;
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("608", ex);
            }

            return false;
        }

        /// <summary>
        /// Retrieves the material and its quantity from the inventory based on the material ID.
        /// </summary>
        /// <param name="idMaterial">The ID of the material to retrieve.</param>
        /// <returns>Returns the material quantity object if found, otherwise null.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during retrieval.
        /// </exception>
        public MaterialQuantity GetMaterialQuantity(int idMaterial)
        {
            try
            {
                MaterialQuantity material = FindMaterial(idMaterial);

                if (material != null)
                {
                    return material;
                }
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("617", ex);
            }

            return null;
        }

        #endregion

        #region Destructor
        /// <summary>
        ///  The destroyer of the MaterialInventory class.
        /// </summary>
        ~MaterialInventory()
        {
        }
        #endregion

        #endregion

    }
}
