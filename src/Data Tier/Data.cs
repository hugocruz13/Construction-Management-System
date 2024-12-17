/*
*	<copyright file="Data_Tier.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>12/17/2024 5:09:50 PM</date>
*	<description></description>
**/
using Data_Layer;
using System;
using System.Collections.Generic;

using Object_Tier;

namespace Data_Tier
{

    [Serializable]
    public class Data
    {

        List<Client> clients;
        Dictionary<int, List<int>> clientsService;
        List<Employee> employees;
        Dictionary<int, List<int>> employeesService;
        List<Material> materials;
        List<MaterialQuantity> inventory;
        Dictionary<int, List<MaterialQuantity>> materialService;
        List<Project> projects;


        public bool CollectData()
        {
            clients = Clients.Instance.ClientsD;
            clientsService = ClientsService.Instance.ClientsDS;
            employees = Employees.Instance.EmployeesD;
            employeesService = EmployeesService.Instance.EmployeesDS;
            materials = Materials.Instance.MaterialD;
            inventory = MaterialInventory.Instance.InventoryD;
            materialService = MaterialService.Instance.MaterialDS;
            projects = Projects.Instance.ProjectsD;
            return true;
        }

        public bool PutData()
        {
            Clients.Instance.ClientsD = clients;
            ClientsService.Instance.ClientsDS = clientsService;
            Employees.Instance.EmployeesD = employees;
            EmployeesService.Instance.EmployeesDS = employeesService;
            MaterialInventory.Instance.InventoryD = inventory;
            Materials.Instance.MaterialD = materials;
            MaterialService.Instance.MaterialDS = materialService;
            Projects.Instance.ProjectsD = projects;

            return true;
        }


        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Data()
        {
        }
        #endregion



    }


}
