namespace CentroEventos.Aplicacion.Persona;

public class EliminarPersonaUseCase(IRepositorioPersona repo)
{
    public void Ejecutar(Persona persona)
    {
        repo.EliminarPersona(persona.Id);
    }
}