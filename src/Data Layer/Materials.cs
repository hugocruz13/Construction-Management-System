/*
*	<copyright file="Material.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>11/20/2024 1:08:02 PM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using System.Data;

using Object_Layer;

namespace Data_Layer
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
        static Dictionary<int, List<Material>> materials;
        #endregion

        #region Methods

        #region Properties
        #endregion

        #region Constructors

        static Materials()
        {
            materials = new Dictionary<int, List<Material>>(11);
        }

        #endregion

        #region OtherMethods
        internal static int GenerateKey(short idMaterial)
        {
            return idMaterial % 11;
        }

        public static short AddMaterial(Material material)
        {
            if (!MaterialExist(material))
            {
                int key = GenerateKey(material.Id);

                if (!materials.ContainsKey(key))
                {
                    materials[key] = new List<Material>(5);
                }

                materials[key].Add(material);
                return material.Id;
            }
            return -11;
        }

        internal static bool MaterialExist(Material material)
        {
            foreach (List<Material> materialList in materials.Values)
            {
                foreach (Material existingMaterial in materialList)
                {
                    if (existingMaterial - material)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool MaterialExist(short idMaterial)
        {
            int key = GenerateKey(idMaterial);

            if (materials.ContainsKey(key))
            {
                foreach (Material materialInstance in materials[key])
                {
                    if (materialInstance.Id == idMaterial)
                    {
                        return true;
                    }
                }
            }

            return false;

        }

        public static bool UpdatePrice(short idMaterial, double price)
        {
            int key = GenerateKey(idMaterial);

            if (materials.ContainsKey(key))
            {
                foreach (Material materialInstance in materials[key])
                {
                    if (materialInstance.Id == idMaterial)
                    {
                        materialInstance.UnitPrice = price;
                        return true;
                    }
                }
            }

            return false;
        }


        public static void ShowMaterials()
        {
            foreach (List<Material> materialList in materials.Values)
            {
                foreach (Material existingMaterial in materialList)
                {
                    Console.WriteLine(existingMaterial.ToString());
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
