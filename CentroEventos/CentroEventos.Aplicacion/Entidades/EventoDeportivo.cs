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

    // Constructor con todos los parámetros.
    public EventoDeportivo(int id, string nom, string desc, DateTime fechaInicio, double duracion, int cupoMax, int respId)
    {
        Id = id;
        Nombre = nom;
        Descripcion = desc;
        FechaHoraInicio = fechaInicio;
        DuracionHoras = duracion;
        CupoMaximo = cupoMax;
        ResponsableId = respId;
    }

    // Constructor sin ID.
    public EventoDeportivo(string nom, string desc, DateTime fechaInicio, double duracion, int cupoMax, int respId)
        : this(0, nom, desc, fechaInicio, duracion, cupoMax, respId)
    { }

    public override string ToString()
    {
        return $"EventoDeportivo [Id: {Id}, Nombre: {Nombre}, Descripcion: {Descripcion}, FechaHoraInicio: {FechaHoraInicio}, DuracionHoras: {DuracionHoras}, CupoMaximo: {CupoMaximo}, ResponsableId: {ResponsableId}]";
    }

    public string ToStringParaTXT()
    {
        return Id + "\n" +
                Nombre + "\n" +
                Descripcion + "\n" +
                FechaHoraInicio + "\n" +
                DuracionHoras + "\n" +
                CupoMaximo + "\n" +
                ResponsableId;
    }
    /// <summary>
    /// Genera un string apto para escribir en un archivo .txt los datos de un evento.
    /// </summary>
    /// <param name="id">ID que se le asignará al evento. Manejado por el repositorio.</param>
    /// <returns>String para escribir en archivo .txt</returns>
    public string ToStringParaTXT(int id)
    {
        return id + "\n" +
                Nombre + "\n" +
                Descripcion + "\n" +
                FechaHoraInicio + "\n" +
                DuracionHoras + "\n" +
                CupoMaximo + "\n" +
                ResponsableId;
    }
}
    