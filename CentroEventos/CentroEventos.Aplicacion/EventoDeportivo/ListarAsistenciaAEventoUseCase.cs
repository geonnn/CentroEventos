using CentroEventos.Aplicacion.Persona;
using CentroEventos.Aplicacion.Reserva;

namespace CentroEventos.Aplicacion.EventoDeportivo;

public class ListarAsistenciaAEventoUseCase(IRepositorioEventoDeportivo repoEventoDeportivo, IRepositorioReserva repoReserva,IRepositorioPersona repoPersona, int id)
{
    public List<Persona.Persona> Ejecutar()
    {
        if (!repoEventoDeportivo.EventoExiste(id))
            throw new EntidadNotFoundException("El evento que quiere listar no existe");
        if (!repoEventoDeportivo.Finalizo(id))
            throw new OperacionInvalidaException("Quiere listar un evento que no terminó");
        
        List<Reserva.Reserva> reservas = repoReserva.ListarReserva();
        List<Persona.Persona> asistentes = new List<Persona.Persona>();
        
            foreach (Reserva.Reserva r in reservas)
        {
            if (r.EventoDeportivoId == id)
                asistentes.Add(repoPersona.ConsultaPersona(r.PersonaId));
        }
        return asistentes;
    }
}