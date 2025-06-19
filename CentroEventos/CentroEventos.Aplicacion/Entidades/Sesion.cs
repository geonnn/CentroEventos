namespace CentroEventos.Aplicacion.Entidades;

using CentroEventos.Aplicacion.Interfaces;


public class Sesion
{
    public Usuario Usuario { get; private set; } = new Usuario("", "", "", "");
    public bool EstaIniciado { get; private set; }

    public Sesion()
    {
        Console.WriteLine("nueva sesion" + DateTime.Now);
        EstaIniciado = false;
    }
    public void IniciarSesion(Usuario u)
    {
        Usuario = u;
        EstaIniciado = true;
    }

    public void CerrarSesion()
    {
        Console.WriteLine("CerrarSesion()" + DateTime.Now);
        Usuario = new Usuario("", "", "", "");
        EstaIniciado = false;
    }
    

}