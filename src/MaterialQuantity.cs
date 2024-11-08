/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/7/2024 6:25:11 PM</date>
*	<description></description>
**/
using System;

namespace src
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 11/7/2024 6:25:11 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class MaterialQuantity
    {
        #region Attributes
        Material material;
        int quantity;
        DateTime date;
        #endregion

        #region Methods

        #region Properties
        public Material Material
        {
            set { material = value; }
            get { return material; }
        }

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

        public DateTime Date
        {
            get { return date; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
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
        /// The destructor.
        /// </summary>
        ~MaterialQuantity()
        {
        }
        #endregion

        #endregion

    }
}
