namespace CentroEventos.Aplicacion.Reserva;

public class EliminarReservaUseCase(IRepositorioReserva repoReserva) {
    
    public void Ejecutar(int id) {

        repoReserva.EliminarReserva(id);
    }
}