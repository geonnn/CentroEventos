namespace CentroEventos.Aplicacion.Persona;
using Interfaces;
using Clases;

public class AgregarPersonaUseCase(IRepositorioPersona repo, PersonaValidador validador, IServicioAutorizacion autorizador)
{
    public void Ejecutar(Persona persona, int idUsuario)
    {
        if (!autorizador.PoseeElPermiso(idUsuario, Permiso.UsuarioAlta))
            throw new FalloAutorizacionException("No tiene permiso para añadir una persona.");

        {
            if (!validador.ValidarConstruccion(persona, out string mensajeError))
                throw new ValidacionException(mensajeError);
        }
        
        {
            if (!validador.ValidarDuplicado(persona, out string mensajeError))
                throw new DuplicadoException(mensajeError);
        }

        repo.AgregarPersona(persona);
    }
}