namespace CentroEventos.Repositorios.Reserva;
using CentroEventos.Aplicacion.Reserva;


public class RepositorioReservaTXT : IRepositorioReserva
{
    readonly string _NombreArch = "Reservas.txt";
    public void AgregarReserva(Reserva reserva) {
        using var sw = new StreamWriter(_NombreArch, true);
        while (sw.EndOfStream)
        sw.WriteLine(reserva.ToStringParaTXT())
    }

    public void EliminarReserva(Reserva r) {
        
   public void ModificarReserva(Reserva r) {
        
    }
    
    public void ListarReserva(Reserva r) {
        
    }

    public
}
