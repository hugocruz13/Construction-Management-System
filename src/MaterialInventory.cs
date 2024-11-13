/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/12/2024 3:46:54 PM</date>
*	<description></description>
**/
using System;

namespace src
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
    /// MaterialInventory.AddMaterial(new MaterialQuantity("Cimento", 4.80, 5))
    /// </code>
    /// </example>
    public class MaterialInventory
    {
        #region Attributes
        /// <summary>
        /// The fixed size of the <c>inventory</c> array.
        /// </summary>
        const int sizeArrays = 20;

        /// <summary>
        /// Array that stores instances of <c>MaterialQuantity</c> objects.
        /// </summary>
        static MaterialQuantity[] inventory;
        #endregion

        #region Methods

        #region Properties
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
        static MaterialInventory()
        {
            inventory = new MaterialQuantity[sizeArrays];
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
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
