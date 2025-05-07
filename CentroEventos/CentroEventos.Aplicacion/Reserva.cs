namespace CentroEventos.Aplicacion;

public class Reserva
{
    public int Id {get;}
    public int PersonaId {get;}
    public int EventoDeportivoId {get;}
    public DateTime FechaAltaReserva {get;}
    public EstadoAsistencia Estado {get; }
}

public enum EstadoAsistencia {Pendiente, Presente, Ausente};