using CentroEventos.Aplicacion.Reserva;

namespace CentroEventos.Aplicacion.EventoDeportivo;

public class ListarEventosConCupoDisponibleUseCase(IRepositorioEventoDeportivo repoEventoDeportivo, IRepositorioReserva repoReserva)
{
    public void Ejecutar()
    {
        repoEventoDeportivo.ListarEventosConCupoDisponible(repoReserva);
    }
}