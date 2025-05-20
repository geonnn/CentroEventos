using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Clases;

namespace CentroEventos.Aplicacion.Reserva;

public class ModificarReservaUseCase(IRepositorioReserva repoReserva, ReservaValidador validador, IServicioAutorizacion autorizador)
{
    public void Ejecutar(Reserva r, int idUsuario)
    {
        if (!autorizador.PoseeElPermiso(idUsuario, Permiso.ReservaModificacion))
            throw new FalloAutorizacionException("No tiene permiso para modificar una reserva.");

        if (!repoReserva.ReservaExiste(r.Id))
            throw new EntidadNotFoundException($"La reserva ID {r.Id} no existe.");
        {
            if (!validador.ValidarConstruccion(r, out string mensajeError))
                throw new ValidacionException(mensajeError);
        }
        {
            if (!validador.ValidarDuplicadoModificar(r, out string mensajeError))
                throw new DuplicadoException(mensajeError);
        }
        repoReserva.ModificarReserva(r);
    }
}