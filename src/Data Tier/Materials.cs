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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CustomExceptions;
using Object_Tier;

namespace Data_Tier
{
    /// <summary>
    /// Purpose:
    /// Created by: hugoc
    /// Created on: 11/20/2024 1:08:02 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [Serializable]
    public class Materials
    {
        #region Attributes
        static Materials instance;
        static List<Material> materials;
        #endregion

        #region Methods

        #region Properties
        public static Materials Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Materials();
                }

                return instance;
            }
        }
        #endregion

        #region Constructors

        protected Materials()
        {
            materials = new List<Material>(5);
        }

        #endregion

        #region OtherMethods
        public short AddMaterial(Material material)
        {
            materials.Add(material);
            return material.Id;
        }

        public bool MaterialExist(Material material)
        {

            foreach (Material existingMaterial in materials)
            {
                if (existingMaterial - material)
                {
                    return true;
                }
            }
            return false;
        }

        public bool MaterialExist(short idMaterial)
        {

            foreach (Material materialInstance in materials)
            {
                if (materialInstance.Id == idMaterial)
                {
                    return true;
                }
            }
            return false;
        }

        public bool UpdatePrice(short idMaterial, double price)
        {

            foreach (Material materialInstance in materials)
            {
                if (materialInstance.Id == idMaterial)
                {
                    materialInstance.UnitPrice = price;
                    return true;
                }
            }
            return false;
        }

        public bool Save(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ConfigurationErrorException("Caminho invalido");
            }

            try
            {
                Stream fs = new FileStream(path, FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, materials);
                fs.Close();
                materials.Clear();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Algo aconteceu ");
            }

        }


        public bool Load(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ConfigurationErrorException("Caminho invalido");
            }
            try
            {
                Stream s = File.Open(path, FileMode.Open, FileAccess.Read);
                BinaryFormatter b = new BinaryFormatter();
                materials = (List<Material>)b.Deserialize(s);
                s.Close();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Algo aconteceu ");
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
