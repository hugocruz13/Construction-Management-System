/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/12/2024 3:46:54 PM</date>
*	<description></description>
**/
using System;

namespace trabalhoPOO_23010
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
        /// The fixed size of the <c>inventory</c> array.
        /// </summary>
        const int sizeArrays = 20;

        /// <summary>
        /// Array that stores instances of <c>MaterialQuantity</c> objects.
        /// </summary>
        static MaterialQuantity[] inventory;
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
            inventory = new MaterialQuantity[sizeArrays];
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        /// <summary>
        /// Adds a material to the inventory if it does not already exist.
        /// </summary>
        /// <param name="inventoryQuantity">The <c>MaterialQuantity</c> instance to add to the inventory.</param>
        /// <returns>The ID of the material if added successfully; otherwise, returns -10 if the material already exists or if there is no available space.</returns>
        public static int AddMaterial(MaterialQuantity inventoryQuantity)
        {
            if (!VerifyMaterialExistence(inventoryQuantity.IdMaterial))
            {
                for (int i = 0; i < inventory.Length; i++)
                {
                    while (inventory[i] == null)
                    {
                        inventory[i] = inventoryQuantity;
                        return inventory[i].IdMaterial;
                    }
                }
            }
            return -10;
        }


        /// <summary>
        /// Checks if a material with a specific ID exists in the inventory.
        /// </summary>
        /// <param name="idMaterial">The ID of the material to verify.</param>
        /// <returns><c>true</c> if the material exists; otherwise, <c>false</c>.</returns>
        public static bool VerifyMaterialExistence(int idMaterial)
        {
            for (int i = 0; i < inventory.Length; i++)
            {

                if (inventory[i] == null)
                {
                    break;
                }

                if (inventory[i].IdMaterial == idMaterial)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the quantity of a material in the inventory based on its ID.
        /// </summary>
        /// <param name="idMaterial">The ID of the material.</param>
        /// <returns>The quantity of the material if it exists; otherwise, returns -10 if the material is not found.</returns>
        public static int GetQuantity(int idMaterial)
        {
            if (!VerifyMaterialExistence(idMaterial))
            {
                return -10;
            }
            int position = FindMaterial(idMaterial);
            return inventory[position].Quantity;
        }

        /// <summary>
        /// Updates the stock quantity of a material in the inventory.
        /// </summary>
        /// <param name="idMaterial">The ID of the material to update.</param>
        /// <param name="quantityUpdate">The new quantity to set.</param>
        /// <returns><c>true</c> if the update is successful; otherwise, <c>false</c> if the material is not found.</returns>
        public static bool UpdateStock(int idMaterial, int quantityUpdate)
        {
            if (VerifyMaterialExistence(idMaterial))
            {
                int position = FindMaterial(idMaterial);
                inventory[position].Quantity = quantityUpdate;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Finds the position of a material in the inventory by its ID.
        /// </summary>
        /// <param name="idMaterial">The ID of the material to find.</param>
        /// <returns>The position of the material in the inventory if found; otherwise, returns -10.</returns>
        private static int FindMaterial(int idMaterial)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].IdMaterial == idMaterial)
                {
                    return i;
                }
            }

            return -10;
        }

        /// <summary>
        /// Decreases the quantity of a material in the inventory by a specified amount if there is sufficient stock.
        /// </summary>
        /// <param name="idMaterial">The ID of the material to use.</param>
        /// <param name="quantity">The quantity to reduce from the stock.</param>
        /// <returns><c>true</c> if the material was used successfully; otherwise, <c>false</c> if the material does not exist or there is insufficient stock.</returns>
        public static bool UseMaterial(int idMaterial, int quantity)
        {
            if (VerifyMaterialExistence(idMaterial))
            {
                int position = FindMaterial(idMaterial);

                if (inventory[position].Quantity >= quantity)
                {
                    inventory[position].Date = DateTime.Now;
                    inventory[position].Quantity -= quantity;
                    return true;
                }
            }

            return false;
        }

        public static void ShowInventory() 
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == null)
                {
                    break;
                }

                Console.WriteLine("{0} {1} {2}", inventory[i].IdMaterial, inventory[i].Quantity, inventory[i].Date);
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
