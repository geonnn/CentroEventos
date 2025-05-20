namespace CentroEventos.Aplicacion.Reserva;

using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Clases;

public class EliminarReservaUseCase(IRepositorioReserva repoReserva, IServicioAutorizacion autorizador) {
    
    public void Ejecutar(int id, int idUsuario) {
        if (!autorizador.PoseeElPermiso(idUsuario, Permiso.ReservaBaja))
            throw new FalloAutorizacionException("No tiene permiso para eliminar una reserva.");
        
        if (!repoReserva.ReservaExiste(id))
            throw new EntidadNotFoundException($"La reserva ID {id} no existe.");

        repoReserva.EliminarReserva(id);
    }
}