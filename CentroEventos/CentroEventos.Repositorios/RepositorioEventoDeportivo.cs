namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo
{
    public RepositorioEventoDeportivo() { }

    public void AltaEventoDeportivo(EventoDeportivo evento)
    {
        using var context = new CentroEventosContext();
        context.Add(evento);
        context.SaveChanges();
    }

    public void BajaEventoDeportivo(int id)
    {
        using var context = new CentroEventosContext();
        // context.Remove(evento);
        context.EventosDeportivos.Remove(context.EventosDeportivos.Where(e => e.Id == id).Single());
        context.SaveChanges();
    }

    public void ModificarEventoDeportivo(EventoDeportivo nuevoEventoDeportivo)
    {
        using var context = new CentroEventosContext();
        context.EventosDeportivos.Update(nuevoEventoDeportivo);
        context.SaveChanges();
    }

    public List<EventoDeportivo> ListarEventoDeportivo()
    {
        using var context = new CentroEventosContext();
        return context.EventosDeportivos.ToList();
    }

    public List<Reserva> ListarReservasDeEvento(int id)
    {
        using var context = new CentroEventosContext();
        return context.EventosDeportivos.First(e => e.Id == id).Reservas!.ToList();
    }

    /// <summary>
    /// Devuelve una lista de eventos deportivos cuya fecha de inicio es igual o posterior a la fecha recibidia como parámetro.
    /// </summary>
    /// <param name="fecha">Fecha desde la cual se consideran los eventos como futuros.</param>
    /// <returns>Lista de eventos deportivos con fecha de inicio igual o posterior a la fecha especificada.</returns>
    public List<EventoDeportivo> ListarEventoDeportivoFuturo(DateTime fecha)
        => ListarEventoDeportivo().Where(e => e.FechaHoraInicio >= fecha).ToList();

    /// <summary>
    /// Devuelve una lista de eventos deportivos cuya fecha de inicio es anterior a la fecha recibida como parámetro.
    /// </summary>
    /// <param name="fecha">Fecha hasta la cual se consideran los eventos como pasados.</param>
    /// <returns>Lista de eventos deportivos con fecha de inicio anterior a la fecha especificada.</returns>
    public List<EventoDeportivo> ListarEventoDeportivoPasado(DateTime fecha)
        => ListarEventoDeportivo().Where(e => e.FechaHoraInicio < fecha).ToList();

    /// <summary>
    /// Devuelve un boolean indicando la existencia de un evento con id recibida por parámetro.
    /// </summary>
    /// <param name="id">Id del evento a verificar existencia.</param>
    /// <returns>True si el evento existe, false si no.</returns>
    public bool EventoExiste(int id)
    {
        using var context = new CentroEventosContext();
        return context.EventosDeportivos.Any(e => e.Id == id);
    }

    // int.TryParse() usa algo como esto para evitar la null warning:
    private bool TryGetEvento(int id, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out EventoDeportivo? ev)
    {
        ev = ListarEventoDeportivo().Find(e => e.Id == id);
        return ev is not null;
    }

    public bool Finalizo(int id)
    {
        if (TryGetEvento(id, out EventoDeportivo? e))
            return e.FechaHoraInicio < DateTime.Now;

        throw new EntidadNotFoundException($"El evento ID {id} no existe.");
    }

    public bool PersonaEsResponsable(int id)
    {
        using var context = new CentroEventosContext();
        return context.EventosDeportivos.Any(e => e.ResponsableId == id);
    }

    public int GetCupoMax(int id)
    {
        if (TryGetEvento(id, out EventoDeportivo? e))
            return e.CupoMaximo;
        
        throw new EntidadNotFoundException($"El evento ID {id} no existe.");
    }
}

