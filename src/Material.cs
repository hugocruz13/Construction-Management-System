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
        string description;
        double unitPrice;
        static int meterialIdCounter = 900;
        #endregion

        #region Methods

        #region Properties
        public int Id 
        {
            set { id = value; }
            get { return id; }
        }

        public string Description 
        {
            set { description = value; }
            get { return description; }
        }

        public double UnitPrice 
        {
            set { unitPrice = value; }
            get { return unitPrice; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Material()
        {
            Id = meterialIdCounter++;
        }

        public Material(string description, double unitPrice, int quantity)
        {
            Id = meterialIdCounter++;
            Description = description;
            UnitPrice = unitPrice;
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
