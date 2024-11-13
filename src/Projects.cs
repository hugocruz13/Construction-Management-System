/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/12/2024 3:48:18 PM</date>
*	<description></description>
**/
using System;

namespace src
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 11/12/2024 3:48:18 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Projects
    {
        #region Attributes

        /// <summary>
        ///  The fixed size of the <c>projects</c> array.
        /// </summary>
        const int sizeArrays = 5;

        /// <summary>
        /// Array that stores instances of <c>Project</c> objects.
        /// </summary>
        static Project[] projects;
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the <c>Projects</c> class by setting up the project array.
        /// </summary>
        /// <remarks>
        /// This static constructor is called only once, when the <c>Projects</c> class is accessed for the first time. 
        /// It initializes the <c>projects</c> array with a predefined size.
        /// </remarks>
        /// <example>
        /// Accessing any member of the <c>Projects</c> class will trigger this constructor if it hasn't been initialized.
        /// </example>
        static Projects()
        {
            projects = new Project[sizeArrays];
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
        ~Projects()
        {
        }
        #endregion

        #endregion

    }
}
