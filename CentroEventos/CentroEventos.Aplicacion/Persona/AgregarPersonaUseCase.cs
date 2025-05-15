namespace CentroEventos.Aplicacion.Persona;

public class AgregarPersonaUseCase(IRepositorioPersona repo, PersonaValidador validador)
{
    public void Ejecutar (Persona persona) {
        if (!validador.Validar(persona, out string mensajeError))
            throw new Exception(mensajeError);
        
        repo.AgregarPersona(persona);
    }
}