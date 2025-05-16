namespace CentroEventos.Aplicacion.EventoDeportivo;

public class ModificarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo)
{
    public void Ejecutar(EventoDeportivo evento) //el evento que recibe esta validada?? de lo contrario pensar como validar
    {
        try
        {
            //if(!TienePermiso) Validar que tenga permiso el usuario
            //    throw new FalloAutorizacionException("No tiene permiso para añadir una persona");
            
            if(!repo.EventoExiste(evento.Id))
                throw new EntidadNotFoundException("Evento no encontrado");

            //if (nuevo responsable existe) REQUIERE REPO PERSONA
            //    throw new EntidadNotFoundException("El responsable no existe");

            if(repo.Finalizo(evento.Id))
                throw new OperacionInvalidaException("No se puede modificar un evento en el pasado");

            repo.ModificarEventoDeportivo(evento.Id);
            Console.WriteLine($"Evento ID {evento.Id} modificado exitosamente.");
        }
        catch(FalloAutorizacionException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al modificar el evento ID {evento.Id}.");
        }
        catch(EntidadNotFoundException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al modificar el evento ID {evento.Id}.");
        }
        catch(OperacionInvalidaException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al modificar el evento ID {evento.Id}.");
        }
    }

}
