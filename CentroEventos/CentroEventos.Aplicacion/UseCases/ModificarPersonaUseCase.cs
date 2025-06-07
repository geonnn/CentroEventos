namespace CentroEventos.Aplicacion.UseCases;
using Entidades;
using Excepciones;
using Interfaces;
using Validadores;



public class ModificarPersonaUseCase(IRepositorioPersona repo, PersonaValidador validador, IServicioAutorizacion autorizador)
{
    public void Ejecutar(Persona persona, int idPersona) // La persona que recibe esta validada?? de lo contrario pensar como validar
    {
        if (!autorizador.PoseeElPermiso(idPersona, Permiso.PersonaModificacion))
            throw new FalloAutorizacionException("No tiene permiso para modificar una persona.");

        {
            if (!validador.ValidarConstruccion(persona, out string mensajeError))
                throw new ValidacionException(mensajeError);
        }

        if (!repo.PersonaExiste(persona.Id))
            throw new EntidadNotFoundException($"Persona ID {persona.Id} no encontrada.");

        { 
            if (!validador.ValidarDuplicadoModificar(persona, out string mensajeError))
                throw new DuplicadoException(mensajeError);
        }

        repo.ModificarPersona(persona);
    }
}