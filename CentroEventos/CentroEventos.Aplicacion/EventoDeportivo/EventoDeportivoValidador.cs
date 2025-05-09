using System.Text;
namespace CentroEventos.Aplicacion.EventoDeportivo;

public class EventoDeportivoValidador
{
    public bool Validar(EventoDeportivo e, out string mensajeError)
    {

        mensajeError = "";
        StringBuilder mensaje = new StringBuilder("");

        if (string.IsNullOrWhiteSpace(e.Nombre)) {
            mensaje.Append("El nombre no puede estar vacío o ser null.\n");
        }

        if (string.IsNullOrWhiteSpace(e.Descripcion)) {
            mensaje.Append("La descripción no puede estar vacía o ser null.\n");
        }

        if (e.FechaHoraInicio < DateTime.Now) {
            mensaje.Append("La hora de inicio debe ser posterior o igual a la hora actual.\n"); 
        }

        if (e.CupoMaximo <= 0) {
            mensaje.Append("El cupo máximo debe ser mayor que cero.\n");
        }

        if (e.DuracionHoras <= 0) {
            mensaje.Append("La duración debe del evento ser mayor a 0.\n");
        }

        if (/* TO-DO comprobar que el e.ResponsableId exista*/) {
            mensaje.Append("La persona responsable no existe.\n");
        }

        mensajeError = mensaje.ToString();
        return (mensajeError == "");
    }
}
