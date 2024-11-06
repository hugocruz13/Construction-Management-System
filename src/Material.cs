/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/6/2024 11:09:34 AM</date>
*	<description></description>
**/
using System;

namespace src
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 11/6/2024 11:09:34 AM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Material
    {
        #region Attributes
        int id;
        string name;
        double unitPrice;
        int quantity;
        static int meterialIdCounter = 900;
        #endregion

        #region Methods

        #region Properties
        public int Id 
        {
            set { id = value; }
            get { return id; }
        }

        public string Name 
        {
            set { name = value; }
            get { return name; }
        }

        public double UnitPrice 
        {
            set { unitPrice = value; }
            get { return unitPrice; }
        }

        public int Quantity 
        {
            set { quantity = value; }
            get { return quantity; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Material()
        {
            Id = meterialIdCounter++;
            Name = string.Empty;
            UnitPrice = 0;
            Quantity = 0;
            
        }

        public Material(string name, double unitPrice, int quantity)
        {
            Id = meterialIdCounter++;
            Name = name;
            UnitPrice = unitPrice;
            Quantity = quantity;
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
        ~Material()
        {
        }
        #endregion

        #endregion

    }
}
