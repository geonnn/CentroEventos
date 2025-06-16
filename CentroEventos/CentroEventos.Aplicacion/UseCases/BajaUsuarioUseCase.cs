namespace CentroEventos.Aplicacion.UseCases;

using Interfaces;
using Entidades;
using Excepciones;
using Validadores;


public class BajaUsuarioUseCase(IRepositorioUsuario repo, IServicioAutorizacion autorizador)
{
    public void Ejecutar( int IdUsuario, List<Permiso> permisos)
    {
        if (!autorizador.PoseeElPermiso(permisos, Permiso.UsuarioBaja))
            throw new FalloAutorizacionException("No tiene permiso para eliminar una persona.");

        if (!repo.UsuarioExiste(IdUsuario))
            throw new EntidadNotFoundException($"El usuario ID {IdUsuario} no encontrado.");

        repo.BajaUsuario(IdUsuario);
    }
}