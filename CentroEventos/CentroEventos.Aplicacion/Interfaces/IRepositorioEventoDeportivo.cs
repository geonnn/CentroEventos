namespace CentroEventos.Aplicacion.Interfaces;
using Entidades;

public interface IRepositorioEventoDeportivo
{
    void AgregarEventoDeportivo(EventoDeportivo evento);
    void EliminarEventoDeportivo(int id);
    void ModificarEventoDeportivo(EventoDeportivo evento);
    List<EventoDeportivo> ListarEventoDeportivo();
    List<EventoDeportivo> ListarEventoDeportivoFuturo(DateTime fecha);
    List<EventoDeportivo> ListarEventoDeportivoPasado(DateTime fecha);
    bool EventoExiste(int id);
    bool Finalizo(int id);
    bool PersonaEsResponsable(int id);
    int GetCupoMax(int id);
}
