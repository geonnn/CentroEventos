namespace CentroEventos.Aplicacion.Entidades;
using System.Security.Cryptography;
using System.Text;

public class Usuario
{
    public int Id { get; private set; }
    public string Nombre { get; private set; }
    public string Apellido { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public List<Permiso> Permisos { get; private set; } // nav para Entity Framework

    // Constructor para EF
#nullable disable
    protected Usuario() { }
#nullable enable

    public Usuario(string nom, string ap, string email, string pw)
    {
        Nombre = nom;
        Apellido = ap;
        Email = email;
        Permisos = new();
        Password = Hash(pw);
    }

    public void Actualizar(Usuario u)
    {
        this.Nombre = u.Nombre;
        this.Apellido = u.Apellido;
        this.Email = u.Email;
        this.Permisos = u.Permisos;
        this.Password = u.Password;
    }

    public void AgregarPermiso(List<Permiso> permisos)
    {
        Permisos = permisos;
    }
    public bool PoseeElPermiso(Permiso permisoRequerido)
    {
        return Permisos.Contains(permisoRequerido);
    }

    private static string Hash(string pass)
    {
        using SHA256 sha256 = SHA256.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(pass);
        byte[] hash = sha256.ComputeHash(bytes);
        pass = Convert.ToHexString(hash);
        return pass;
    }
}
