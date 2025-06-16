using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

public class ServicioAutorizacion : IServicioAutorizacion
{
    public bool PoseeElPermiso(List<Permiso> permisos, Permiso permiso)
    => permisos.Exists(p => p.Equals(permiso)) ;
}