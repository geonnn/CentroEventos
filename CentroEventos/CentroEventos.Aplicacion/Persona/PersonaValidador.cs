using System.Text;

namespace CentroEventos.Aplicacion.Persona;

public class PersonaValidador
{
    public bool Validar(Persona p)
    {

        string mensajeError = "";
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
        if (mensaje.Equals(""))
        {
            throw new ValidacionException(mensaje.ToString());
        }
        //if (repo.DniExiste(persona.Dni))
        //    mensaje.Append("El DNI ya existe");
//
        //if (repo.EmailExiste(persona.Email))
        //    mensaje.Append("El Email ya existe");

        if (mensaje.Equals(""))
        {
            throw new DuplicadoException(mensajeError);
        }

        return true;
    }
}
