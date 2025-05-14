namespace CentroEventos.Aplicacion.Persona;

public class ListarPersonaUseCase(IRepositorioPersona repo)
{
public List<Persona> Ejecutar()
{
return repo.ListarPersonas();
}
}