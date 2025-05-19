using System.Text;
using CentroEventos.Aplicacion.EventoDeportivo;
using CentroEventos.Aplicacion.Persona;

namespace CentroEventos.Aplicacion.Reserva;

public class ReservaValidador(IRepositorioPersona repoP, IRepositorioEventoDeportivo repoE)
{

    public bool Validar(Reserva r, out string mensajeError)
    {

        StringBuilder mensaje = new StringBuilder("");

        if (!repoP.PersonaExiste(r.PersonaId)) {
            mensaje.Append($"La persona ID {r.PersonaId} no existe.\n");
        }

        if (!repoE.EventoExiste(r.EventoDeportivoId)) {
            mensaje.Append($"El evento ID {r.EventoDeportivoId} no existe.\n");
        }

        // if (/* TO-DO consultar que la persona no haya reservado para el mismo evento. */) {
        //     mensaje.Append("La persona ingresada ya se encuentra registrada para este evento.\n");
        // }

        // if (/* TO-DO consultar si hay cupo para el evento.*/) {
        //     mensaje.Append("El evento está lleno.\n");
        // }

        mensajeError = mensaje.ToString();
        return mensajeError == "";
    }

}
