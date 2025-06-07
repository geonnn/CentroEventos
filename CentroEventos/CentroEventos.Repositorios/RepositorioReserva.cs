namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

public class RepositorioReserva : IRepositorioReserva
{
    public RepositorioReserva() { }

    public void AltaReserva(Reserva reserva)
    {
        using StreamWriter sw = new StreamWriter(_archReservas, true);
        sw.WriteLine(reserva.ToStringParaTXT(_idGetter.GetNuevoId(_archUltimaId)));
    }

    public void BajaReserva(int id)
    {
        List<Reserva> reservas = ListarReservas();
        reservas.RemoveAt(reservas.FindIndex(p => p.Id == id));
        using StreamWriter sw = new StreamWriter(_archReservas, false);
        reservas.ForEach(r => sw.WriteLine(r.ToStringParaTXT()));
    }

    public void ModificarReserva(Reserva nuevaReserva)
    {
        List<Reserva> reservas = ListarReservas();

        int index = reservas.FindIndex(r => r.Id == nuevaReserva.Id);
        reservas[index] = nuevaReserva;

        using StreamWriter sw = new StreamWriter(_archReservas, false);
        reservas.ForEach(r => sw.WriteLine(r.ToStringParaTXT()));
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
        => ListarReservas().Exists(r => r.PersonaId == id);

    public bool EventoTieneReserva(int id)
        => ListarReservas().Exists(r => r.EventoDeportivoId == id);

    public bool PersonaReservoEvento(int pId, int eId)
        => ListarReservas().Exists(r => r.PersonaId == pId && r.EventoDeportivoId == eId);

    public bool EventoTieneCupo(int eId, int cupoMax)
        => ListarReservas().FindAll(e => e.Id == eId).Count < cupoMax;

    public bool ReservaExiste(int id)
        => ListarReservas().Exists(r => r.Id == id);
}
