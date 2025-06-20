namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

public class RepositorioReserva : IRepositorioReserva
{
    public RepositorioReserva() { }

    public void AltaReserva(Reserva reserva)
    {
        using var context = new CentroEventosContext();
        context.Add(reserva);
        context.SaveChanges();
    }

    public void BajaReserva(int id)
    {
        using var context = new CentroEventosContext();
        // context.Reservas.Remove(reserva);
        context.Reservas.Remove(context.Reservas.Where(r => r.Id == id).Single());
        context.SaveChanges();
    }

    public void ModificarReserva(Reserva nuevaReserva)
    {
        using var context = new CentroEventosContext();
        context.Reservas.Update(nuevaReserva);
        context.SaveChanges();
    }

    public List<Reserva> ListarReservas()
    {
        using var context = new CentroEventosContext();
        return context.Reservas.ToList();
    }

    public bool PersonaTieneReserva(int id)
    {
        using var context = new CentroEventosContext();
        return context.Reservas.Any(r => r.PersonaId == id);
    }

    public bool EventoTieneReserva(int id)
    {
        using var context = new CentroEventosContext();
        return context.Reservas.Any(r => r.EventoDeportivoId == id);
    }

    public bool PersonaReservoEvento(int pId, int eId)
    {
        using var context = new CentroEventosContext();
        return context.Reservas.Any(r => r.PersonaId == pId && r.EventoDeportivoId == eId);
    }

    public bool EventoTieneCupo(int eId, int cupoMax)
    {
        using var context = new CentroEventosContext();
        return context.Reservas.Where(r => r.EventoDeportivoId == eId).Count() < cupoMax;
    }

    public bool ReservaExiste(int id)
    {
        using var context = new CentroEventosContext();
        return context.Reservas.Any(r => r.Id == id);
    }
}
