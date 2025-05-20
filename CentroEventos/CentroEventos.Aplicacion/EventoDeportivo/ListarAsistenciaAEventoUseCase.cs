namespace CentroEventos.Aplicacion.EventoDeportivo;

using CentroEventos.Aplicacion.Persona;
using CentroEventos.Aplicacion.Reserva;

public class ListarAsistenciaAEventoUseCase(IRepositorioEventoDeportivo repoEventoDeportivo, IRepositorioReserva repoReserva,IRepositorioPersona repoPersona, int id)
{
    public List<Persona> Ejecutar()
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