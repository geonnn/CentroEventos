namespace CentroEventos.Aplicacion.Reserva;

public class EliminarReservaUseCase(IRepositorioReserva repoReserva) {
    
    public List<Reserva> Ejecutar() {

        return repoReserva.EliminarReserva();
    }
}