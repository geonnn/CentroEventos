namespace CentroEventos.Aplicacion.Reserva;

public class ModificarReservaUseCase(IRepositorioReserva repoReserva) {

    public List<Reserva> Ejecutar() {

        return repoReserva.ModificarReserva();

    }
}