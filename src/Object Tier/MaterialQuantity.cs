/*
*	<copyright file="MaterialQuantity.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/7/2024 6:25:11 PM</date>
*	<description>Class MaterialQuantity represents the quantity of a material and the date of its addition.</description>
**/
using System;

namespace Object_Tier
{
    /// <summary>
    /// Represents the quantity of a material and the date it was added.
    /// </summary>
    [Serializable]
    public class MaterialQuantity : IComparable<MaterialQuantity>
    {
        #region Attributes

        /// <summary>
        /// The ID of the material.
        /// </summary>
        int idMaterial;

        /// <summary>
        /// The quantity of the material.
        /// </summary>
        int quantity;

        /// <summary>
        /// The date the material was added.
        /// </summary>
        DateTime date;

        #endregion

        #region Methods

        #region Properties

        /// <summary>
        /// Gets the ID of the material.
        /// </summary>
        public int IdMaterial
        {
            get { return idMaterial; }
        }

        /// <summary>
        /// Gets or sets the quantity of the material.
        /// The value must be zero or greater.
        /// </summary>
        public int Quantity
        {
            set
            {
                if (value >= 0)
                {
                    quantity = value;
                }
            }
            get { return quantity; }
        }

        /// <summary>
        /// Gets or sets the date the material was added.
        /// </summary>
        public DateTime Date
        {
            set { date = value; }
            get { return date; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the MaterialQuantity class with an ID and quantity.
        /// The date is set to the current date and time.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantity"></param>
        public MaterialQuantity(int id, int quantity)
        {
            this.idMaterial = id;
            Quantity = quantity;
            date = DateTime.Now;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Checks if the current MaterialQuantity is equal to another object.
        /// Two MaterialQuantity objects are equal if their material IDs are the same.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>True if the objects are equal; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is MaterialQuantity)
            {
                MaterialQuantity othermaterial = obj as MaterialQuantity;

                if (idMaterial == othermaterial.idMaterial)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns a string representation of the MaterialQuantity.
        /// Includes the material ID, date, and quantity.
        /// </summary>
        /// <returns>A string representing the MaterialQuantity.</returns>
        public override string ToString()
        {
            return idMaterial + " " + Date + " " + Quantity;
        }

        /// <summary>
        /// Compares the current MaterialQuantity to another based on their material IDs.
        /// </summary>
        /// <param name="material">The MaterialQuantity to compare to.</param>
        /// <returns>A value indicating the relative order of the objects.</returns>
        public int CompareTo(MaterialQuantity material)
        {
            return IdMaterial.CompareTo(material.IdMaterial);
        }
        #endregion

        #region OtherMethods

        /// <summary>
        /// Creates a new MaterialQuantity instance.
        /// </summary>
        /// <param name="id">The ID of the material.</param>
        /// <param name="quantity">The quantity of the material.</param>
        /// <returns>A new MaterialQuantity object.</returns>
        public static MaterialQuantity CreateMaterialQuantity(int id, int quantity)
        {
            return new MaterialQuantity(id, quantity);
        }

        /// <summary>
        /// Checks if two MaterialQuantity objects are equal using the "-" operator.
        /// </summary>
        /// <param name="material1">The first MaterialQuantity.</param>
        /// <param name="material2">The second MaterialQuantity.</param>
        /// <returns>True if the objects are equal; otherwise, false.</returns>
        public static bool operator -(MaterialQuantity material1, MaterialQuantity material2)
        {
            if (material1.Equals(material2))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if two MaterialQuantity objects are not equal using the "+" operator.
        /// </summary>
        /// <param name="material1">The first MaterialQuantity.</param>
        /// <param name="material2">The second MaterialQuantity.</param>
        /// <returns>True if the objects are not equal; otherwise, false.</returns>
        public static bool operator +(MaterialQuantity material1, MaterialQuantity material2)
        {
            return !(material1 - material2);
        }
        #endregion

        #region Destructor
        /// <summary>
        ///  The destroyer of the MaterialQuantity class. 
        /// </summary>
        ~MaterialQuantity()
        {
        }
        #endregion

        #endregion

    }
}
