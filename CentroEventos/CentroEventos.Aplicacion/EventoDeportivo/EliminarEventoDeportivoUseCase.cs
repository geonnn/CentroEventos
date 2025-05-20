namespace CentroEventos.Aplicacion.EventoDeportivo;

using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Clases;

public class EliminarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo, EventoDeportivoValidador validador, IServicioAutorizacion autorizador)
{
    public void Ejecutar(int id, int idUsuario)
    {
        if (!autorizador.PoseeElPermiso(idUsuario, Permiso.EventoBaja))
            throw new FalloAutorizacionException("No tiene permiso para eliminar un evento deportivo.");

        if (!repo.EventoExiste(id))
            throw new EntidadNotFoundException($"Evento ID {id} no encontrado.");
        
        if (validador.TieneReserva(id))
            throw new OperacionInvalidaException($"No se puede eliminar el evento ID {id} porque tiene reservas.");

        repo.EliminarEventoDeportivo(id);
    }
}