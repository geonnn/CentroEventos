namespace CentroEventos.Aplicacion.Entidades;

public class Reserva
{
    public int Id {get; private set;}
    public int PersonaId {get; private set;}
    public int EventoDeportivoId {get; private set;}
    public DateTime FechaAltaReserva {get; private set;}
    public EstadoAsistencia Estado {get; private set;}

    // Constructor vacío para Entity Framework
    #nullable disable
    protected Reserva() { }
    #nullable enable

    public Reserva(int personaId, int eventoDeportivoId, DateTime fechaAltaReserva, EstadoAsistencia estado)
    {
        PersonaId = personaId;
        EventoDeportivoId = eventoDeportivoId;
        FechaAltaReserva = fechaAltaReserva;
        Estado = estado;
    }

    public void Actualizar(Reserva r)
    {
        this.PersonaId = r.PersonaId;
        this.EventoDeportivoId = r.EventoDeportivoId;
        this.FechaAltaReserva = r.FechaAltaReserva;
        this.Estado = r.Estado;
    }

    public override string ToString()
    {
        return $"Reserva [Id: {Id}, PersonaId: {PersonaId}, EventoDeportivoId: {EventoDeportivoId}, FechaAltaReserva: {FechaAltaReserva:dd/MM/yyyy}, Estado: {Estado}]";
    }
}

public enum EstadoAsistencia {Pendiente, Presente, Ausente};