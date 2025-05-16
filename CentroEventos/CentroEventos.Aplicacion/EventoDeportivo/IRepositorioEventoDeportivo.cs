namespace CentroEventos.Aplicacion.EventoDeportivo;
using CentroEventos.Aplicacion.Reserva;

public interface IRepositorioEventoDeportivo
{
    void AgregarEventoDeportivo(EventoDeportivo evento);
    void EliminarEventoDeportivo(int id);
    void ModificarEventoDeportivo(int id);
    List<EventoDeportivo> ListarEventoDeportivo();
    List<EventoDeportivo> ListarEventoDeportivo(DateTime fecha);
    public bool EventoExiste(int id);
    public bool Finalizo(int id);
    public List<EventoDeportivo> ListarEventosConCupoDisponible(IRepositorioReserva repoReserva);
}
