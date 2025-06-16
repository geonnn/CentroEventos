namespace CentroEventos.Aplicacion.UseCases;

using Interfaces;
using Excepciones;
using Entidades;
using Validadores;
using System.Security.Cryptography;
using System.Text;

public class AltaUsuarioUseCase(IRepositorioUsuario repo, UsuarioValidador validador, IServicioAutorizacion autorizador)
{
    public void Ejecutar(Usuario usuario, List<Permiso> permisos)
    {
        if (!autorizador.PoseeElPermiso(permisos, Permiso.UsuarioAlta))
            throw new FalloAutorizacionException("No tiene permiso para añadir una usuario.");
        {
            if (!validador.ValidarConstruccion(usuario, out string mensajeError))
                throw new ValidacionException(mensajeError);
        }
        {
            if (!validador.ValidarDuplicado(usuario, out string mensajeError))
                throw new DuplicadoException(mensajeError);
        }
    
    repo.AltaUsuario(usuario);
    }
}