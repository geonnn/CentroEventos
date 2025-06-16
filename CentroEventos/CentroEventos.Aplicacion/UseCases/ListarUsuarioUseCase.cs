namespace CentroEventos.Aplicacion.UseCases;

using Interfaces;
using Entidades;

public class ListarUsuarioUseCase(IRepositorioUsuario repo)
{
    public List<Usuario> Ejecutar()
    {
        return repo.ListarUsuarios();
    }
}
