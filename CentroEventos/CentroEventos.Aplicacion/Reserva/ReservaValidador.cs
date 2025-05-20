namespace CentroEventos.Aplicacion.Reserva;

using System.Text;
using CentroEventos.Aplicacion.EventoDeportivo;
using CentroEventos.Aplicacion.Persona;

public class ReservaValidador(IRepositorioPersona repoP, IRepositorioEventoDeportivo repoE, IRepositorioReserva repoR)
{

    public bool ValidarConstruccion(Reserva r, out string mensajeError)
    {
        StringBuilder mensaje = new StringBuilder("");

        if (!repoP.PersonaExiste(r.PersonaId))
        {
            mensaje.Append($"La persona ID {r.PersonaId} no existe.\n");
        }

        if (!repoE.EventoExiste(r.EventoDeportivoId))
        {
            mensaje.Append($"El evento ID {r.EventoDeportivoId} no existe.\n");
        }

        mensajeError = mensaje.ToString();
        return mensajeError == "";
    }

    public bool ValidarDuplicado(Reserva r, out string mensajeError)
    {
        mensajeError = "";

        if (repoR.PersonaReservoEvento(r.PersonaId, r.EventoDeportivoId))
            mensajeError = $"La persona ID {r.PersonaId} ya se encuentra registrada para el evento ID {r.EventoDeportivoId}.";

        return mensajeError == "";
    }

    public bool ValidarCupo(Reserva r, out string mensajeError)
    {
        mensajeError = "";

        if (/* TODO: consultar cupo. */)
            mensajeError = $"El evento ID {r.EventoDeportivoId} ya ha alcanzado su cupo máximo.";

        return mensajeError == "";

    }

}
