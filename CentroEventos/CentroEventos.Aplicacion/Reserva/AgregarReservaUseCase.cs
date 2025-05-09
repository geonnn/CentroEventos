namespace CentroEventos.Aplicacion.Reserva;

public class AgregarReservaUseCase(IRepositorioReserva repoReserva) {
    
    public List<Reserva> Ejecutar() {

        return repoReserva.AgregarReserva();
    }
}