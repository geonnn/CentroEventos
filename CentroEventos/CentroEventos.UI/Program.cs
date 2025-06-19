using CentroEventos.UI.Components;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.UseCases;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

CentroEventosSqlite.Inicializar();

// Blazor:
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddSingleton<Sesion>();

builder.Services.AddSingleton<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddSingleton<UiNotifier>();

builder.Services.AddTransient<IRepositorioPersona, RepositorioPersona>();
builder.Services.AddTransient<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();
builder.Services.AddTransient<IRepositorioReserva, RepositorioReserva>();
builder.Services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();

builder.Services.AddTransient<PersonaValidador>();
builder.Services.AddTransient<EventoDeportivoValidador>();
builder.Services.AddTransient<ReservaValidador>();
builder.Services.AddTransient<UsuarioValidador>();

builder.Services.AddTransient<LoginUseCase>();
builder.Services.AddTransient<LogoutUseCase>();
builder.Services.AddTransient<RegistroUseCase>();
builder.Services.AddTransient<OtorgarPermisoUseCase>();

builder.Services.AddTransient<AltaPersonaUseCase>();
builder.Services.AddTransient<AltaUsuarioUseCase>();
builder.Services.AddTransient<AltaEventoDeportivoUseCase>();
builder.Services.AddTransient<AltaReservaUseCase>();

builder.Services.AddTransient<BajaPersonaUseCase>();
builder.Services.AddTransient<BajaUsuarioUseCase>();
builder.Services.AddTransient<BajaEventoDeportivoUseCase>();
builder.Services.AddTransient<BajaReservaUseCase>();

builder.Services.AddTransient<ModificarPersonaUseCase>();
builder.Services.AddTransient<ModificarUsuarioUseCase>();
builder.Services.AddTransient<ModificarEventoDeportivoUseCase>();
builder.Services.AddTransient<ModificarReservaUseCase>();

builder.Services.AddTransient<ListarPersonaUseCase>();
builder.Services.AddTransient<ListarUsuarioUseCase>();
builder.Services.AddTransient<ListarEventoDeportivoUseCase>();
builder.Services.AddTransient<ListarReservaUseCase>();
builder.Services.AddTransient<ListarEventosConCupoDisponibleUseCase>();
builder.Services.AddTransient<ListarAsistenciaAEventoUseCase>();


// builder.Services.AddProtectedBrowserStorage();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

// using (var scope = app.Services.CreateScope())
// {
//     using var context = new CentroEventosContext();
//     var otorgarPermiso = scope.ServiceProvider.GetRequiredService<OtorgarPermisoUseCase>();

//     if (!context.Usuarios.Any())
//     {
//         var admin = new Usuario("admin", "", "admin@admin", "admin");
//         var todosLosPermisos = Enum.GetValues<Permiso>().ToList();
//         context.Usuarios.Add(admin);
//         context.SaveChanges();
//         otorgarPermiso.Ejecutar(admin,todosLosPermisos,todosLosPermisos);
//     }
// }

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
try
{
    app.Run();
}
catch (Exception e)
{
    Console.WriteLine($"Excepción {e.GetType().Name}:\n" + e.Message);
}