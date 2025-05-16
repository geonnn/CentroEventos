using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Clases;

namespace CentroEventos.Aplicacion.Reserva;

public class AgregarReservaUseCase(IRepositorioReserva repoReserva, ReservaValidador validador, IServicioAutorizacion autorizador) {
    
    public void Ejecutar(Reserva reserva, int idUsuario) 
    {
        try
        {
            if (!validador.Validar(reserva, out string mensajeError))
                throw new ValidacionException(mensajeError);

            if (!autorizador.PoseeElPermiso(idUsuario, Permiso.ReservaAlta))
                throw new FalloAutorizacionException("No tiene permiso para añadir una persona.");

            repoReserva.AgregarReserva(reserva);
            Console.WriteLine($"Persona ID {reserva.Id} añadido exitosamente.");
        }
        catch (ValidacionException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al añadir el reserva ID {reserva.Id}.");
        }
        catch(FalloAutorizacionException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al añadir reserva {reserva.Id}.");
        }
        
        
    }
}