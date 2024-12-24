namespace Interface_Tier
{
    /// <summary>
    /// Methods to implement in the projects class
    /// </summary>
    public interface IProjects
    {
        /// <summary>
        /// Removes a project from the projects list by its ID.
        /// </summary>
        /// <param name="idProject">The ID of the project to remove.</param>
        /// <returns>True if the project was successfully removed, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the removal.
        /// </exception>
        bool RemoveProject(int idProject);

        /// <summary>
        /// Checks if a project exists by its ID.
        /// </summary>
        /// <param name="projectId">The ID of the project to check.</param>
        /// <returns>True if the project exists, otherwise false.</returns>
        bool ProjectExists(int idProject);

        /// <summary>
        /// Closes a project by setting its end date and status to completed.
        /// </summary>
        /// <param name="idProject">The ID of the project to close.</param>
        /// <returns>True if the project was successfully closed, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the closure.
        /// </exception>
        bool CloseProject(int idProject);

        /// <summary>
        /// Adds a client to a project.
        /// </summary>
        /// <param name="idProject">The ID of the project to add the client to.</param>
        /// <param name="idClient">The ID of the client to add.</param>
        /// <returns>True if the client was added successfully, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the addition.
        /// </exception>
        bool AddClient(int idProject, int idClient);

        /// <summary>
        /// Removes a client from a project.
        /// </summary>
        /// <param name="idProject">The ID of the project to remove the client from.</param>
        /// <param name="idClient">The ID of the client to remove.</param>
        /// <returns>True if the client was removed successfully, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the removal.
        /// </exception>
        bool RemoveClient(int idProject, int idClient);

        /// <summary>
        /// Adds an employee to a project.
        /// </summary>
        /// <param name="idProject">The ID of the project to add the employee to.</param>
        /// <param name="idEmployee">The ID of the employee to add.</param>
        /// <returns>True if the employee was added successfully, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the addition.
        /// </exception>
        bool AddEmployee(int idProject, int idEmployee);

        /// <summary>
        /// Removes an employee from a project.
        /// </summary>
        /// <param name="idProject">The ID of the project to remove the employee from.</param>
        /// <param name="idEmployee">The ID of the employee to remove.</param>
        /// <returns>True if the employee was removed successfully, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the removal.
        /// </exception>
        bool RemoveEmployee(int idProject, int idEmployee);

        /// <summary>
        /// Uses material in a project.
        /// </summary>
        /// <param name="idProject">The ID of the project to use material in.</param>
        /// <param name="idMaterial">The ID of the material to use.</param>
        /// <param name="quantity">The quantity of the material to use.</param>
        /// <returns>True if the material was used successfully, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the material use.
        /// </exception>
        bool UseMaterial(int idProject, int idMaterial, int quantity);
    }
}
