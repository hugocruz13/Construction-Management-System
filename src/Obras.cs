/*
*	<copyright file="src.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>10/28/2024 2:03:59 PM</date>
*	<description></description>
**/
using System;

namespace src
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 10/28/2024 2:03:59 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Obras
    {
        #region Attributes
        Funcionario[] funcionarios; 
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Obras()
        {
            funcionarios = new Funcionario[10];
        }

        public Obras(int x)
        {
            funcionarios = new Funcionario[x];
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        public bool AddFuncionario(Funcionario f) 
        {
            if (f != null)
            {
                for (int i = 0; i < funcionarios.Length; i++)
                {
                    if (funcionarios[i] == null)
                    {
                        funcionarios[i] = f;
                        return true;
                    }
                }
            }

            return false;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Obras()
        {
        }
        #endregion

        #endregion

    }
}
