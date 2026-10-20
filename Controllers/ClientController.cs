using ClientManagementSystem.Models;
using ClientManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientManagementSystem.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _repository;

        // ASP.NET Core "injects" the repository registered in Program.cs.
        public ClientController(IClientRepository repository)
        {
            _repository = repository;
        }

        // READ (list): GET /Client
        public IActionResult Index()
        {
            var clients = _repository.GetAll();
            return View(clients);
        }

        // READ (one): GET /Client/Details/5
        public IActionResult Details(int id)
        {
            var client = _repository.GetById(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // CREATE (show empty form): GET /Client/Create
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (save form): POST /Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client client)
        {
            if (!ModelState.IsValid)
            {
                return View(client);   // show the form again with error messages
            }

            _repository.Add(client);
            TempData["Message"] = "Client added successfully.";
            return RedirectToAction(nameof(Index));
        }

        // UPDATE (show form filled with existing data): GET /Client/Edit/5
        public IActionResult Edit(int id)
        {
            var client = _repository.GetById(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // UPDATE (save changes): POST /Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(client);
            }

            if (!_repository.Update(client))
            {
                return NotFound();
            }

            TempData["Message"] = "Client updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        // DELETE (show confirmation page): GET /Client/Delete/5
        public IActionResult Delete(int id)
        {
            var client = _repository.GetById(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // DELETE (really delete after confirmation): POST /Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!_repository.Delete(id))
            {
                return NotFound();
            }

            TempData["Message"] = "Client deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
