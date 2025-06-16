namespace CentroEventos.Aplicacion.Entidades;

public class Sesion {
    public Usuario? Usuario {get; private set;}
    public bool estaIniciado {get; private set;}
    
    public Sesion()
    {
        estaIniciado = false;
    }
    public void IniciarSesion(Usuario u)
    {
        Usuario = u;
        estaIniciado = true;
    }

    public void CerrarSesion()
    {
        Usuario = null;    
        estaIniciado = false;
    }
}