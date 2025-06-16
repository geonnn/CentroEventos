namespace CentroEventos.Aplicacion.UseCases;

using Interfaces;
using Excepciones;
using Entidades;
using Validadores;
using System.Security.Cryptography;
using System.Text;

public class OtorgarPermisoUseCase(IRepositorioUsuario repoU, IServicioAutorizacion autorizador)
{
    public void Ejecutar(Usuario usuario,List<Permiso> permisosOtorgados, List<Permiso> permisosUsuQueEjecuta)
    {
        if (!autorizador.PoseeElPermiso(permisosUsuQueEjecuta, Permiso.OtorgarPermisos))
            throw new FalloAutorizacionException("No tiene permiso para añadir una usuario.");
        {
        if(!repoU.UsuarioExiste(usuario.Id))
            throw new EntidadNotFoundException("El usuario al que quiere dar permisos no existe.");
        }

    repoU.OtorgarPermiso(usuario, permisosOtorgados);
    }
}