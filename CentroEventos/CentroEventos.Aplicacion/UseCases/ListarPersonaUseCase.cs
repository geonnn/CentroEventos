namespace CentroEventos.Aplicacion.UseCases;
using Entidades;
using Interfaces;
public class ListarPersonaUseCase(IRepositorioPersona repo)
{
    public List<Persona> Ejecutar()
    {
        return repo.ListarPersonas();
    }
}