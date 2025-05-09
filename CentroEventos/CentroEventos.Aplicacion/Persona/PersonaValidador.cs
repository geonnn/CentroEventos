using System.Text;

namespace CentroEventos.Aplicacion.Persona;

public class PersonaValidador
{
    public bool Validar(Persona p, out string mensajeError)
    {

        mensajeError = "";
        StringBuilder mensaje = new StringBuilder("");

        if (string.IsNullOrWhiteSpace(p.Nombre)) {
            mensaje.Append("El nombre no puede estar vacío o ser null.\n");
        }

        if (string.IsNullOrWhiteSpace(p.Apellido)) {
            mensaje.Append("El apellido no puede estar vacío o ser null.\n");
        }

        if (string.IsNullOrWhiteSpace(p.Dni)) {
            mensaje.Append("El DNI no puede estar vacío o ser null.\n");
        }
        else if (/* TO-DO comprobar que no exista el dni.*/) {
            mensaje.Append("El DNI ingresado ya existe.");
        }

        if (string.IsNullOrWhiteSpace(p.Email)) {
            mensaje.Append("El email no puede estar vacío o ser null.\n");
        }
        else if (/* TO-DO comprobar que no exista el email. */) {
            mensaje.Append("El email ingresado ya existe.");
        }

        mensajeError = mensaje.ToString();
        return (mensajeError == "");
    }
}
