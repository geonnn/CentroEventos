namespace CentroEventos.Aplicacion.UseCases;
using Entidades;
using Excepciones;
using Interfaces;
using Validadores;



public class ModificarReservaUseCase(IRepositorioReserva repoReserva, ReservaValidador validador, IServicioAutorizacion autorizador)
{
    public void Ejecutar(Reserva r, List<Permiso> permisos)
    {
        if (!autorizador.PoseeElPermiso(permisos, Permiso.ReservaModificacion))
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