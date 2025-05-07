namespace CentroEventos.Aplicacion;

public class EventoDeportivo
{
    public int Id {get;}
    public string Nombre {get;}
    public string Descripcion {get;}
    public DateTime FechaHoraInicio {get;}
    public double DuracionHoras {get;}
    public int CupoMaximo {get;}
    public int ResponsableId {get;}
}