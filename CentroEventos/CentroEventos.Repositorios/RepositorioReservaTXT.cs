namespace CentroEventos.Repositorios.Reserva;
using CentroEventos.Aplicacion.Reserva;


public class RepositorioReservaTXT : IRepositorioReserva
{
    readonly string _archReservas = "../../../../CentroEventos.Repositorios/txt_files/reservas.txt";
    readonly string _archUltimaId = "../../../../CentroEventos.Repositorios/txt_files/ultima_id_reservas.txt";

    public RepositorioReservaTXT() {
        if (!File.Exists(_archUltimaId)) {
            using StreamWriter sw = new StreamWriter(_archUltimaId);
            sw.Write(0);
        }
    }

    public void AgregarReserva(Reserva reserva) {
        string r = reserva.ToStringParaTXT(NuevoId());
        using StreamWriter sw = new StreamWriter(_archReservas, true);
        sw.WriteLine(r);
    }

    public void EliminarReserva(int id) {

    }
        
   public void ModificarReserva(int id) {
        
    }
    
    public List<Reserva> ListarReserva() {
        
        using var sr = new StreamReader(_archReservas);
        sr.ReadLine();
        Reserva r;
        List<Reserva> ListaReserva = new List<Reserva>{};
        while (!sr.EndOfStream) {
            r = new Reserva();
            //r.Id = int.Parse(sr.ReadLine());
        }
        return new List<Reserva> ();
    }

    private int NuevoId()
    {
        // implementar try catch.
        using StreamReader sr = new StreamReader(_archUltimaId);
        string? s = sr.ReadLine();
        Console.WriteLine(s);
        int id = int.Parse(s);
        id++;
        sr.Close();
        using StreamWriter sw = new StreamWriter(_archUltimaId);
        sw.WriteLine(id);
        sw.Close();
        return id;
    }
}
