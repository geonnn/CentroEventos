namespace CentroEventos.Aplicacion.Reserva;

public class AgregarReservaUseCase(IRepositorioReserva repoReserva, ReservaValidador validador) {
    
    public void Ejecutar(Reserva reserva) 
    {
        try
        {
            if (!validador.Validar(reserva, out string mensajeError))
                throw new ValidacionException(mensajeError);

            //if(!TienePermiso) Validar que tenga permiso el usuario
            //    throw new FalloAutorizacionException("No tiene permiso para añadir una persona");

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