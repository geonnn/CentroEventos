namespace CentroEventos.Aplicacion.Persona;

public class AgregarPersonaUseCase(IRepositorioPersona repo)
{
    public void Ejecutar (Persona persona) {
        repo.AgregarPersona(persona);
    }
}