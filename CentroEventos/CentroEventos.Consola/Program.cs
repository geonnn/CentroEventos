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
AgregarPersonaUseCase agregarPersona = new AgregarPersonaUseCase(repoPersona);
AgregarReservaUseCase agregarReserva = new AgregarReservaUseCase(repoReserva);

// Ejecución los casos de uso

agregarPersona.Ejecutar(new Persona("33444555", "Paul", "Auster", "paulauster@gmail.com", "221555666"));
agregarEventoDeportivo.Ejecutar(new EventoDeportivo("uno", "evento1", new DateTime(2025, 10, 10), 90, 100, 5));
agregarReserva.Ejecutar(new Reserva(1, 1, DateTime.Now, EstadoAsistencia.Pendiente));