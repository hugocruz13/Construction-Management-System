/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/3/2024 7:20:40 PM</date>
*	<description></description>
**/
using System;

namespace Object_Tier
{
    /// <summary>
    /// Represents a person with basic attributes like Id and Name.
    /// This class provides access and modification to a person’s attributes.
    /// </summary>
    /// <remarks>
    /// The <c>Person</c> class is used to store a person’s identifying information.
    /// </remarks>
    /// <example>
    /// Example of use
    /// <code>
    /// Name = name;
    /// </code>
    /// </example>
    [Serializable]
    public class Person
    {
        #region Attributes
        /// <summary>
        /// Unique identifier of the person.
        /// </summary>
        short id;
        /// <summary>
        /// Name of the person
        /// </summary>
        string name;
        #endregion

        #region Methods

        #region Properties
        /// <summary>
        /// Gets or sets the unique identifier of the person.
        /// </summary>
        /// <value>The unique id of the person.</value>
        /// <remarks>This value is used to uniquely identify the person.</remarks>
        /// <permission>
        /// Public Access
        /// </permission>
        public short Id 
        {
            get { return id; }
        }

        /// <summary>
        /// Gets or sets the name of the person..
        /// </summary>
        /// <value>The name of the person.</value>
        /// <remarks>This value contains the full name of the person.</remarks>
        /// <permission>
        /// Public Access
        /// </permission>
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <c>Person</c> class with the specified ID and name.
        /// </summary>
        /// <remarks>
        /// This constructor is <c>protected</c> to prevent direct instantiation of the <c>Person</c> class,
        /// enforcing that it can only be instantiated through derived classes.
        /// </remarks>
        /// <param name="id">The unique identifier for the person.</param>
        /// <param name="name">The name of the person.</param>
        protected Person(short id, string name) 
        {
            this.id = id;
            Name = stringFormatada(name);
        }
        #endregion

        #region OtherMethods
        private string stringFormatada(string name)
        {
            return name.ToUpper().Trim();
        }
        #endregion

        #region Destructor
        /// <summary>
        /// Destroyer of the Person class.
        /// </summary>
        ~Person()
        {
        }
        #endregion

        #endregion
    }
}
