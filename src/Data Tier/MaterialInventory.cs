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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CustomExceptions;
using Object_Tier;

namespace Data_Tier
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
    /// MaterialInventory.AddMaterial(new MaterialQuantity("Cimento", 4.80, 5))  0O
    /// </code>
    /// </example>
    [Serializable]
    public class MaterialInventory
    {
        #region Attributes

        /// <summary>
        /// Array that stores instances of <c>MaterialQuantity</c> objects.
        /// </summary>
        static MaterialInventory instance;
        static List<MaterialQuantity> inventory;
        #endregion

        #region Methods

        #region Properties
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
        protected MaterialInventory()
        {
            inventory = new List<MaterialQuantity>(5);
        }

        #endregion

        #region OtherMethods
        public short AddMaterial(MaterialQuantity inventoryQuantity)
        {
            inventory.Add(inventoryQuantity);
            return inventoryQuantity.IdMaterial;

        }

        public bool VerifyMaterialExistence(short idMaterial)
        {

            foreach (MaterialQuantity materialInstance in inventory)
            {
                if (materialInstance.IdMaterial == idMaterial)
                {
                    return true;
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
        public bool UpdateQuantity(short idMaterial, int quantityUpdate)
        {

            foreach (MaterialQuantity materialInstance in inventory)
            {
                if (materialInstance.IdMaterial == idMaterial)
                {
                    materialInstance.Quantity = quantityUpdate;
                    return true;
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
        public bool UseMaterial(short idMaterial, int quantity)
        {

            foreach (MaterialQuantity materialInstance in inventory)
            {
                if (materialInstance.IdMaterial == idMaterial && materialInstance.Quantity >= quantity)
                {
                    materialInstance.Quantity -= quantity;
                    return true;
                }
            }


            return false;
        }

        public bool Save(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ConfigurationErrorException("Caminho invalido");
            }

            try
            {
                Stream fs = new FileStream(path, FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, inventory);
                fs.Close();
                inventory.Clear();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Algo aconteceu ");
            }

        }


        public bool Load(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ConfigurationErrorException("Caminho invalido");
            }
            try
            {
                Stream s = File.Open(path, FileMode.Open, FileAccess.Read);
                BinaryFormatter b = new BinaryFormatter();
                inventory = (List<MaterialQuantity>)b.Deserialize(s);
                s.Close();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Algo aconteceu ");
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
