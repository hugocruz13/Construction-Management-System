using Object_Tier;

namespace Interface_Tier
{
    /// <summary>
    /// Methods to implement in the clients class
    /// </summary>
    public interface IClients
    {
        /// <summary>
        /// Adds a client to the client list.
        /// </summary>
        /// <param name="client">The client object to add.</param>
        /// <returns>The ID of the added client.</returns>
        int AddClient(Client client);

        /// <summary>
        /// Removes a client from the client list based on their ID.
        /// </summary>
        /// <param name="idClient">The ID of the client to remove.</param>
        /// <returns>Returns true if the client was successfully removed, otherwise false.</returns>
        bool RemoveClient(int idClient);

        /// <summary>
        /// Checks if a client exists in the client list based on their ID.
        /// </summary>
        /// <param name="idClient">The ID of the client to check for.</param>
        /// <returns>Returns true if the client exists, otherwise false.</returns>
        bool ExistClient(int idClient);

        /// <summary>
        /// Updates the contact information of a client based on their ID.
        /// </summary>
        /// <param name="idClient">The ID of the client to update.</param>
        /// <param name="contacto">The new contact information to set.</param>
        /// <returns>Returns true if the contact information was successfully updated, otherwise false.</returns>
        bool UpdateContact(int idClient, int contacto);

        /// <summary>
        /// Retrieves a client from the client list based on their ID.
        /// </summary>
        /// <param name="idClient">The ID of the client to retrieve.</param>
        /// <returns>The client object with the specified ID, or null if not found.</returns>
        Client GetClient(int idClient);

    }
}
