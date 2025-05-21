namespace CentroEventos.Aplicacion.UseCases;

using Entidades;
using Excepciones;
using Interfaces;
using Validadores;

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