using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Clases;

namespace CentroEventos.Aplicacion.EventoDeportivo;

public class ModificarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo, IServicioAutorizacion autorizador)
{
    public void Ejecutar(EventoDeportivo evento, int idUsuario) //el evento que recibe esta validada?? de lo contrario pensar como validar
    {
        if (!autorizador.PoseeElPermiso(idUsuario, Permiso.EventoModificacion))
            throw new FalloAutorizacionException("No tiene permiso para añadir una persona.");

        if(!repo.EventoExiste(evento.Id))
            throw new EntidadNotFoundException("Evento no encontrado");

        //if (nuevo responsable existe) REQUIERE REPO PERSONA
        //    throw new EntidadNotFoundException("El responsable no existe");

        if(repo.Finalizo(evento.Id))
            throw new OperacionInvalidaException("No se puede modificar un evento en el pasado");

        repo.ModificarEventoDeportivo(evento);
        Console.WriteLine($"Evento ID {evento.Id} modificado exitosamente.");
    }

}
