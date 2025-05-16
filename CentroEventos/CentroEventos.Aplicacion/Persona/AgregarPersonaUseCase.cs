namespace CentroEventos.Aplicacion.Persona;

public class AgregarPersonaUseCase(IRepositorioPersona repo, PersonaValidador validador)
{
    public void Ejecutar (Persona persona) 
    {
        try
        {
            if (!validador.Validar(persona, out string mensajeError))
                throw new ValidacionException(mensajeError);

            //if(!TienePermiso) Validar que tenga permiso el usuario
            //    throw new FalloAutorizacionException("No tiene permiso para añadir una persona");

            if(repo.DniExiste(persona.Dni))
                throw new DuplicadoException("El DNI ya existe");

            if(repo.EmailExiste(persona.Email))
                throw new DuplicadoException("El Email ya existe");

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