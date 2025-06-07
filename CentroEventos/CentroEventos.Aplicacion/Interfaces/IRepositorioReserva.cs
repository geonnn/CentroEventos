namespace CentroEventos.Aplicacion.Interfaces;
using Entidades;

public interface IRepositorioReserva
{
    void AltaReserva(Reserva reserva);
    void BajaReserva(int id);
    void ModificarReserva(Reserva r);
    List<Reserva> ListarReservas();
    bool PersonaTieneReserva(int id);
    bool EventoTieneReserva(int id);
    bool PersonaReservoEvento(int pId, int eId);
    bool EventoTieneCupo(int id, int cupoMax);
    bool ReservaExiste(int id);
}
