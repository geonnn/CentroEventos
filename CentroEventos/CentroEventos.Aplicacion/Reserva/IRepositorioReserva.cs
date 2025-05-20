namespace CentroEventos.Aplicacion.Reserva;

public interface IRepositorioReserva
{
    void AgregarReserva(Reserva reserva);
    void EliminarReserva(int id);
    void ModificarReserva(Reserva r);
    List<Reserva> ListarReservas();
    bool PersonaTieneReserva(int id);
    bool EventoTieneReserva(int id);
    bool PersonaReservoEvento(int pId, int eId);
}
