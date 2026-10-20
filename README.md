# Client Management System (ASP.NET Core MVC)

Beginner CRUD assignment. In-memory storage, Bootstrap 5 UI.

## Run in Visual Studio
1. Open `ClientManagementSystem.csproj` (File > Open > Project/Solution).
2. Press F5 (or Ctrl+F5). The browser opens on the client list.

## Run from a terminal
    dotnet run

Then open the URL shown in the console (e.g. https://localhost:7xxx).

## Folder guide
- Models/       Client.cs (data + validation rules)
- Services/     IClientRepository + InMemoryClientRepository (storage)
- Controllers/  ClientController.cs (CRUD actions)
- Views/Client/ Index, Create, Edit, Details, Delete, _ClientForm
- Views/Shared/ _Layout.cshtml (page frame, navbar, Bootstrap)
- wwwroot/      css/site.css (static files)

Note: data is lost when the app stops (no database yet).
Bootstrap loads from a CDN, so an internet connection is needed for styling.
"# clientmanagementsys-" 
