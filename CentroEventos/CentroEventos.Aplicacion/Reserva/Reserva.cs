namespace CentroEventos.Aplicacion.Reserva;

public class Reserva
{
    public int Id {get;}
    public int PersonaId {get;}
    public int EventoDeportivoId {get;}
    public DateTime FechaAltaReserva {get;}
    public EstadoAsistencia Estado {get; }

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