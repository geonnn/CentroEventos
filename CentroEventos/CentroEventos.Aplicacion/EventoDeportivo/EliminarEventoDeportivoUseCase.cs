namespace CentroEventos.Aplicacion.EventoDeportivo;

public class EliminarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo)
{
    public void Ejecutar(int id)
    {
        try
        {
            //if(!TienePermiso) Validar que tenga permiso el usuario
            //    throw new FalloAutorizacionException("No tiene permiso para añadir una persona");

            if (!repo.EventoExiste(id))
                throw new EntidadNotFoundException("Evento no encontrado");
            
            //if (evento tiene reserva)
            //    throw new OperacionInvalidaException("No se puede eliminar un evento con reservas"); FALTA REPO RESERVA

            repo.EliminarEventoDeportivo(id);
            Console.WriteLine($"Persona ID {id} eliminada exitosamente.");
        }
        catch(FalloAutorizacionException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al eliminar el evento ID {id}.");
        }
        catch(EntidadNotFoundException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al eliminar el evento ID {id}.");
        }
        catch(OperacionInvalidaException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al eliminar el evento ID {id}.");
        }
        
    }
}

