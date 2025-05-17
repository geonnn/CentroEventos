using CentroEventos.Aplicacion.Reserva;

namespace CentroEventos.Aplicacion.EventoDeportivo;

public class ListarEventosConCupoDisponibleUseCase(IRepositorioEventoDeportivo repoEventoDeportivo, IRepositorioReserva repoReserva)
{
    public List<EventoDeportivo> Ejecutar()
    {
        List<EventoDeportivo> EventosFuturos = repoEventoDeportivo.ListarEventoDeportivoFuturo(DateTime.Now);
        List<Reserva.Reserva> reservas = repoReserva.ListarReservas();
        foreach (EventoDeportivo e in EventosFuturos)
        {
            
            int contador = 0;
            foreach (Reserva.Reserva r in reservas)
            {
                if (r.EventoDeportivoId == e.Id)
                    contador++;
            }
            if (contador < e.CupoMaximo)
                EventosFuturos.Add(e);
        }

        return EventosFuturos;
    }
}