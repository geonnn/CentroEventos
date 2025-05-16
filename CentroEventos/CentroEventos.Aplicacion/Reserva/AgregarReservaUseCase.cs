namespace CentroEventos.Aplicacion.Reserva;

public class AgregarReservaUseCase(IRepositorioReserva repoReserva, ReservaValidador validador) {
    
    public void Ejecutar(Reserva reserva) 
    {
        try
        {
            if (!validador.Validar(reserva, out string mensajeError))
                throw new ValidacionException(mensajeError);

            repoReserva.AgregarReserva(reserva);
            Console.WriteLine($"Persona ID {reserva.Id} añadido exitosamente.");
        }
        catch (ValidacionException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al añadir el reserva ID {reserva.Id}.");
        }
    }
}