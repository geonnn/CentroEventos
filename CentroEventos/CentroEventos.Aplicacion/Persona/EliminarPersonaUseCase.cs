namespace CentroEventos.Aplicacion.Persona;

public class EliminarPersonaUseCase(IRepositorioPersona repo)
{
    public void Ejecutar(Persona persona)
    {
        try {
            if(!repo.PersonaExiste(persona.Id))
                throw new EntidadNotFoundException("Persona no encontrada");

            //if(!TienePermiso) Validar que tenga permiso el usuario
            //    throw new FalloAutorizacionException("No tiene permiso para eliminar una persona");

            //if(persona tiene reserva)
            //    throw new OperacionInvalidaException("No se puede eliminar una persona con reservas"); FALTA REPO RESERVA

            //if(persona es responsable de evento)
            //    throw new OperacionInvalidaException("No se puede eliminar una persona con eventos"); FALTA REPO EVENTODEPORTIVO

            repo.EliminarPersona(persona.Id);
            Console.WriteLine($"Persona ID {persona.Id} eliminada exitosamente.");
        }
        catch (EntidadNotFoundException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al eliminar persona ID {persona.Id}.");
        }
        catch (FalloAutorizacionException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al eliminar persona ID {persona.Id}.");
        }
        catch (OperacionInvalidaException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al eliminar persona ID {persona.Id}.");
        }
        
    }
}
