using Object_Tier;

namespace Interface_Tier
{
    /// <summary>
    /// Methods to implement in the employees class
    /// </summary>
    public interface IEmployees
    {
        /// <summary>
        /// Adds a new employee to the list and sorts the list.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        /// <returns>The ID of the added employee.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws if the employee is null or if an error occurs during the addition.
        /// </exception>
        int AddEmployee(Employee employee);

        /// <summary>
        /// Removes an employee by their ID from the list.
        /// </summary>
        /// <param name="idEmployee">The ID of the employee to remove.</param>
        /// <returns><c>true</c> if the employee was removed, otherwise <c>false</c>.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws if an error occurs during the removal.
        /// </exception>
        bool RemoveEmployee(int idEmployee);

        /// <summary>
        /// Checks if an employee exists in the list based on their ID.
        /// </summary>
        /// <param name="idEmployee">The ID of the employee to check.</param>
        /// <returns><c>true</c> if the employee exists, otherwise <c>false</c>.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws if an error occurs during the existence check.
        /// </exception>
        bool EmployeeExist(int idEmployee);

        /// <summary>
        /// Updates an employee's role and hourly rate.
        /// </summary>
        /// <param name="idEmployee">The ID of the employee to update.</param>
        /// <param name="role">The new role of the employee.</param>
        /// <param name="hourly">The new hourly rate of the employee.</param>
        /// <returns><c>true</c> if the update was successful, otherwise <c>false</c>.</returns>
        /// <exception cref="ConfigurationErrorException">Throws if the update fails.</exception>
        bool UpdateRole(int idEmployee, string role, double hourly);

        /// <summary>
        /// Retrieves an employee based on their ID.
        /// </summary>
        /// <param name="idEmployee">The ID of the employee to retrieve.</param>
        /// <returns>The employee object if found, otherwise <c>null</c>.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws if the retrieval fails.
        /// </exception>
        Employee GetEmployee(int idEmployee);

    }
}
