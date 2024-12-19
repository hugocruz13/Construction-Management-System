using Object_Tier;

namespace Interface_Tier
{
    /// <summary>
    /// Methods to implement in the materials class
    /// </summary>
    public interface IMaterials
    {

        /// <summary>
        /// Adds a new material to the materials list.
        /// </summary>
        /// <param name="material">The material to add.</param>
        /// <returns>The ID of the added material.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if the material is null or any error occurs during the addition.
        /// </exception>
        int AddMaterial(Material material);


        /// <summary>
        /// Checks if a material exists in the list based on its ID.
        /// </summary>
        /// <param name="idMaterial">The ID of the material to check.</param>
        /// <returns>True if the material exists, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the check.
        /// </exception>
        bool MaterialExist(int idMaterial);


        /// <summary>
        /// Updates the price of a material in the list based on its ID.
        /// </summary>
        /// <param name="idMaterial">The ID of the material to update.</param>
        /// <param name="price">The new price to set.</param>
        /// <returns>True if the price was updated successfully, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the update.
        /// </exception>
        bool UpdatePrice(int idMaterial, double price);

    }
}
