using ClientManagementSystem.Models;

namespace ClientManagementSystem.Services
{
    // The "contract" for storing clients. The controller only knows about this
    // interface, not HOW the data is stored. That is what lets us swap the
    // in-memory list for SQL Server later without rewriting the controller.
    public interface IClientRepository
    {
        List<Client> GetAll();            // Read (list)
        Client? GetById(int id);          // Read (one)
        void Add(Client client);          // Create
        bool Update(Client client);       // Update
        bool Delete(int id);              // Delete
    }
}
