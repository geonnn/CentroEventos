using CentroEventos.Aplicacion.EventoDeportivo;
using CentroEventos.Aplicacion.Persona;
using CentroEventos.Aplicacion.Reserva;

using CentroEventos.Repositorios;

// Dependencias

IRepositorioEventoDeportivo repoEventoDeportivo = new RepositorioEventoDeportivoTXT();
IRepositorioReserva repoReserva = new RepositorioReservaTXT();
IRepositorioPersona repoPersona = new RepositorioPersonaTXT();

// Casos de uso

var AgregarEventoDeportivo = new AgregarEventoDeportivoUseCase(repoEventoDeportivo);

// Ejecución los casos de uso