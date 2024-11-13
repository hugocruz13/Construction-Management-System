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
        const int sizeArrays = 5;
        static Project[] projects;
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
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
