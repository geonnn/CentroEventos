using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Clases;

namespace CentroEventos.Aplicacion.EventoDeportivo;

public class AgregarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo, EventoDeportivoValidador validador, IServicioAutorizacion autorizador)
{
    public void Ejecutar(EventoDeportivo evento, int idUsuario)
    {
        if (!autorizador.PoseeElPermiso(idUsuario, Permiso.EventoAlta))
            throw new FalloAutorizacionException("No tiene permiso para añadir un evento deportivo.");

        if (!validador.ValidarConstruccion(evento, out string mensajeError))
            throw new ValidacionException(mensajeError);

        if (!validador.ValidarResponsable(evento.ResponsableId))
            throw new EntidadNotFoundException($"El responsable {evento.ResponsableId} no existe.");

        repo.AgregarEventoDeportivo(evento);               
    }
}