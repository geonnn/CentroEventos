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
        var lista = new List<Usuario>();

        using (var context = new CentroEventosContext())
            foreach (var u in context.Usuarios)
                lista.Add(u);
        return lista;
    }

    public bool UsuarioExiste(int id)
    {
        using (var context = new CentroEventosContext())
        return context.Usuarios.FirstOrDefault(u => u.Id == id) != null;
    }

    public bool UsuarioExiste(string email)
    {
        using (var context = new CentroEventosContext())
        return context.Usuarios.FirstOrDefault(u => u.Email == email) != null;
    }

    public Usuario ConsultaUsuario(string email)
    {
        using (var context = new CentroEventosContext())
        return context.Usuarios.First(u => u.Email == email);
    }

    public void OtorgarPermiso(Usuario usuario, List<Permiso> permisosOtorgados)
    {
        usuario.AgregarPermiso(permisosOtorgados);
        ModificarUsuario(usuario);
    }
}