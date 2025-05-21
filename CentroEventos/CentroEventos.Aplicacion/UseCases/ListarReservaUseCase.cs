namespace CentroEventos.Aplicacion.UseCases;

using Entidades;
using Interfaces;

public class ListarReservaUseCase(IRepositorioReserva repoReserva)
{
    public List<Reserva> Ejecutar()
    {
        return repoReserva.ListarReservas();
    }
}