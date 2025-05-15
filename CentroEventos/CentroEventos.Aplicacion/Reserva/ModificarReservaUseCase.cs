namespace CentroEventos.Aplicacion.Reserva;

public class ModificarReservaUseCase(IRepositorioReserva repoReserva) {

    public void Ejecutar(Reserva r) {

        repoReserva.ModificarReserva(r);

    }
}