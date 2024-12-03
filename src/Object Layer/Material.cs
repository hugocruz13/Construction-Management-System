/*
*	<copyright file="Material.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/7/2024 6:16:35 PM</date>
*	<description>Material class represents a material with information such as name and unit price.</description>
**/
using System;

namespace Object_Layer
{
    /// <summary>
    /// The class <c>Material</c> represents a material used in processes, 
    /// with attributes such as ID, name and unit price. The ID is automatically 
    /// generated, and the unit price is validated to ensure it is positive.
    /// </summary>
    /// <remarks>
    /// The class provides properties to access and modify the attributes of a material,
    /// as well as a method to check the equality of two materials based on the name.
    /// </remarks>
    /// <example>
    /// Example of use
    /// <code>
    /// Material mat = new Material("Cimento", 4.80)
    /// </code>
    /// </example>
    public class Material
    {
        #region Attributes
        /// <summary>
        /// Unique material identifier.
        /// </summary>
        short id;

        /// <summary>
        /// Name of the material.
        /// </summary>
        string name;

        /// <summary>
        /// Unit price of the material.
        /// </summary>
        double unitPrice;

        /// <summary>
        /// Static counter to assign unique IDs to materials.
        /// </summary>
        static short materialIdCounter = 900;
        #endregion

        #region Methods

        #region Properties
        /// <summary>
        /// Returns the ID of the Material
        /// </summary>
        /// <value>The material ID.</value>
        /// <permission>
        /// Public Access (read only).
        /// </permission>
        public short Id
        {
            get { return id; }
        }

        /// <summary>
        /// Gets or set the name of the material.
        /// </summary>
        /// <value>Material name.</value>
        /// <permission>
        /// Public Access
        /// </permission>
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        /// <summary>
        /// Get or set the unit price of the material. 
        /// The price must be greater than zero.
        /// </summary>
        /// <value>Unit price of the material.</value>
        /// <permission>
        /// Public Access
        /// </permission>
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
        #endregion

        #region Constructors

        /// <summary>
        /// Constructor that initializes a material with the name and unit price.
        /// The ID is assigned automatically with the static counter.
        /// </summary>
        /// <param name="name">Name of the material.</param>
        /// <param name="price">Unit price of the material.</param>
        /// <remarks>
        ///  The ID is assigned automatically and generated based on the static counter <c>materialIdCounter</c>
        /// </remarks>
        /// <permission>
        /// Public Access
        /// </permission>
        public Material(string name, double price)
        {
            id = materialIdCounter++;
            Name = name.ToUpper().Trim();
            UnitPrice = price;
        }

        #endregion

        #region Overrides
        /// <summary>
        /// Determines whether the specified object is equal to the current material.
        /// </summary>
        /// <param name="obj">The object to compare with the current material.</param>
        /// <returns>
        /// <c>true</c> if the specified object is equal to the current material; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj ==null)
            {
                return false;
            }

            if (obj is Material)
            {
                Material otherClient = obj as Material;

                if (name == otherClient.Name && unitPrice == otherClient.UnitPrice)
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return Id + " " + Name + " " + UnitPrice;
        }
        #endregion

        #region OtherMethods
        public static bool operator -(Material material1, Material material2)
        {
            if (material1.Equals(material2))
            {
                return true;
            }

            return false;
        }

        public static bool operator +(Material material1, Material material2)
        {
            return !(material1 - material2);
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
