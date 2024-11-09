/*
*	<copyright file="MaterialQuantity.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/7/2024 6:25:11 PM</date>
*	<description>Class MaterialQuantity represents the quantity of a material and the date of its addition.</description>
**/
using System;

namespace src
{
    /// <summary>
    /// The class <c>MaterialQuantity</c> represents the quantity of a 
    /// given material, together with the date of its addition to the system.
    /// </summary>
    /// <remarks>
    /// This class allows you to associate a material with an amount and record the date of the transaction.
    /// </remarks>
    /// <example>
    /// Example of use
    /// <code>
    /// Material material = new Material("Cimento", 4.8);
    /// MaterialQuantity materialQuantity = new MaterialQuantity(material, 50);
    /// </code>
    /// </example>
    public class MaterialQuantity
    {
        #region Attributes
        /// <summary>
        /// Material associated with quantity.
        /// </summary>
        Material material;
        /// <summary>
        /// Quantity of material.
        /// </summary>
        int quantity;
        /// <summary>
        /// Date of registration of the quantity of material.
        /// </summary>
        DateTime date;
        #endregion

        #region Methods

        #region Properties
        /// <summary>
        /// Gets or sets the material associated with the quantity.
        /// </summary>
        /// <value>Associated material.</value>
        /// <permission>
        /// Public Access
        /// </permission>
        public Material Material
        {
            set { material = value; }
            get { return material; }
        }

        /// <summary>
        /// Gets or sets the quantity of material. The quantity must be greater than zero.
        /// </summary>
        /// <value>Quantity of material.</value>
        /// <permission>
        /// Public Access
        /// </permission>
        public int Quantity
        {
            set
            {
                if (value > 0)
                {
                    quantity = value;
                }
            }
            get { return quantity; }
        }

        /// <summary>
        /// Gets the date of registration of the quantity of material.
        /// </summary>
        /// <value>Date of registration.</value>
        /// <permission>
        /// Public Access (read only).
        /// </permission>
        public DateTime Date
        {
            get { return date; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Standard constructor of the class <c>MaterialQuantity</c>. This constructor
        /// initializes the quantity of material and the date of registration.
        /// </summary>
        /// <param name="material">Material associated with quantity.</param>
        /// <param name="quantity">Quantity of material.</param>
        /// <remarks>
        /// The date is automatically set to the current date and time at the time of object creation.
        /// </remarks>
        /// <permission>
        /// Public Access (read only).
        /// </permission>
        public MaterialQuantity(Material material, int quantity)
        {
            Material = material;
            Quantity = quantity;
            date = DateTime.Now;
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
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
