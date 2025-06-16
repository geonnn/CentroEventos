namespace CentroEventos.Aplicacion.UseCases;

using Entidades;
using Excepciones;
using Interfaces;
using Validadores;

public class AltaReservaUseCase(IRepositorioReserva repoReserva, ReservaValidador validador, IServicioAutorizacion autorizador) {
    
    public void Ejecutar(Reserva reserva, List<Permiso> permisos) 
    {
        if (!autorizador.PoseeElPermiso(permisos, Permiso.ReservaAlta))
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

        repoReserva.AltaReserva(reserva);
    }
}