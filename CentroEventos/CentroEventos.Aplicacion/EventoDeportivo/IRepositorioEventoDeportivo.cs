namespace CentroEventos.Aplicacion.EventoDeportivo;
using CentroEventos.Aplicacion.Reserva;

public interface IRepositorioEventoDeportivo
{
    void AgregarEventoDeportivo(EventoDeportivo evento);
    void EliminarEventoDeportivo(int id);
    void ModificarEventoDeportivo(EventoDeportivo evento);
    List<EventoDeportivo> ListarEventoDeportivo();
    List<EventoDeportivo> ListarEventoDeportivoFuturo(DateTime fecha);
    List<EventoDeportivo> ListarEventoDeportivoPasado(DateTime fecha);
    public bool EventoExiste(int id);
    public bool Finalizo(int id);
}
