namespace CentroEventos.Aplicacion.UseCases;
using Interfaces;
using Entidades;
using Excepciones;
using Validadores;


public class BajaPersonaUseCase(IRepositorioPersona repo, PersonaValidador validador, IServicioAutorizacion autorizador)
{
    public void Ejecutar(int id, int idPersona)
    {
        if (!autorizador.PoseeElPermiso(idPersona, Permiso.PersonaBaja))
            throw new FalloAutorizacionException("No tiene permiso para eliminar una persona.");

        if (!repo.PersonaExiste(id))
            throw new EntidadNotFoundException($"Persona ID {id} no encontrada.");

        // PersonaValidador recibe todos los repositorios en su construcción.
        // Hace las consultas a los repositorios que no sean de la entidad propia de este useCase.
        if (!validador.ValidarReglas(id, out string mensajeError))
            throw new OperacionInvalidaException(mensajeError);

        repo.BajaPersona(id);
    }
}
