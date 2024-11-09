/*
*	<copyright file="UsedMaterials.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/8/2024 3:55:27 PM</date>
*	<description>Class to manage the materials used in a project.</description>
**/
using System;

namespace src
{
    /// <summary>
    /// The <c>UsedMaterials</c> class represents the materials used in a project.
    /// It stores the details of the material (id,name, price) and the quantity used in the project, 
    /// along with the date when the material was added.
    /// </summary>
    /// <remarks>
    /// The <c>UsedMaterials</c> class manages a collection of materials used in a project, 
    /// storing each material with its quantity and the date it was used. The materials are 
    /// stored in an array with a fixed size, and the total number of materials used is tracked.
    /// </remarks>
    /// <example>
    /// Example of use:
    /// <code>
    /// UsedMaterials.AddMaterial(new Material("Cemento", 5.0), 10);
    /// UsedMaterials.ShowList();
    /// </code>
    /// </example>
    public class UsedMaterials
    {
        #region Attributes
        /// <summary>
        /// Sets the maximum size of the array to store employees
        /// </summary>
        const int sizeArrays = 20;
        /// <summary>
        /// Static array to store the materials used
        /// </summary>
        static MaterialQuantity[] usedMaterials;
        /// <summary>
        /// Counter to control or number of materials added
        /// </summary>
        static int total = 0;
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// The static constructor of the class. Initializes the 'usedMaterials' array to store the materials used.
        /// </summary>
        static UsedMaterials()
        {
            //Initializes the material array with the size set in 'sizeArrays'
            usedMaterials = new MaterialQuantity[sizeArrays];
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        public static bool AddMaterial(Material m, int quantity)
        {
            MaterialQuantity mq = new MaterialQuantity(m, quantity);
            usedMaterials[total++] = mq;
            return true;
        }

        public static void ShowList() 
        {
            for (int i = 0; i < total; i++)
            {
                MaterialQuantity material = usedMaterials[i];
                Material mat = material.Material;

                Console.WriteLine("{0} {1} {2} {3} {4}", mat.Id, mat.Name, mat.UnitPrice, material.Quantity, material.Date.ToString("g"));
            }

        }

        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~UsedMaterials()
        {
        }
        #endregion

        #endregion

    }
}
