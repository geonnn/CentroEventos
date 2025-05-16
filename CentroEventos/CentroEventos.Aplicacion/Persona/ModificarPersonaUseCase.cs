namespace CentroEventos.Aplicacion.Persona;

public class ModificarPersonaUseCase(IRepositorioPersona repo)
{
    public void Ejecutar(Persona persona) // La persona que recibe esta validada?? de lo contrario pensar como validar
    {
        try
        {
            if(!repo.PersonaExiste(persona.Id))
                throw new EntidadNotFoundException("Persona no encontrada");
            
            //if(!TienePermiso) Validar que tenga permiso el usuario
            //    throw new FalloAutorizacionException("No tiene permiso para eliminar una persona");

            repo.ModificarPersona(persona);
            Console.WriteLine($"Persona ID {persona.Id} modificada exitosamente.");
        }
        catch(EntidadNotFoundException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al modificar ID {persona.Id}.");
        }
        catch (FalloAutorizacionException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al eliminar persona ID {persona.Id}.");
        }
    }
}