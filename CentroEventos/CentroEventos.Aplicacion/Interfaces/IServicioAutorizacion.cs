namespace CentroEventos.Aplicacion.Interfaces;
using Entidades;

public interface IServicioAutorizacion
{
    bool PoseeElPermiso(List<Permiso> permisosUsuario, Permiso permiso);
}