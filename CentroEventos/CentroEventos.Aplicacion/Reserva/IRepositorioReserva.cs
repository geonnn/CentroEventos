namespace CentroEventos.Aplicacion.Reserva;

public interface IRepositorioReserva
{
    void AgregarReserva(Reserva reserva);
    void EliminarReserva(int id);
    void ModificarReserva(int id);
    List<Reserva> ListarReserva();
}
