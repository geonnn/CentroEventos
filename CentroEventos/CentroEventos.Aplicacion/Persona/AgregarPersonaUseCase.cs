namespace CentroEventos.Aplicacion.Persona;

public class AgregarPersonaUseCase(IRepositorioPersona repo, PersonaValidador validador, int Autorizacion)
{
    public void Ejecutar (Persona persona) 
    {
        try
        {
            if (Autorizacion != 1)
                throw new FalloAutorizacionException("No tiene permiso para añadir una persona");

            validador.Validar(persona);
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