namespace CentroEventos.Aplicacion.Reserva;

public class AgregarReservaUseCase(IRepositorioReserva repoReserva, ReservaValidador validador) {
    
    public void Ejecutar(Reserva r) {
        if (!validador.Validar(r, out string mensajeError))
            throw new Exception(mensajeError);

        repoReserva.AgregarReserva(r);
    }
}