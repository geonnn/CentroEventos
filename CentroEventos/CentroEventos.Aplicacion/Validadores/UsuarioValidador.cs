namespace CentroEventos.Aplicacion.Validadores;
using System.Text;
using Entidades;
using Interfaces;


public class UsuarioValidador(IRepositorioUsuario repoU)
{
    public bool ValidarConstruccion(Usuario u, out string mensajeError)
    {
        StringBuilder mensaje = new StringBuilder("");

        if (string.IsNullOrWhiteSpace(u.Nombre))
        {
            mensaje.Append("El nombre no puede estar vacío o ser null.\n");
        }

        if (string.IsNullOrWhiteSpace(u.Apellido))
        {
            mensaje.Append("El apellido no puede estar vacío o ser null.\n");
        }

        if (string.IsNullOrWhiteSpace(u.Email))
        {
            mensaje.Append("El email no puede estar vacío o ser null.\n");
        }

        if (string.IsNullOrWhiteSpace(u.Password))
        {
            mensaje.Append("La constraseña no puede estar vacía o ser null.\n");
        }
        mensajeError = mensaje.ToString();
        return mensajeError == "";
    }

    public bool ValidarDuplicado(Usuario u, out string mensajeError)
    {
        StringBuilder mensaje = new StringBuilder("");


        if (repoU.UsuarioExiste(u.Email))
        {
            mensaje.Append($"El Email {u.Email} ya existe.");
        }

        mensajeError = mensaje.ToString();
        return mensajeError == "";
    }

    public bool ValidarDuplicadoModificar(Usuario u, out string mensajeError)
    {
        // en este punto la Usuario existe y la modificación está bien construida:
        // pedir lista de Usuarios y borrar la que se quiere modificar.
        // comparar contra esa lista.
        // si no hay duplicado enviar Usuario a modificar.
        // modificar se encarga de insertar la Usuario modificada en el lugar correcto. 

        StringBuilder mensaje = new StringBuilder("");
        var lista = repoU.ListarUsuarios().Where(us => us.Id != u.Id);

        if (lista.FirstOrDefault(us => us.Email == u.Email) != null)
            mensaje.Append($"El Email {u.Email} ya existe.");

        mensajeError = mensaje.ToString();
        return mensajeError == "";
    }
}
