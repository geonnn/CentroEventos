namespace CentroEventos.Aplicacion.Interfaces;
using Entidades;

public interface IRepositorioUsuario
{
    void AltaUsuario(Usuario usuario);
    void BajaUsuario(int id);
    void ModificarUsuario(Usuario usuario);
    List<Usuario> ListarUsuarios();
    bool UsuarioExiste(int id);
    bool UsuarioExiste(string email);
    public Usuario ConsultaUsuario(string email);
    void OtorgarPermiso(Usuario usuario, List<Permiso> permisosOtorgados);
}