using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Clases;

namespace CentroEventos.Aplicacion.Reserva;

public class ModificarReservaUseCase(IRepositorioReserva repoReserva, IServicioAutorizacion autorizador) {

    public void Ejecutar(Reserva r, int idUsuario) {
        if (!autorizador.PoseeElPermiso(idUsuario, Permiso.ReservaModificacion))
            throw new FalloAutorizacionException("No tiene permiso para añadir una persona.");

        repoReserva.ModificarReserva(r);

    }
}