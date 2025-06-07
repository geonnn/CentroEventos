namespace CentroEventos.Aplicacion.Interfaces;
using Entidades;
public interface IServicioAutorizacion
{
    bool PoseeElPermiso(int idPersona, Permiso permiso);
}