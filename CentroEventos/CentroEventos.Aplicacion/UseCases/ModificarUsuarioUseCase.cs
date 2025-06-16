namespace CentroEventos.Aplicacion.UseCases;
using Interfaces;
using Entidades;
using Excepciones;
using Validadores;


public class ModificarUsuarioUseCase(IRepositorioUsuario repo, UsuarioValidador validador, IServicioAutorizacion autorizador)
{
    public void Ejecutar(Usuario usuario, Usuario usuEjecuta)
    {
        if (usuario.Id != usuEjecuta.Id)
        {
            if (!autorizador.PoseeElPermiso(usuEjecuta.Permisos, Permiso.UsuarioModificacion))
                throw new FalloAutorizacionException("No tiene permiso para modificar otros usuarios.");
            if (!repo.UsuarioExiste(usuario.Id))
                throw new EntidadNotFoundException($"El usuario ID {usuario.Id} no encontrado.");
        }
        {
            if (!validador.ValidarConstruccion(usuario, out string mensajeError))
                throw new ValidacionException(mensajeError);
        }
        {
            if (!validador.ValidarDuplicadoModificar(usuario, out string mensajeError))
                throw new DuplicadoException(mensajeError);
        }

        repo.ModificarUsuario(usuario);
    }
}