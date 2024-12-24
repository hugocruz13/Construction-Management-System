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
    /// Represents a person with an ID and a name.
    /// </summary>
    [Serializable]
    public class Person
    {
        #region Attributes
        /// <summary>
        /// The ID of the person.
        /// </summary>
        int id;

        /// <summary>
        /// The ID of the person.
        /// </summary>
        string name;
        #endregion

        #region Methods

        #region Properties

        /// <summary>
        /// Gets the ID of the person.
        /// </summary>
        public int Id
        {
            get { return id; }
        }

        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        public string Name
        {
            set { name = stringFormatada(value); }
            get { return name; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Person class with an ID and a name.
        /// The name is automatically formatted.
        /// </summary>
        /// <param name="id">The ID of the person.</param>
        /// <param name="name">The name of the person.</param>
        protected Person(int id, string name)
        {
            this.id = id;
            Name = name;
        }
        #endregion

        #region OtherMethods

        /// <summary>
        /// Formats a string to be uppercase and trimmed.
        /// </summary>
        /// <param name="name">The string to format</param>
        /// <returns>The formatted string.</returns>
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
