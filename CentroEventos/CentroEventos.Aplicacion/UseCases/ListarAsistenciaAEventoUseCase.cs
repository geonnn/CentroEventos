namespace CentroEventos.Aplicacion.UseCases;

using Entidades;
using Excepciones;
using Interfaces;

public class ListarAsistenciaAEventoUseCase(IRepositorioEventoDeportivo repoEventoDeportivo, IRepositorioReserva repoReserva,IRepositorioPersona repoPersona)
{
    public List<Persona> Ejecutar(int id)
    {
        if (!repoEventoDeportivo.EventoExiste(id))
            throw new EntidadNotFoundException("El evento que quiere listar no existe.");
        if (!repoEventoDeportivo.Finalizo(id))
            throw new OperacionInvalidaException("Quiere listar un evento que no terminó.");
        
        List<Reserva> reservas = repoReserva.ListarReservas();
        List<Persona> asistentes = new List<Persona>();
        
        foreach (Reserva r in reservas)
        {
            if (r.EventoDeportivoId == id)
                asistentes.Add(repoPersona.ConsultaPersona(r.PersonaId));
        }
        return asistentes;
    }
}