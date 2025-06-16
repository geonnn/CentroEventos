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

builder.Services.AddSingleton<IServicioAutorizacion, ServicioAutorizacion>();

builder.Services.AddTransient<IRepositorioPersona, RepositorioPersona>();
builder.Services.AddTransient<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();
builder.Services.AddTransient<IRepositorioReserva, RepositorioReserva>();
builder.Services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();

builder.Services.AddTransient<PersonaValidador>();
builder.Services.AddTransient<EventoDeportivoValidador>();
builder.Services.AddTransient<ReservaValidador>();
builder.Services.AddTransient<UsuarioValidador>();

builder.Services.AddTransient<LoginUseCase>();
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

builder.Services.AddScoped<Sesion>();



// builder.Services.AddScoped

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();