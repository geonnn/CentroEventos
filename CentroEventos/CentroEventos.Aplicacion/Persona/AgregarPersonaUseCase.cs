namespace CentroEventos.Aplicacion.Persona;

public class AgregarPersonaUseCase(IRepositorioPersona repo, PersonaValidador validador)
{
    public void Ejecutar (Persona persona) 
    {
        try
        {
            // if (!validador.Validar(persona, out string mensajeError))
            //     throw new ValidacionException(mensajeError);

            validador.Validar(persona);
            //if(!TienePermiso) Validar que tenga permiso el usuario
            //    throw new FalloAutorizacionException("No tiene permiso para añadir una persona");

            
            repo.AgregarPersona(persona);
            Console.WriteLine($"Persona ID {persona.Id} añadido exitosamente.");
        }
        catch (ValidacionException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al añadir la persona ID {persona.Id}.");
        }
        catch (FalloAutorizacionException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al añadir persona {persona.Id}.");
        }
        catch (DuplicadoException e)
        {
            Console.WriteLine("Excepción: " + e);
            Console.WriteLine($"Error al añadir persona {persona.Id}.");
        }
    }
}