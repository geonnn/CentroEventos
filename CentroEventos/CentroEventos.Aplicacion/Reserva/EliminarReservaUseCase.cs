using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Clases;


namespace CentroEventos.Aplicacion.Reserva;

public class EliminarReservaUseCase(IRepositorioReserva repoReserva, IServicioAutorizacion autorizador) {
    
    public void Ejecutar(int id, int idUsuario) {
        if (!autorizador.PoseeElPermiso(idUsuario, Permiso.ReservaBaja))
            throw new FalloAutorizacionException("No tiene permiso para añadir una persona.");
        //TODO: Validaciones
        repoReserva.EliminarReserva(id);
    }
}