namespace CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Clases;
public interface IServicioAutorizacion
{
    bool PoseeElPermiso(int idUsuario, Permiso permiso);
}