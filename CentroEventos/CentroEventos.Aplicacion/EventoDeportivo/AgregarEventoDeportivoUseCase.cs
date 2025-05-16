namespace CentroEventos.Aplicacion.EventoDeportivo;

public class AgregarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo, EventoDeportivoValidador validador)
{
    public void Ejecutar(EventoDeportivo evento)
    {
        try
        {
            if (!validador.Validar(evento, out string mensajeError))
                throw new ValidacionException(mensajeError);

            //if(!TienePermiso) Validar que tenga permiso el usuario
            //    throw new FalloAutorizacionException("No tiene permiso para añadir una persona");

            //if (!_repoPersona.PersonaExiste(evento.ResponsableId)) TENEMOS QUE MANDAR EL REPO DE PERSONAS POR QUE SI NO EXISTE EL RESPONSABLE ES OTRO TIPO DE EXCEPTION
            //    throw new EntidadNotFoundException("El responsable no existe");

            if(evento.FechaHoraInicio < DateTime.Now)
                throw new  OperacionInvalidaException("No se puede crear un evento en el pasado");

            repo.AgregarEventoDeportivo(evento);
            Console.WriteLine($"Evento ID {evento.Id} añadido exitosamente.");
        }
        catch (ValidacionException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al añadir el evento ID {evento.Id}.");
        }
        catch (FalloAutorizacionException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al añadir el evento ID {evento.Id}.");
        }
        catch (EntidadNotFoundException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al añadir el evento ID {evento.Id}.");
        }
        catch (OperacionInvalidaException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al añadir el evento ID {evento.Id}.");
        }
        
    }
}