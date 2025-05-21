using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.UseCases;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Repositorios;

// Dependencias

// IDGetter y FileManager
IIdGetter idgetter = new IdGetter();
IFileManager filemanager = new FileManager();

// Servicio de autorizacion
IServicioAutorizacion autorizador = new ServicioAutorizacion();
int Admin = 1;
// int Usuario = 0; // usuario para testear validación de autorización.

// Interfaces de repositorios
IRepositorioPersona repoPersona = new RepositorioPersonaTXT(idgetter, filemanager);
IRepositorioEventoDeportivo repoEventoDeportivo = new RepositorioEventoDeportivoTXT(idgetter, filemanager);
IRepositorioReserva repoReserva = new RepositorioReservaTXT(idgetter, filemanager);

// Validadores
PersonaValidador validadorPersona = new PersonaValidador(repoPersona, repoEventoDeportivo, repoReserva);
EventoDeportivoValidador validadorEvento = new EventoDeportivoValidador(repoPersona, repoReserva);
ReservaValidador validadorReserva = new ReservaValidador(repoPersona, repoEventoDeportivo, repoReserva);

// Casos de uso

// Probar optimización: implementar que los constructores de los useCases reciban un tipo Repositorio y un tipo Validador.
// P ej. que los repositorios y validadores hereden de una clase respectivamente en común o implementen una misma interfaz.

// Persona
AgregarPersonaUseCase agregarPersona = new AgregarPersonaUseCase(repoPersona, validadorPersona, autorizador);
EliminarPersonaUseCase eliminarPersona = new EliminarPersonaUseCase(repoPersona, validadorPersona, autorizador);
ModificarPersonaUseCase modificarPersona = new ModificarPersonaUseCase(repoPersona, validadorPersona, autorizador);
ListarPersonaUseCase listarPersonas = new ListarPersonaUseCase(repoPersona);

// Evento Deportivo
AgregarEventoDeportivoUseCase agregarEventoDeportivo = new AgregarEventoDeportivoUseCase(repoEventoDeportivo, validadorEvento, autorizador);
EliminarEventoDeportivoUseCase eliminarEvento = new EliminarEventoDeportivoUseCase(repoEventoDeportivo, validadorEvento, autorizador);
ModificarEventoDeportivoUseCase modificarEvento = new ModificarEventoDeportivoUseCase(repoEventoDeportivo, validadorEvento, autorizador);
ListarEventoDeportivoUseCase listarEventos = new ListarEventoDeportivoUseCase(repoEventoDeportivo);
ListarEventosConCupoDisponibleUseCase listarEventosConCupoDisponible = new ListarEventosConCupoDisponibleUseCase(repoEventoDeportivo, repoReserva);
ListarAsistenciaAEventoUseCase listarAsistenciaAEvento = new ListarAsistenciaAEventoUseCase(repoEventoDeportivo, repoReserva, repoPersona);

// Reserva
AgregarReservaUseCase agregarReserva = new AgregarReservaUseCase(repoReserva, validadorReserva, autorizador);
EliminarReservaUseCase eliminarReserva = new EliminarReservaUseCase(repoReserva, autorizador);
ModificarReservaUseCase modificarReserva = new ModificarReservaUseCase(repoReserva, validadorReserva, autorizador);
ListarReservaUseCase listarReservas = new ListarReservaUseCase(repoReserva);

// Ejecución de los casos de uso
try
{
    agregarPersona.Ejecutar(new Persona("33444555", "Nombre1", "Apellido1", "email1@gmail.com", "221222333"), Admin);
    agregarPersona.Ejecutar(new Persona("11222333", "Nombre2", "Apellido2", "email2@gmail.com", "221444555"), Admin);

    // listarPersonas.Ejecutar().ForEach(Console.WriteLine);
    // eliminarPersona.Ejecutar(3, Admin);
    // System.Console.WriteLine("");
    // listarPersonas.Ejecutar().ForEach(Console.WriteLine);
    // modificarPersona.Ejecutar(new Persona(1, "12345678", "Pelo", "Hassan", "ppel@gmail.com", ""), Admin);

    // agregarEventoDeportivo.Ejecutar(new EventoDeportivo("uno", "evento1", new DateTime(2025, 10, 10), 90, 100, 9), Admin);
    // agregarReserva.Ejecutar(new Reserva(1, 1, DateTime.Now, EstadoAsistencia.Pendiente),Admin); // este no tienen que andar porque usuario no tiene la autorizacion pa hacerlo
    // modificarReserva.Ejecutar(new Reserva(1, 2, 1, DateTime.Now, EstadoAsistencia.Pendiente), Admin);
    // agregarEventoDeportivo.Ejecutar(new EventoDeportivo("tres", "evento3", DateTime.Now, 90, 100, 5), Admin);
    // System.Console.WriteLine("");
    // listarEventosConCupoDisponible.Ejecutar().ForEach(e => Console.WriteLine(e.ToStringParaTXT()));
    // System.Console.WriteLine("");
    // listarAsistenciaAEvento.Ejecutar(3).ForEach(Console.WriteLine);
}
catch (Exception e)
{
    Console.WriteLine($"Excepción {e}:" + e.Message);
}