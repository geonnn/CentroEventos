using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Clases;

namespace CentroEventos.Aplicacion.EventoDeportivo;

public class AgregarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo, EventoDeportivoValidador validador, IServicioAutorizacion autorizador)
{
    public void Ejecutar(EventoDeportivo evento, int idUsuario)
    {
        if (!autorizador.PoseeElPermiso(idUsuario, Permiso.EventoAlta))
            throw new FalloAutorizacionException("No tiene permiso para añadir una persona.");

        if (!validador.Validar(evento, out string mensajeError))
            throw new ValidacionException(mensajeError);

        //if (!_repoPersona.PersonaExiste(evento.ResponsableId)) TENEMOS QUE MANDAR EL REPO DE PERSONAS POR QUE SI NO EXISTE EL RESPONSABLE ES OTRO TIPO DE EXCEPTION
        //    throw new EntidadNotFoundException("El responsable no existe");

        if(evento.FechaHoraInicio < DateTime.Now)
            throw new  OperacionInvalidaException("No se puede crear un evento en el pasado");

        repo.AgregarEventoDeportivo(evento);
        Console.WriteLine($"Evento ID {evento.Id} añadido exitosamente.");
               
    }
}