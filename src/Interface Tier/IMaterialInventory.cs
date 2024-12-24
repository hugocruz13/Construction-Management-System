using Object_Tier;

namespace Interface_Tier
{
    /// <summary>
    /// Methods to implement in the inventory class
    /// </summary>
    public interface IMaterialInventory
    {
        /// <summary>
        /// Adds a new material to the inventory.
        /// </summary>
        /// <param name="inventoryQuantity">The material quantity to add to the inventory.</param>
        /// <returns>The ID of the added material.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if the material is null or if any error occurs during the addition.
        /// </exception>
        int AddMaterial(MaterialQuantity inventoryQuantity);

        /// <summary>
        /// Verifies if a material exists in the inventory based on the material ID.
        /// </summary>
        /// <param name="idMaterial">The ID of the material to verify.</param>
        /// <returns>Returns true if the material exists, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the verification process.
        /// </exception>
        bool VerifyMaterialExistence(int idMaterial);

        /// <summary>
        /// Verifies if there is enough quantity of a material in the inventory.
        /// </summary>
        /// <param name="idMaterial">The ID of the material to check.</param>
        /// <param name="quantity">The quantity of material to check for.</param>
        /// <returns>Returns true if there is enough quantity, otherwise false.</returns>

        bool VerifyMaterialQuantity(int idMaterial, int quantity);

        /// <summary>
        /// Updates the quantity of a material in the inventory.
        /// </summary>
        /// <param name="idMaterial">The ID of the material to update.</param>
        /// <param name="quantityUpdate">The new quantity of the material.</param>
        /// <returns>Returns true if the quantity was updated successfully, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the update process.
        /// </exception>
        bool UpdateQuantity(int idMaterial, int quantityUpdate);

        /// <summary>
        /// Decreases the quantity of a material in the inventory when it is used.
        /// </summary>
        /// <param name="idMaterial">The ID of the material to use.</param>
        /// <param name="quantity">The quantity of material to use.</param>
        /// <returns>Returns true if the material quantity was successfully decreased, otherwise false.</returns>
        /// <exception cref="ConfigurationErrorException">
        /// Throws an exception if an error occurs during the use process.
        /// </exception>
        bool UseMaterial(int idMaterial, int quantity);
    }
}
