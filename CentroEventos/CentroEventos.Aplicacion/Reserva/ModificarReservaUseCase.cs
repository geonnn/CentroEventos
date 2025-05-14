namespace CentroEventos.Aplicacion.Reserva;

public class ModificarReservaUseCase(IRepositorioReserva repoReserva) {

    public void Ejecutar(int id) {

        repoReserva.ModificarReserva(id);

    }
}