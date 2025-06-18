namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
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
        List<Reserva> reservas = ListarReservas();
    }

    public List<Reserva> ListarReservas()
    {
        var lista = new List<Reserva>();

        using (var context = new CentroEventosContext())
        {
            foreach (var r in context.Reservas)
                lista.Add(r);
        }
        return lista;
    }

    public bool PersonaTieneReserva(int id)
    {
    // => ListarReservas().Exists(r => r.PersonaId == id);
        using var context = new CentroEventosContext();
        return context.Reservas.Any(r => r.PersonaId == id);
    }

    public bool EventoTieneReserva(int id)
        => ListarReservas().Exists(r => r.EventoDeportivoId == id);

    public bool PersonaReservoEvento(int pId, int eId)
        => ListarReservas().Exists(r => r.PersonaId == pId && r.EventoDeportivoId == eId);

    public bool EventoTieneCupo(int eId, int cupoMax)
        => ListarReservas().FindAll(e => e.Id == eId).Count < cupoMax;

    public bool ReservaExiste(int id)
        => ListarReservas().Exists(r => r.Id == id);
}
