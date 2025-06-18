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
        var lista = new List<EventoDeportivo>();
        using (var context = new CentroEventosContext())
        {
            foreach (var e in context.EventosDeportivos)
                lista.Add(e);
        }
        return lista;
    }

    /// <summary>
    /// Devuelve una lista de eventos deportivos cuya fecha de inicio es igual o posterior a la fecha recibidia como parámetro.
    /// </summary>
    /// <param name="fecha">Fecha desde la cual se consideran los eventos como futuros.</param>
    /// <returns>Lista de eventos deportivos con fecha de inicio igual o posterior a la fecha especificada.</returns>
    public List<EventoDeportivo> ListarEventoDeportivoFuturo(DateTime fecha)
    {
        List<EventoDeportivo> eventos = ListarEventoDeportivo();
        eventos.RemoveAll(e => e.FechaHoraInicio < fecha );
        return eventos;
    }

    /// <summary>
    /// Devuelve una lista de eventos deportivos cuya fecha de inicio es anterior a la fecha recibida como parámetro.
    /// </summary>
    /// <param name="fecha">Fecha hasta la cual se consideran los eventos como pasados.</param>
    /// <returns>Lista de eventos deportivos con fecha de inicio anterior a la fecha especificada.</returns>
    public List<EventoDeportivo> ListarEventoDeportivoPasado(DateTime fecha)
    {
        List<EventoDeportivo> eventos = ListarEventoDeportivo();
        eventos.RemoveAll(e => e.FechaHoraInicio >= fecha);
        return eventos;
    }

    public bool EventoExiste(int id){
        using (var context = new CentroEventosContext())
        return context.EventosDeportivos.FirstOrDefault(e => e.Id == id) != null;
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

    public bool PersonaEsResponsable(int id){
        using (var context = new CentroEventosContext())
        return context.EventosDeportivos.FirstOrDefault(e => e.ResponsableId == id) != null;
    }

    public int GetCupoMax(int id)
    {
        if (TryGetEvento(id, out EventoDeportivo? e))
            return e.CupoMaximo;
        
        throw new EntidadNotFoundException($"El evento ID {id} no existe.");
    }
}

