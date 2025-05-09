namespace CentroEventos.Aplicacion.EventoDeportivo;

public class EventoDeportivo
{
    public int Id {get;}
    public string Nombre {get;}
    public string Descripcion {get;}
    public DateTime FechaHoraInicio {get;}
    public double DuracionHoras {get;}
    public int CupoMaximo {get;}
    public int ResponsableId {get;}

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