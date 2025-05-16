using System.Text;
using CentroEventos.Aplicacion.EventoDeportivo;
using CentroEventos.Aplicacion.Persona;

namespace CentroEventos.Aplicacion.Reserva;

public class ReservaValidador
{
    readonly IRepositorioPersona _repoPersona;
    readonly IRepositorioEventoDeportivo _repoEventos;

    public ReservaValidador(IRepositorioPersona repoPersona, IRepositorioEventoDeportivo repoEventos)
    {
        _repoPersona = repoPersona;
        _repoEventos = repoEventos;
    }

    public bool Validar(Reserva r, out string mensajeError)
    {

        mensajeError = "";
        StringBuilder mensaje = new StringBuilder("");

        // if (/* TO-DO consultar si r.PersonaId existe.*/) {
        //     mensaje.Append("El id de persona ingresado no existe.\n");
        // }

        // if (/* TO-DO consultar si r.EventoDeportivoId existe.*/) {
        //     mensaje.Append("El id del evento ingresado no existe.\n");
        // }

        // if (/* TO-DO consultar que la persona no haya reservado para el mismo evento. */) {
        //     mensaje.Append("La persona ingresada ya se encuentra registrada para este evento.\n");
        // }

        // if (/* TO-DO consultar si hay cupo para el evento.*/) {
        //     mensaje.Append("El evento está lleno.\n");
        // }

        mensajeError = mensaje.ToString();
        return (mensajeError == "");
    }

}
