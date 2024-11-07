/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/7/2024 6:16:35 PM</date>
*	<description></description>
**/
using System;

namespace src
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 11/7/2024 6:16:35 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Material
    {
        #region Attributes
        int id;
        string name;
        double unitPrice;
        static int materialIdCounter = 900;
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
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public Material(string name, double price)
        {
            Id = materialIdCounter++;
            Name = name;
            UnitPrice = price;
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
