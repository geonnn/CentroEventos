namespace CentroEventos.Aplicacion.UseCases;
using Entidades;
using Interfaces;

public class ListarEventosConCupoDisponibleUseCase(IRepositorioEventoDeportivo repoEventoDeportivo, IRepositorioReserva repoReserva)
{
    public List<EventoDeportivo> Ejecutar()
    {
        List<EventoDeportivo> eventosFuturos = repoEventoDeportivo.ListarEventoDeportivoFuturo(DateTime.Now);
        var eventosConCupo = new List<EventoDeportivo>();
        foreach (EventoDeportivo e in eventosFuturos)
        {
            if (repoReserva.EventoTieneCupo(e.Id, e.CupoMaximo))
                eventosConCupo.Add(e);
        }

        return eventosConCupo;
    }
}