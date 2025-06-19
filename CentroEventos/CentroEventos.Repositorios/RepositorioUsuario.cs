namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;


public class RepositorioUsuario : IRepositorioUsuario
{

    public RepositorioUsuario() { }

    public void AltaUsuario(Usuario usuario)
    {
        using var context = new CentroEventosContext();
        context.Add(usuario);
        context.SaveChanges();
    }

    public void BajaUsuario(int id)
    {
        using var context = new CentroEventosContext();
        // context.Personas.Remove(persona);
        context.Usuarios.Remove(context.Usuarios.Where(u => u.Id == id).Single());
        context.SaveChanges();
    }

    public void ModificarUsuario(Usuario nuevoUsuario)
    {
        using var context = new CentroEventosContext();
        context.Usuarios.Update(nuevoUsuario);
        context.SaveChanges();
    }

    public List<Usuario> ListarUsuarios()
    {
        using var context = new CentroEventosContext();
        return context.Usuarios.ToList();
    }

    public bool UsuarioExiste(int id)
    {
        using var context = new CentroEventosContext();
        return context.Usuarios.Any(u => u.Id == id);
    }

    public bool UsuarioExiste(string email)
    {
        using var context = new CentroEventosContext();
        return context.Usuarios.Any(u => u.Email == email);
    }

    public Usuario ConsultaUsuario(string email)
    {
        using var context = new CentroEventosContext();
        return context.Usuarios.First(u => u.Email == email);
    }

    public void OtorgarPermiso(Usuario usuario, List<Permiso> permisosOtorgados)
    {
        usuario.AgregarPermiso(permisosOtorgados);
        ModificarUsuario(usuario);
    }
}