namespace CentroEventos.Aplicacion.Entidades;

public class EventoDeportivo
{
    public int Id {get; private set;}
    public string Nombre {get; private set;}
    public string Descripcion {get; private set;}
    public DateTime FechaHoraInicio {get; private set; }
    public double DuracionHoras {get; private set; }
    public int CupoMaximo {get; private set; }
    public int ResponsableId {get; private set;}
    public List<Reserva>? Reservas { get; private set; }= new();

    // Constructor vacío para Entity Framework
    #nullable disable
    protected EventoDeportivo() { }
    #nullable enable

    public EventoDeportivo(string nom, string desc, DateTime fechaInicio, double duracion, int cupoMax, int respId)
    {
        Nombre = nom;
        Descripcion = desc;
        FechaHoraInicio = fechaInicio;
        DuracionHoras = duracion;
        CupoMaximo = cupoMax;
        ResponsableId = respId;
    }

    public void Actualizar(EventoDeportivo e)
    {
        this.Nombre = e.Nombre;
        this.Descripcion = e.Descripcion;
        this.FechaHoraInicio = e.FechaHoraInicio;
        this.DuracionHoras = e.DuracionHoras;
        this.CupoMaximo = e.CupoMaximo;
        this.ResponsableId = e.ResponsableId;
    }

    public override string ToString()
    {
        return $"EventoDeportivo [Id: {Id}, Nombre: {Nombre}, Descripcion: {Descripcion}, FechaHoraInicio: {FechaHoraInicio}, DuracionHoras: {DuracionHoras}, CupoMaximo: {CupoMaximo}, ResponsableId: {ResponsableId}]";
    }
}
    