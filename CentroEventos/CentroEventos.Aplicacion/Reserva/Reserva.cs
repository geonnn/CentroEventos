namespace CentroEventos.Aplicacion.Reserva;

public class Reserva
{
    public int Id {get;}
    public int PersonaId {get; private set;}
    public int EventoDeportivoId {get; private set;}
    public DateTime FechaAltaReserva {get; private set;}
    public EstadoAsistencia Estado {get; private set;}

    public string ToStringParaTXT(int id)
    {
        return $"{id}\n" +
               $"{PersonaId}\n" +
               $"{EventoDeportivoId}\n" +
               $"{FechaAltaReserva:dd/MM/yyyy}\n" +
               $"{Estado}";
    }
}

public enum EstadoAsistencia {Pendiente, Presente, Ausente};