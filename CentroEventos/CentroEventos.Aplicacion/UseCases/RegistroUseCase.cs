namespace CentroEventos.Aplicacion.UseCases;

using Interfaces;
using Excepciones;
using Entidades;
using Validadores;
using System.Security.Cryptography;
using System.Text;

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
    
        repo.AltaUsuario(usuario);
    }
}