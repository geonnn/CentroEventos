namespace CentroEventos.Aplicacion.UseCases;

using Entidades;
using Excepciones;
using Interfaces;
using Validadores;

public class BajaEventoDeportivoUseCase(IRepositorioEventoDeportivo repo, EventoDeportivoValidador validador, IServicioAutorizacion autorizador)
{
    public void Ejecutar(int id, List<Permiso> permisos)
    {
        if (!autorizador.PoseeElPermiso(permisos, Permiso.EventoBaja))
            throw new FalloAutorizacionException("No tiene permiso para eliminar un evento deportivo.");

        if (!repo.EventoExiste(id))
            throw new EntidadNotFoundException($"Evento ID {id} no encontrado.");
        
        if (validador.TieneReserva(id))
            throw new OperacionInvalidaException($"No se puede eliminar el evento ID {id} porque tiene reservas.");

        repo.BajaEventoDeportivo(id);
    }
}