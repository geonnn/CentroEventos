namespace CentroEventos.Aplicacion.UseCases;
using Interfaces;
using Entidades;
using Excepciones;
using Validadores;


public class EliminarPersonaUseCase(IRepositorioPersona repo, PersonaValidador validador, IServicioAutorizacion autorizador)
{
    public void Ejecutar(int id, int idUsuario)
    {
        if (!autorizador.PoseeElPermiso(idUsuario, Permiso.UsuarioBaja))
            throw new FalloAutorizacionException("No tiene permiso para eliminar una persona.");

        
            throw new EntidadNotFoundException($"Persona ID {id} no encontrada.");

        // PersonaValidador recibe todos los repositorios en su construcción.
        // Hace las consultas a los repositorios que no sean de la entidad propia de este useCase.
        if (!validador.ValidarReglas(id, out string mensajeError))
            throw new OperacionInvalidaException(mensajeError);

        repo.EliminarPersona(id);
    }
}
