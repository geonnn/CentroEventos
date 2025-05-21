using CentroEventos.Aplicacion.EventoDeportivo;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Persona;
using CentroEventos.Aplicacion.Reserva;
using CentroEventos.Aplicacion.Clases;

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
AgregarEventoDeportivoUseCase agregarEventoDeportivo = new AgregarEventoDeportivoUseCase(repoEventoDeportivo, validadorEvento, autorizador);
AgregarPersonaUseCase agregarPersona = new AgregarPersonaUseCase(repoPersona, validadorPersona, autorizador);
AgregarReservaUseCase agregarReserva = new AgregarReservaUseCase(repoReserva, validadorReserva, autorizador);
ListarEventosConCupoDisponibleUseCase listarEventosConCupoDisponible = new ListarEventosConCupoDisponibleUseCase(repoEventoDeportivo, repoReserva);
ListarAsistenciaAEventoUseCase listaPersonasQueFueronAEvento = new ListarAsistenciaAEventoUseCase(repoEventoDeportivo, repoReserva, repoPersona, 3);

// Ejecución los casos de uso
try
{
    agregarPersona.Ejecutar(new Persona("33444555", "Paul", "Auster", "paulauster@gmail.com", "221555666"),Admin);
    agregarEventoDeportivo.Ejecutar(new EventoDeportivo("uno", "evento1", new DateTime(2025, 10, 10), 90, 100, 1),Admin);
    agregarReserva.Ejecutar(new Reserva(1, 1, DateTime.Now, EstadoAsistencia.Pendiente),Usuario); // este no tienen que andar porque usuario no tiene la autorizacion pa hacerlo
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