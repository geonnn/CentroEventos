using CentroEventos.Aplicacion.EventoDeportivo;
using CentroEventos.Aplicacion.Persona;
using CentroEventos.Aplicacion.Reserva;

using CentroEventos.Repositorios;

// Dependencias
IRepositorioEventoDeportivo repoEventoDeportivo = new RepositorioEventoDeportivoTXT(new IdGetter(), new FileManager());
IRepositorioReserva repoReserva = new RepositorioReservaTXT(new IdGetter(), new FileManager());
IRepositorioPersona repoPersona = new RepositorioPersonaTXT(new IdGetter(), new FileManager());

// Casos de uso

AgregarEventoDeportivoUseCase agregarEventoDeportivo = new AgregarEventoDeportivoUseCase(repoEventoDeportivo);

// Ejecución los casos de uso

agregarEventoDeportivo.Ejecutar(new EventoDeportivo("uno", "evento1", new DateTime(2025, 10, 10), 90, 100, 5));