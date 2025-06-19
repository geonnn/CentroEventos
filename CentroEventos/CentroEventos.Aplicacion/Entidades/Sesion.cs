namespace CentroEventos.Aplicacion.Entidades;

public class Sesion
{
    public Usuario Usuario { get; private set; } = new Usuario("", "", "", "");
    public bool EstaIniciado { get; private set; } = false;

    public Sesion()
    {
        EstaIniciado = false;
    }
    public void IniciarSesion(Usuario u)
    {
        Usuario = u;
        EstaIniciado = true;
    }

    public void CerrarSesion()
    {
        Usuario = new Usuario("", "", "", "");
        EstaIniciado = false;
    }
}