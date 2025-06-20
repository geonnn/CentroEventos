namespace CentroEventos.Aplicacion.UseCases;

using Interfaces;
using Excepciones;
using Entidades;
using Validadores;

public class RegistroUseCase(IRepositorioUsuario repo, UsuarioValidador validador)
{
    public void Ejecutar(Usuario usuario)
    {
        {
            if (!validador.ValidarConstruccion(usuario, out string mensajeError))
                throw new ValidacionException(mensajeError);
        }
        {
            if (!validador.ValidarDuplicado(usuario, out string mensajeError))
                throw new DuplicadoException(mensajeError);
        }

        if (repo.EsPrimerUsuario())
            repo.AltaUsuario(usuario, true);
        else
            repo.AltaUsuario(usuario);

    }
}