namespace CentroEventos.Aplicacion.UseCases;
using Interfaces;
using Entidades;
using Validadores;
using Excepciones;
public class AltaEventoDeportivoUseCase(IRepositorioEventoDeportivo repo, EventoDeportivoValidador validador, IServicioAutorizacion autorizador)
{
    public void Ejecutar(EventoDeportivo evento, List<Permiso> permisos)
    {
        if (!autorizador.PoseeElPermiso(permisos, Permiso.EventoAlta))
            throw new FalloAutorizacionException("No tiene permiso para añadir un evento deportivo.");

        if (!validador.ValidarConstruccion(evento, out string mensajeError))
            throw new ValidacionException(mensajeError);

        if (!validador.ValidarResponsable(evento.ResponsableId))
            throw new EntidadNotFoundException($"El responsable {evento.ResponsableId} no existe.");

        repo.AltaEventoDeportivo(evento);               
    }
}