namespace CentroEventos.Aplicacion.Reserva;

public class AgregarReservaUseCase(IRepositorioReserva repoReserva) {
    
    public void Ejecutar(Reserva r) {
        repoReserva.AgregarReserva(r);
    }
}