using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

public class ServicioAutorizacion : IServicioAutorizacion
{
    public bool PoseeElPermiso(int id, Permiso permiso)
    => id == 1 ;
}