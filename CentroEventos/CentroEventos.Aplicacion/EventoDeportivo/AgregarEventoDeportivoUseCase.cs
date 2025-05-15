namespace CentroEventos.Aplicacion.EventoDeportivo;

public class AgregarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo, EventoDeportivoValidador validador)
{
    public void Ejecutar(EventoDeportivo evento)
    {
        try
        {
            if (!validador.Validar(evento, out string mensajeError))
                throw new Exception(mensajeError);

            repo.AgregarEventoDeportivo(evento);
            Console.WriteLine($"Evento ID {evento.Id} añadido exitosamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al añadir el evento ID {evento.Id}.");
        }

    }
}