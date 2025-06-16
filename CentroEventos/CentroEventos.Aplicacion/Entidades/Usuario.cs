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

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(pw);
            byte[] hash = sha256.ComputeHash(bytes);
            pw = Convert.ToHexString(hash);
        }
        Password = pw;
    }
    public void AgregarPermiso(List<Permiso> permisos)
    {
        Permisos = permisos;
    }
}
