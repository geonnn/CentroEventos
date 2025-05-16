using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Clases;

namespace CentroEventos.Aplicacion.Persona;

public class EliminarPersonaUseCase(IRepositorioPersona repo, IServicioAutorizacion autorizador)
{
    public void Ejecutar(int id, int idUsuario)
    {
        if (!autorizador.PoseeElPermiso(idUsuario, Permiso.UsuarioBaja))
            throw new FalloAutorizacionException("No tiene permiso para eliminar una persona");

        if (!repo.PersonaExiste(id))
            throw new EntidadNotFoundException("Persona no encontrada");

            //if(persona tiene reserva)
            //    throw new OperacionInvalidaException("No se puede eliminar una persona con reservas"); FALTA REPO RESERVA

            //if(persona es responsable de evento)
            //    throw new OperacionInvalidaException("No se puede eliminar una persona con eventos"); FALTA REPO EVENTODEPORTIVO

            repo.EliminarPersona(id);
            Console.WriteLine($"Persona ID {id} eliminada exitosamente.");
    }
}
