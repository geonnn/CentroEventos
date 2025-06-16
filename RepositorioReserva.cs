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
        using var context = new CentroEventosContext();
        context.Reservas.Update(nuevaReserva);
        context.SaveChanges();
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
        using (var context = new CentroEventosContext())
        return context.Reservas.FirstOrDefault(r => r.PersonaId == id) != null;
    }

    public bool EventoTieneReserva(int id)
    {
        using (var context = new CentroEventosContext())
        return context.Reservas.FirstOrDefault(r => r.EventoDeportivoId == id) != null;
    }

    public bool PersonaReservoEvento(int pId, int eId)
    {
        using (var context = new CentroEventosContext())
        return context.Reservas.FirstOrDefault(r => r.PersonaId == pId && r.EventoDeportivoId == eId) != null;
    }

    public bool EventoTieneCupo(int eId, int cupoMax)
    {
        using (var context = new CentroEventosContext())
        return context.Reservas.Where(r => r.EventoDeportivoId == eId).Count() < cupoMax;
    }

    public bool ReservaExiste(int id)
    {
        using (var context = new CentroEventosContext())
        return context.Reservas.FirstOrDefault(r => r.Id == id) != null;
    }
}
