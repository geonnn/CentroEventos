namespace CentroEventos.Aplicacion.Reserva;

using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Clases;

public class AgregarReservaUseCase(IRepositorioReserva repoReserva, ReservaValidador validador, IServicioAutorizacion autorizador) {
    
    public void Ejecutar(Reserva reserva, int idUsuario) 
    {
        if (!autorizador.PoseeElPermiso(idUsuario, Permiso.ReservaAlta))
            throw new FalloAutorizacionException("No tiene permiso para añadir una reserva.");
        {
            if (!validador.ValidarConstruccion(reserva, out string mensajeError))
                throw new ValidacionException(mensajeError);
        }
        {
            if (!validador.ValidarDuplicado(reserva, out string mensajeError))
                throw new DuplicadoException(mensajeError);
        }
        {
            if (!validador.ValidarCupo(reserva, out string mensajeError))
                throw new CupoExcedidoException(mensajeError);
        }

        repoReserva.AgregarReserva(reserva);
    }
}