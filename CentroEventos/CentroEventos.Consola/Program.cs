using CentroEventos.Aplicacion.EventoDeportivo;
using CentroEventos.Aplicacion.Persona;
using CentroEventos.Aplicacion.Reserva;

using CentroEventos.Repositorios;

// Dependencias
IRepositorioPersona repoPersona = new RepositorioPersonaTXT(new IdGetter(), new FileManager());
IRepositorioEventoDeportivo repoEventoDeportivo = new RepositorioEventoDeportivoTXT(new IdGetter(), new FileManager());
IRepositorioReserva repoReserva = new RepositorioReservaTXT(new IdGetter(), new FileManager());

// Validadores
PersonaValidador validadorPersona = new PersonaValidador();
EventoDeportivoValidador validadorEvento = new EventoDeportivoValidador(repoPersona);
ReservaValidador validadorReserva = new ReservaValidador(repoPersona, repoEventoDeportivo);

// Casos de uso

// Probar optimización: implementar que los constructores de los useCases reciban un tipo Repositorio y un tipo Validador.
// P ej. que los repositorios y validadores hereden de una clase respectivamente en común o implementen una misma interfaz. 
AgregarEventoDeportivoUseCase agregarEventoDeportivo = new AgregarEventoDeportivoUseCase(repoEventoDeportivo, validadorEvento);
AgregarPersonaUseCase agregarPersona = new AgregarPersonaUseCase(repoPersona, validadorPersona);
AgregarReservaUseCase agregarReserva = new AgregarReservaUseCase(repoReserva, validadorReserva);
ListarEventosConCupoDisponibleUseCase listarEventosConCupoDisponible = new ListarEventosConCupoDisponibleUseCase(repoEventoDeportivo, repoReserva);

// Ejecución los casos de uso

agregarPersona.Ejecutar(new Persona("33444555", "Paul", "Auster", "paulauster@gmail.com", "221555666"));
agregarEventoDeportivo.Ejecutar(new EventoDeportivo("uno", "evento1", new DateTime(2025, 10, 10), 90, 100, 1));
agregarReserva.Ejecutar(new Reserva(1, 1, DateTime.Now, EstadoAsistencia.Pendiente));