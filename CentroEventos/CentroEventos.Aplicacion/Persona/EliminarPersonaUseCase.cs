namespace CentroEventos.Aplicacion;

public class EliminarPersonaUseCase(IRepositorioPersona repo)
{
public void Ejecutar(Persona persona)
{
repo.EliminarPersona(persona);
}
}