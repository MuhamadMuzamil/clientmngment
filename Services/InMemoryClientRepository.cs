using ClientManagementSystem.Models;

namespace ClientManagementSystem.Services
{
    // Stores clients in a normal C# list. Data is lost when the app stops.
    public class InMemoryClientRepository : IClientRepository
    {
        private readonly List<Client> _clients = new List<Client>();
        private int _nextId = 1;

        public InMemoryClientRepository()
        {
            // A few sample rows so the table is not empty on first run.
            Add(new Client { FullName = "Ayesha Khan", CompanyName = "BrightPath Traders", Email = "ayesha@brightpath.com", PhoneNumber = "+92 300 1234567", ServiceRequired = "Website Design" });
            Add(new Client { FullName = "Omar Farooq", CompanyName = "Farooq Logistics", Email = "omar@farooqlogistics.com", PhoneNumber = "+92 321 7654321", ServiceRequired = "SEO Services" });
            Add(new Client { FullName = "Sara Malik", CompanyName = "Malik Boutique", Email = "sara@malikboutique.com", PhoneNumber = "+92 333 5550123", ServiceRequired = "Social Media Marketing" });
        }

        public List<Client> GetAll()
        {
            return _clients.OrderBy(c => c.Id).ToList();
        }

        public Client? GetById(int id)
        {
            return _clients.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Client client)
        {
            client.Id = _nextId++;   // automatic Client ID
            _clients.Add(client);
        }

        public bool Update(Client updated)
        {
            var existing = GetById(updated.Id);
            if (existing == null)
            {
                return false;
            }

            existing.FullName = updated.FullName;
            existing.CompanyName = updated.CompanyName;
            existing.Email = updated.Email;
            existing.PhoneNumber = updated.PhoneNumber;
            existing.ServiceRequired = updated.ServiceRequired;
            return true;
        }

        public bool Delete(int id)
        {
            var existing = GetById(id);
            if (existing == null)
            {
                return false;
            }

            _clients.Remove(existing);
            return true;
        }
    }
}
