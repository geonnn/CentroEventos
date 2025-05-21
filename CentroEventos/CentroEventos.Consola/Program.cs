using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.UseCases;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Repositorios;

// Dependencias
IRepositorioPersona repoPersona = new RepositorioPersonaTXT(new IdGetter(), new FileManager());
IRepositorioEventoDeportivo repoEventoDeportivo = new RepositorioEventoDeportivoTXT(new IdGetter(), new FileManager());
IRepositorioReserva repoReserva = new RepositorioReservaTXT(new IdGetter(), new FileManager());
IServicioAutorizacion autorizador = new ServicioAutorizacion();

int Admin = 1;
int Usuario = 0;
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

// Ejecución los casos de uso
try
{
    //agregarPersona.Ejecutar(new Persona("33444555", "Pelo", "Hassan", "ppel@gmail.com", "221555666"),Admin);
    //agregarPersona.Ejecutar(new Persona("33444555", "", "Lara", "gabilara@gmail.com", "221555666"), Admin);
    //agregarPersona.Ejecutar(new Persona("12345678", "Gonzalo", "Gil", "gonzalo@gmail.com", "221444555"), Admin);
    //agregarPersona.Ejecutar(new Persona("987654321", "Gabi", "Lara", "gabilara@gmail.com", "221555666"), Admin);
    //agregarPersona.Ejecutar(new Persona("41294714", "Paula", "uster", "paulauster@gmail.com", "221555666"), Admin);

    // listarPersonas.Ejecutar().ForEach(p => Console.WriteLine(p.ToStringParaTXT()));
    // eliminarPersona.Ejecutar(3, Admin);
    listarPersonas.Ejecutar().ForEach(p => Console.WriteLine(p));
    // modificarPersona.Ejecutar(new Persona(1, "12345678", "Pelo", "Hassan", "ppel@gmail.com", ""), Admin);

    // agregarEventoDeportivo.Ejecutar(new EventoDeportivo("uno", "evento1", new DateTime(2025, 10, 10), 90, 100, 9), Admin);
    // agregarReserva.Ejecutar(new Reserva(1, 1, DateTime.Now, EstadoAsistencia.Pendiente),Admin); // este no tienen que andar porque usuario no tiene la autorizacion pa hacerlo
    // modificarReserva.Ejecutar(new Reserva(1, 2, 1, DateTime.Now, EstadoAsistencia.Pendiente), Admin);
    // agregarEventoDeportivo.Ejecutar(new EventoDeportivo("tres", "evento3", DateTime.Now, 90, 100, 5), Admin);
    System.Console.WriteLine("");
    listarEventosConCupoDisponible.Ejecutar().ForEach(e => Console.WriteLine(e.ToStringParaTXT()));
    System.Console.WriteLine("");
    listarAsistenciaAEvento.Ejecutar(3).ForEach(Console.WriteLine);
    

}
catch (ValidacionException e)
{
    Console.WriteLine(e.Message);
}

catch (CupoExcedidoException e)
{
    Console.WriteLine(e.Message);
}

catch (DuplicadoException e)
{
    Console.WriteLine(e.Message);
}

catch (EntidadNotFoundException e)
{
    Console.WriteLine(e.Message);
}
catch (FalloAutorizacionException e)
{
    Console.WriteLine(e.Message);
}
catch (OperacionInvalidaException e)
{
    Console.WriteLine(e.Message);
}