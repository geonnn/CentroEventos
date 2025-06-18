namespace CentroEventos.Aplicacion.UseCases;

using CentroEventos.Aplicacion.Entidades;


public class LogoutUseCase(Sesion sesion)
{
    public bool Ejecutar()
    {
        sesion.CerrarSesion();
        return true;
    }

}