namespace CentroEventos.Aplicacion.EventoDeportivo;

using CentroEventos.Aplicacion.Reserva;


public class ListarEventosConCupoDisponibleUseCase(IRepositorioEventoDeportivo repoEventoDeportivo, IRepositorioReserva repoReserva)
{
    public List<EventoDeportivo> Ejecutar()
    {
        List<EventoDeportivo> eventosFuturos = repoEventoDeportivo.ListarEventoDeportivoFuturo(DateTime.Now);
        List<Reserva> reservas = repoReserva.ListarReservas();
        foreach (EventoDeportivo e in eventosFuturos)
        {
            
            int contador = 0;
            foreach (Reserva r in reservas)
            {
                if (r.EventoDeportivoId == e.Id)
                    contador++;
            }
            if (contador < e.CupoMaximo)
                eventosFuturos.Add(e);
        }

        return eventosFuturos;
    }
}