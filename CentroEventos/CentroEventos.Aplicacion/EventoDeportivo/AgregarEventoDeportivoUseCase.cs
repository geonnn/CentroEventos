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
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Excepción: " + e);
            System.Console.WriteLine("El evento no se pudo añadir.");
        }

    }
}