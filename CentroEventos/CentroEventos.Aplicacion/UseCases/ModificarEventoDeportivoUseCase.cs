namespace CentroEventos.Aplicacion.UseCases;
using Entidades;
using Excepciones;
using Interfaces;
using Validadores;

public class ModificarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo, EventoDeportivoValidador validador, IServicioAutorizacion autorizador)
{
    public void Ejecutar(EventoDeportivo evento, List<Permiso> permisos) //el evento que recibe esta validada?? de lo contrario pensar como validar
    {
        if (!autorizador.PoseeElPermiso(permisos, Permiso.EventoModificacion))
            throw new FalloAutorizacionException("No tiene permiso para modificar un evento deportivo.");

        if (!validador.ValidarConstruccion(evento, out string mensajeError))
            throw new ValidacionException(mensajeError);

        if (!repo.EventoExiste(evento.Id))
            throw new EntidadNotFoundException($"Evento ID {evento.Id} no encontrado.");

        if (!validador.ValidarResponsable(evento.Id))
            throw new EntidadNotFoundException($"El nuevo responsable ID {evento.ResponsableId} no existe.");

        if(repo.Finalizo(evento.Id))
            throw new OperacionInvalidaException($"No se puede modificar el evento {evento.Id}. El evento ya ocurrió.");

        repo.ModificarEventoDeportivo(evento);
    }

}
