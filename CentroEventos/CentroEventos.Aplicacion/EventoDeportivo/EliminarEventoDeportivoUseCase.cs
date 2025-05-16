using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Clases;

namespace CentroEventos.Aplicacion.EventoDeportivo;

public class EliminarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo, IServicioAutorizacion autorizador)
{
    public void Ejecutar(int id, int idUsuario)
    {
        if (!autorizador.PoseeElPermiso(idUsuario, Permiso.EventoBaja))
            throw new FalloAutorizacionException("No tiene permiso para añadir una persona.");

        if (!repo.EventoExiste(id))
            throw new EntidadNotFoundException("Evento no encontrado");
        
        //if (evento tiene reserva)
        //    throw new OperacionInvalidaException("No se puede eliminar un evento con reservas"); FALTA REPO RESERVA

        repo.EliminarEventoDeportivo(id);
        Console.WriteLine($"Persona ID {id} eliminada exitosamente.");    
    }
}

