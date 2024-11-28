/*
*	<copyright file="Material.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/20/2024 1:08:02 PM</date>
*	<description></description>
**/
using System;

namespace trabalhoPOO_23010
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 11/20/2024 1:08:02 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Materials
    {
        #region Attributes
        const int sizeArrays = 20;
        static Material[] materials;
        #endregion

        #region Methods

        #region Properties
        public static Material[] Material
        {
            get { return (Material[])materials.Clone(); }
        }
        #endregion

        #region Constructors

        static Materials()
        {
            materials = new Material[sizeArrays];
        }

        #endregion

        #region OtherMethods
        public static short AddMaterial(Material material)
        {
            if (!MaterialExist(material))
            {
                for (int i = 0; i < materials.Length; i++)
                {
                    if (materials[i] == null)
                    {
                        materials[i] = material;
                        return materials[i].Id;
                    }
                }
            }
            return -11;
        }

        internal static bool MaterialExist(Material material)
        {
            if (material == null)
            {
                return false;
            }

            foreach (Material m in materials)
            {
                if (m == null)
                {
                    return false;
                }

                if (material - m)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool MaterialExist(short idMaterial)
        {
            for (int i = 0; i < materials.Length; i++)
            {
                if (materials[i] == null)
                {
                    break;
                }
                if (materials[i].Id == idMaterial)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool UpdatePrice(short idMaterial, double price)
        {
            int position = FindMaterial(idMaterial);
            if (position != -11)
            {
                materials[position].UnitPrice= price;
                return true;
            }

            return false;
        }

        internal static int FindMaterial(short idMaterial)
        {
            if (MaterialExist(idMaterial))
            {
                for (int i = 0; i < materials.Length; i++)
                {
                    if (materials[i].Id == idMaterial)
                    {
                        return i;
                    }
                }
            }

            return -11;
        }

        public static void ShowMaterials()
        {
            for (int i = 0; i < materials.Length; i++)
            {
                if (materials[i] == null)
                    break;
                Console.WriteLine(materials[i].ToString());
            }
        }

        public static void ShowMaterials(short idMaterial)
        {
            if (MaterialExist(idMaterial))
            {
                for (int i = 0; i < materials.Length; i++)
                {
                    if (materials[i] == null)
                    {
                        break;
                    }
                    if (materials[i].Id == idMaterial)
                    {
                        Console.WriteLine(materials[i].ToString());
                        break;
                    }
                }
            }
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Materials()
        {
        }
        #endregion

        #endregion

    }
}
