using System.Text;

namespace CentroEventos.Aplicacion.Persona;

public class PersonaValidador(IRepositorioPersona repo)
{
    public bool ValidarConstruccion(Persona p, out string mensajeError)
    {
        StringBuilder mensaje = new StringBuilder("");
        
        if (string.IsNullOrWhiteSpace(p.Nombre))
        {
            mensaje.Append("El nombre no puede estar vacío o ser null.\n");
        }

        if (string.IsNullOrWhiteSpace(p.Apellido))
        {
            mensaje.Append("El apellido no puede estar vacío o ser null.\n");
        }

        if (string.IsNullOrWhiteSpace(p.Dni))
        {
            mensaje.Append("El DNI no puede estar vacío o ser null.\n");
        }

        if (string.IsNullOrWhiteSpace(p.Email))
        {
            mensaje.Append("El email no puede estar vacío o ser null.\n");
        }

        mensajeError = mensaje.ToString();
        return mensajeError == "";
    }

    public bool ValidarDuplicado(Persona p, out string mensajeError)
    {
        StringBuilder mensaje = new StringBuilder("");

        if (repo.DniExiste(p.Dni))
        {
            mensaje.Append("El DNI ya existe");
        }

        if (repo.EmailExiste(p.Email))
        {
            mensaje.Append("El Email ya existe");
        }

        mensajeError = mensaje.ToString();
        return mensajeError == "";
    }

    public bool ValidarDuplicadoModificar(Persona p, out string mensajeError)
    {
        // en este punto la persona existe y la modificación está bien construida:
        // pedir lista de personas y borrar la que se quiere modificar.
        // comparar contra esa lista.
        // si no hay duplicado enviar persona a modificar.
        // modificar se encarga de insertar la persona modificada en el lugar correcto. 
        
        StringBuilder mensaje = new StringBuilder("");
        var lista = repo.ListarPersonas();
        lista.RemoveAt(lista.FindIndex(pe => pe.Id == p.Id));

        if (lista.Exists(pe => pe.Dni == p.Dni))
            mensaje.Append("El DNI ya existe.");

        if (lista.Exists(pe => pe.Email == p.Email))
            mensaje.Append("El Email ya existe.");

        mensajeError = mensaje.ToString();
        return mensajeError == "";
        
    }
}
