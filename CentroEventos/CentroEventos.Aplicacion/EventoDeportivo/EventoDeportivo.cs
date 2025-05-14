namespace CentroEventos.Aplicacion.EventoDeportivo;

public class EventoDeportivo
{
    public int Id {get; private set;}
    public string Nombre {get; private set;}
    public string Descripcion {get; private set;}
    public DateTime FechaHoraInicio {get; private set; }
    public double DuracionHoras {get; private set; }
    public int CupoMaximo {get; private set; }
    public int ResponsableId {get; private set;}

    public EventoDeportivo(string nom, string desc, DateTime fechaInicio, double duracion, int cupoMax, int respId)
    {
        Nombre = nom;
        Descripcion = desc;
        FechaHoraInicio = fechaInicio;
        DuracionHoras = duracion;
        CupoMaximo = cupoMax;
        ResponsableId = respId;
    }

    public string ToStringParaTXT(int id)
    {
        return  id + "\n" +
                Nombre +"\n" +
                Descripcion + "\n" +
                FechaHoraInicio + "\n" +
                DuracionHoras + "\n" +
                CupoMaximo + "\n" +
                ResponsableId;
    }
}