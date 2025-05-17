namespace CentroEventos.Aplicacion.EventoDeportivo;
using System.Text;
using CentroEventos.Aplicacion.Persona;
using CentroEventos.Aplicacion.Reserva;

public class EventoDeportivoValidador(IRepositorioPersona repoP, IRepositorioReserva repoR)
{
    public bool ValidarConstruccion(EventoDeportivo e, out string mensajeError)
    {

        StringBuilder mensaje = new StringBuilder("");

        if (string.IsNullOrWhiteSpace(e.Nombre))
        {
            mensaje.Append("El nombre no puede estar vacío o ser null.\n");
        }

        if (string.IsNullOrWhiteSpace(e.Descripcion))
        {
            mensaje.Append("La descripción no puede estar vacía o ser null.\n");
        }

        if (e.FechaHoraInicio < DateTime.Now)
        {
            mensaje.Append("La hora de inicio debe ser posterior o igual a la hora actual.\n");
        }

        if (e.CupoMaximo <= 0)
        {
            mensaje.Append("El cupo máximo debe ser mayor que cero.\n");
        }

        if (e.DuracionHoras <= 0)
        {
            mensaje.Append("La duración debe del evento ser mayor a 0.\n");
        }

        mensajeError = mensaje.ToString();
        return mensajeError == "";
    }

    public bool ValidarResponsable(int id)
        => repoP.PersonaExiste(id);

    public bool TieneReserva(int id)
        => repoR.EventoTieneReserva(id);
}
