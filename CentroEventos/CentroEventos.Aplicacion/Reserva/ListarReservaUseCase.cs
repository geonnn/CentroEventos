namespace CentroEventos.Aplicacion.Reserva;

public class ListarReservaUseCase(IRepositorioReserva repoReserva) {
    
    public List<Reserva> Ejecutar() {

        return repoReserva.ListarReservas();
    }
}