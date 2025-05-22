using CentroEventos.Aplicacion.Entidades;
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
    // Alta de personas
    agregarPersona.Ejecutar(new Persona("123", "Juan", "Pérez", "juan@mail.com", "221111111"), Admin);
    agregarPersona.Ejecutar(new Persona("456", "Ana", "García", "ana@mail.com"), Admin);
    agregarPersona.Ejecutar(new Persona("789", "Luis", "Martínez", "luis@mail.com", "221222333"), Admin);

    // Listado de personas
    Console.WriteLine("Personas:");
    listarPersonas.Ejecutar().ForEach(Console.WriteLine);
    Console.WriteLine();

    // Modificación de persona
    modificarPersona.Ejecutar(new Persona(1, "123", "Juan Carlos", "Pérez", "juan@mail.com", "221111111"), Admin);

    // Eliminación de persona
    eliminarPersona.Ejecutar(2, Admin);

    // Listado final de personas
    Console.WriteLine("Personas después de modificar y eliminar:");
    listarPersonas.Ejecutar().ForEach(Console.WriteLine);
    Console.WriteLine();

    // Alta de eventos deportivos
    agregarEventoDeportivo.Ejecutar(
        new EventoDeportivo("Fútbol 5", "Torneo amistoso", new DateTime(2025, 7, 15, 18, 0, 0), 2, 10, 1), Admin);
    agregarEventoDeportivo.Ejecutar(
        new EventoDeportivo("Básquet", "Torneo rápido", new DateTime(2025, 8, 20, 19, 0, 0), 4, 20, 1), Admin);

    // Listado de eventos deportivos
    Console.WriteLine("Eventos deportivos:");
    listarEventos.Ejecutar().ForEach(Console.WriteLine);
    Console.WriteLine();

    // Alta de reservas
    agregarReserva.Ejecutar(
        new Reserva(1, 1, new DateTime(2025, 7, 10, 10, 0, 0), EstadoAsistencia.Pendiente), Admin);
    agregarReserva.Ejecutar(
        new Reserva(3, 2, new DateTime(2025, 8, 18, 15, 0, 0), EstadoAsistencia.Pendiente), Admin);

    // Listado de reservas
    Console.WriteLine("Reservas:");
    listarReservas.Ejecutar().ForEach(Console.WriteLine);
    Console.WriteLine();

    // Modificación de reserva
    modificarReserva.Ejecutar(
        new Reserva(1, 1, 1, new DateTime(2025, 7, 10, 10, 0, 0), EstadoAsistencia.Presente), Admin);

    // Eliminación de reserva
    eliminarReserva.Ejecutar(2, Admin);

    // Listado final de reservas
    Console.WriteLine("Reservas después de modificar y eliminar:");
    listarReservas.Ejecutar().ForEach(Console.WriteLine);
    Console.WriteLine();

    // Listar eventos con cupo disponible
    Console.WriteLine("Eventos con cupo disponible:");
    listarEventosConCupoDisponible.Ejecutar().ForEach(Console.WriteLine);
    Console.WriteLine();

    // Prueba de error: intentar eliminar persona inexistente
    try
    {
        eliminarPersona.Ejecutar(99, Admin);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Prueba de error al eliminar persona inexistente: " + ex.Message);
    }
}
catch (Exception e)
{
    Console.WriteLine($"Excepción {e.GetType().Name}:\n" + e.Message);
}