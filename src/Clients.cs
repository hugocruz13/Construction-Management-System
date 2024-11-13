/*
*	<copyright file="Clients.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/12/2024 3:44:27 PM</date>
*	<description></description>
**/
using System;

namespace src
{
    /// <summary>
    /// Represents a collection of client with a fixed maximum capacity.
    /// </summary>
    /// <remarks>
    /// This class is designed to store instances of the <c>Client</c> class in a fixed-size array, defined by the constant <c>sizeArrays</c>.
    /// The array is statically initialized upon first access to the <c>Clients</c> class.
    /// </remarks>
    /// <example>
    /// Example of use
    /// <code>
    /// Clients clients 
    /// Clients.AddClient(new Client client("Ricardo Alves","96......."))
    /// </code>
    /// </example>
    public class Clients
    {
        #region Attributes
        /// <summary>
        /// The fixed size of the <c>clients</c> array.
        /// </summary>
        const int sizeArrays = 20;

        /// <summary>
        /// Array that stores instances of <c>Client</c> objects.
        /// </summary>
        static Client[] clients;
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the <c>Clients</c> class by setting up the client array.
        /// </summary>
        /// <remarks>
        /// This static constructor is called only once, when the <c>Clients</c> class is accessed for the first time. 
        /// It initializes the <c>clients</c> array with a predefined size.
        /// </remarks>
        /// <example>
        /// Accessing any member of the <c>Clients</c> class will trigger this constructor if it hasn't been initialized.
        /// </example>
        static Clients()
        {
            clients = new Client[sizeArrays];
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        #endregion

        #region Destructor
        /// <summary>
        /// The destroyer of the Clients class.
        /// </summary>
        ~Clients()
        {
        }
        #endregion

        #endregion

    }
}
