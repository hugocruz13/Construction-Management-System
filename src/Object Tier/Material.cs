/*
*	<copyright file="Material.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/7/2024 6:16:35 PM</date>
*	<description>Material class represents a material with information such as name and unit price.</description>
**/
using System;

namespace Object_Tier
{
    /// <summary>
    /// Represents a material with ID, name, unit price, and registration date.
    /// </summary>
    [Serializable]
    public class Material : IComparable<Material>
    {
        #region Attributes

        /// <summary>
        /// Stores the ID of the material.
        /// </summary>
        int id;

        /// <summary>
        /// Stores the name of the material.
        /// </summary>
        string name;

        /// <summary>
        /// Stores the unit price of the material.
        /// </summary>
        double unitPrice;

        /// <summary>
        ///  Stores the last registration date of the material.
        /// </summary>
        DateTime lastRegiste;

        /// <summary>
        /// Static counter to generate unique material IDs. Starts at 900.
        /// </summary>
        [NonSerialized]
        static int materialIdCounter = 900;
        #endregion

        #region Methods

        #region Properties
        /// <summary>
        /// Gets the ID of the material. Read-only.
        /// </summary>
        public int Id
        {
            get { return id; }
        }

        /// <summary>
        /// Gets or sets the name of the material.
        /// </summary>
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        /// <summary>
        /// Gets or sets the unit price of the material.
        /// The value must be greater than zero.
        /// </summary>
        public double UnitPrice
        {
            set
            {
                if (value > 0)
                {
                    unitPrice = value;
                }
            }
            get { return unitPrice; }
        }

        /// <summary>
        /// Gets or sets the last registration date of the material.
        /// </summary>
        public DateTime LastRegiste
        {
            set { lastRegiste = value; }
            get { return lastRegiste; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Material class with a name and unit price.
        /// Automatically assigns a unique ID.
        /// </summary>
        /// <param name="name">The name of the material.</param>
        /// <param name="price">The unit price of the material.</param>
        public Material(string name, double price)
        {
            id = materialIdCounter++;
            Name = name.ToUpper().Trim();
            UnitPrice = price;
            LastRegiste = DateTime.Now;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Determines whether the specified object is equal to the current material.
        /// Materials are equal if their name and unit price match.
        /// </summary>
        /// <param name="obj">The object to compare with the current material.</param>
        /// <returns>True if the objects are equal; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Material)
            {
                Material otherMaterial = obj as Material;

                if (name == otherMaterial.Name && unitPrice == otherMaterial.UnitPrice)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns a string representation of the material, including ID, name, and unit price.
        /// </summary>
        /// <returns>A string representation of the material.</returns>
        public override string ToString()
        {
            return Id + " " + Name + " " + UnitPrice;
        }
        #endregion

        #region OtherMethods

        /// <summary>
        /// Creates a new Material instance.
        /// </summary>
        /// <param name="name">The name of the material.</param>
        /// <param name="price">The unit price of the material.</param>
        /// <returns>A new Material object.</returns>
        public static Material CreateMaterial(string name, double price)
        {
            return new Material(name, price);
        }

        /// <summary>
        /// Checks if two materials are equal using the "-" operator.
        /// </summary>
        /// <param name="material1">The first material.</param>
        /// <param name="material2">The second material.</param>
        /// <returns>True if the materials are equal; otherwise, false.</returns>
        public static bool operator -(Material material1, Material material2)
        {
            if (material1.Equals(material2))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if two materials are not equal using the "+" operator.
        /// </summary>
        /// <param name="material1">The first material.</param>
        /// <param name="material2">The second material.</param>
        /// <returns>True if the materials are not equal; otherwise, false.</returns>
        public static bool operator +(Material material1, Material material2)
        {
            return !(material1 - material2);
        }

        /// <summary>
        /// Compares the current material to another material based on their name.
        /// </summary>
        /// <param name="material">The material to compare to.</param>
        /// <returns>A value indicating the relative order of the materials.</returns>
        public int CompareTo(Material material)
        {
            return Name.CompareTo(material.Name);
        }

        /// <summary>
        /// Increments the static material ID counter.
        /// </summary>
        /// <returns>True after incrementing the counter.</returns>
        public static bool getNextMaterialId()
        {
            materialIdCounter++;
            return true;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destroyer of the Material class.
        /// </summary>
        ~Material()
        {
        }
        #endregion

        #endregion

    }
}
