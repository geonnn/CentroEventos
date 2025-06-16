namespace CentroEventos.Aplicacion.UseCases;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using System.Security.Cryptography;
using System.Text;

public class LoginUseCase(IRepositorioUsuario repoU, Sesion sesion) {
    public bool Ejecutar(string email, string pass) {

        if (!repoU.UsuarioExiste(email)) 
        {
            
            return false;
            throw new Exception("El usuario no existe.");

        } 
        
        Usuario u = repoU.ConsultaUsuario(email);
        
        using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(pass);
                byte[] hash = sha256.ComputeHash(bytes);
                pass = Convert.ToHexString(hash);
            }
        
        if (!u.Password.Equals(pass)) 
        {
            return false;
            throw new Exception("Contraseña incorrecta.");
        }
        sesion.IniciarSesion(u);
        return true;
    }
    
}