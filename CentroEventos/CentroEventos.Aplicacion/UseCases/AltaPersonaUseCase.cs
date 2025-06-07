namespace CentroEventos.Aplicacion.UseCases;
using Interfaces;
using Entidades;
using Excepciones;
using Validadores;

public class AltaPersonaUseCase(IRepositorioPersona repo, PersonaValidador validador, IServicioAutorizacion autorizador)
{
    public void Ejecutar(Persona persona, int idPersona)
    {
        if (!autorizador.PoseeElPermiso(idPersona, Permiso.PersonaAlta))
            throw new FalloAutorizacionException("No tiene permiso para añadir una persona.");

        {
            if (!validador.ValidarConstruccion(persona, out string mensajeError))
                throw new ValidacionException(mensajeError);
        }
        
        {
            if (!validador.ValidarDuplicado(persona, out string mensajeError))
                throw new DuplicadoException(mensajeError);
        }

        repo.AltaPersona(persona);
    }
}