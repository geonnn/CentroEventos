namespace CentroEventos.Aplicacion.Reserva;

public class Reserva
{
    public int Id {get; private set;}
    public int PersonaId {get; private set;}
    public int EventoDeportivoId {get; private set;}
    public DateTime FechaAltaReserva {get; private set;}
    public EstadoAsistencia Estado {get; private set;}

    // Constructor con todos los parámetros.
    public Reserva(int id, int personaId, int eventoDeportivoId, DateTime fechaAltaReserva, EstadoAsistencia estado)
    {
        Id = id;
        PersonaId = personaId;
        EventoDeportivoId = eventoDeportivoId;
        FechaAltaReserva = fechaAltaReserva;
        Estado = estado;
    }

    // Constructor sin ID.
    public Reserva(int personaId, int eventoDeportivoId, DateTime fechaAltaReserva, EstadoAsistencia estado)
        : this(0, personaId, eventoDeportivoId, fechaAltaReserva, estado)
    { }

    public string ToStringParaTXT(int id)
    {
        return id + "\n" +
               PersonaId + "\n" +
               EventoDeportivoId + "\n" +
               $"{FechaAltaReserva:dd/MM/yyyy}" + "\n" +
               Estado;
    }
    public string ToStringParaTXT()
    {
        return Id + "\n" +
               PersonaId + "\n" +
               EventoDeportivoId + "\n" +
               $"{FechaAltaReserva:dd/MM/yyyy}" + "\n" +
               Estado;
    }
}

public enum EstadoAsistencia {Pendiente, Presente, Ausente};