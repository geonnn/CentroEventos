namespace CentroEventos.Aplicacion.UseCases;

using Interfaces;
using Entidades;
using Excepciones;

public class BajaReservaUseCase(IRepositorioReserva repoReserva, IServicioAutorizacion autorizador) {
    
    public void Ejecutar(int id, List<Permiso> permisos) {
        if (!autorizador.PoseeElPermiso(permisos, Permiso.ReservaBaja))
            throw new FalloAutorizacionException("No tiene permiso para eliminar una reserva.");
        
        if (!repoReserva.ReservaExiste(id))
            throw new EntidadNotFoundException($"La reserva ID {id} no existe.");

        repoReserva.BajaReserva(id);
    }
}