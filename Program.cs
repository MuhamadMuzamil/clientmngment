using ClientManagementSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Register MVC (Controllers + Views)
builder.Services.AddControllersWithViews();

// 2. Register our client "storage".
//    Singleton = one shared instance for the whole app, so the in-memory list
//    keeps its data between requests.
//    LATER: replace InMemoryClientRepository with a database version here.
builder.Services.AddSingleton<IClientRepository, InMemoryClientRepository>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();   // serves files from wwwroot (our CSS)
app.UseRouting();
app.UseAuthorization();

// 3. Default route: opening the site shows the client list (ClientController -> Index)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Client}/{action=Index}/{id?}");

app.Run();
