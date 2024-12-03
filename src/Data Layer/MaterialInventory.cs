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
using System.Diagnostics;

using Object_Layer;

namespace Data_Layer
{
    /// <summary>
    /// Represents a inventory with a fixed maximum capacity.
    /// </summary>
    /// <remarks>
    /// This class is designed to store instances of the <c>MaterialQuantity</c> class in a fixed-size array, defined by the constant <c>sizeArrays</c>.
    /// The array is statically initialized upon first access to the <c>MaterialInventory</c> class.
    /// </remarks>
    /// <example>
    /// Example of use
    /// <code>
    /// MaterialInventory inventory 
    /// MaterialInventory.AddMaterial(new MaterialQuantity("Cimento", 4.80, 5))
    /// </code>
    /// </example>
    public class MaterialInventory
    {
        #region Attributes

        /// <summary>
        /// Array that stores instances of <c>MaterialQuantity</c> objects.
        /// </summary>
        static Dictionary<int, List<MaterialQuantity>> inventory;
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the <c>MaterialInventory</c> class by setting up the meterial array.
        /// </summary>
        /// <remarks>
        /// This static constructor is called only once, when the <c>MaterialInventory</c> class is accessed for the first time. 
        /// It initializes the <c>inventory</c> array with a predefined size.
        /// </remarks>
        /// <example>
        /// Accessing any member of the <c>MaterialInventory</c> class will trigger this constructor if it hasn't been initialized.
        /// </example>
        static MaterialInventory()
        {
            inventory = new Dictionary<int, List<MaterialQuantity>>(11);
        }

        #endregion

        #region OtherMethods
        /// <summary>
        /// Adds a material to the inventory if it does not already exist.
        /// </summary>
        /// <param name="inventoryQuantity">The <c>MaterialQuantity</c> instance to add to the inventory.</param>
        /// <returns>The ID of the material if added successfully; otherwise, returns -10 if the material already exists or if there is no available space.</returns>
        internal static int GenerateKey(short idMaterial)
        {
            return idMaterial % 11;
        }

        public static short AddMaterial(MaterialQuantity inventoryQuantity)
        {
            if (!VerifyMaterialExistence(inventoryQuantity) && inventoryQuantity.IdMaterial != -11)
            {
                int key = GenerateKey(inventoryQuantity.IdMaterial);

                if (!inventory.ContainsKey(key))
                {
                    inventory[key] = new List<MaterialQuantity>(5);
                }

                inventory[key].Add(inventoryQuantity);
                return inventoryQuantity.IdMaterial;
            }
            return -10;
        }


        internal static bool VerifyMaterialExistence(MaterialQuantity inventoryQuantity)
        {
            foreach (List<MaterialQuantity> inventoryList in inventory.Values)
            {
                foreach (MaterialQuantity existingMaterial in inventoryList)
                {
                    if (existingMaterial - inventoryQuantity)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool VerifyMaterialExistence(short idMaterial)
        {
            int key = GenerateKey(idMaterial);

            if (inventory.ContainsKey(key))
            {
                foreach (MaterialQuantity materialInstance in inventory[key])
                {
                    if (materialInstance.IdMaterial == idMaterial)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        /// <summary>
        /// Updates the stock quantity of a material in the inventory.
        /// </summary>
        /// <param name="idMaterial">The ID of the material to update.</param>
        /// <param name="quantityUpdate">The new quantity to set.</param>
        /// <returns><c>true</c> if the update is successful; otherwise, <c>false</c> if the material is not found.</returns>
        public static bool UpdateQuantity(short idMaterial, int quantityUpdate)
        {
            int key = GenerateKey(idMaterial);

            if (inventory.ContainsKey(key))
            {
                foreach (MaterialQuantity materialInstance in inventory[key])
                {
                    if (materialInstance.IdMaterial == idMaterial)
                    {
                        materialInstance.Quantity = quantityUpdate;
                        return true;
                    }
                }
            }

            return false;
        }


        ///// <summary>
        ///// Decreases the quantity of a material in the inventory by a specified amount if there is sufficient stock.
        ///// </summary>
        ///// <param name="idMaterial">The ID of the material to use.</param>
        ///// <param name="quantity">The quantity to reduce from the stock.</param>
        ///// <returns><c>true</c> if the material was used successfully; otherwise, <c>false</c> if the material does not exist or there is insufficient stock.</returns>
        public static bool UseMaterial(short idMaterial, int quantity)
        {
            int key = GenerateKey(idMaterial);

            if (inventory.ContainsKey(key))
            {
                foreach (MaterialQuantity materialInstance in inventory[key])
                {
                    if (materialInstance.IdMaterial == idMaterial && materialInstance.Quantity >= quantity)
                    {
                        materialInstance.Quantity -= quantity;
                        return true;
                    }
                }
            }

            return false;
        }

        public static void ShowInventory()
        {
            foreach (List<MaterialQuantity> inventoryList in inventory.Values)
            {
                foreach (MaterialQuantity existingMaterial in inventoryList)
                {
                    Console.WriteLine(existingMaterial.ToString());
                }
            }
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
