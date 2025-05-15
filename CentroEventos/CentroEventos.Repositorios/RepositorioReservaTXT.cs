namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.Reserva;

public class RepositorioReservaTXT : IRepositorioReserva
{
    readonly IIdGetter _idGetter;
    readonly IFileManager _fileManager;
    readonly string _archReservas = "../../../../CentroEventos.Repositorios/txt_files/reservas.txt";
    readonly string _archUltimaId = "../../../../CentroEventos.Repositorios/txt_files/ultima_id_reservas.txt";

    public RepositorioReservaTXT(IIdGetter idg, IFileManager fm)
    {
        _idGetter = idg;
        _fileManager = fm;
        _fileManager.InicializarArchivo(_archUltimaId);
    }

    public void AgregarReserva(Reserva reserva)
    {
        using StreamWriter sw = new StreamWriter(_archReservas, true);
        sw.WriteLine(reserva.ToStringParaTXT(_idGetter.GetNuevoId(_archUltimaId)));
    }

    public void EliminarReserva(int id)
    {
        List<Reserva> reservas = ListarReserva();
        List<Reserva> reservasN = new List<Reserva> {};
        foreach(Reserva r in reservas)
        {
            if (!(r.Id == id))
            {
                reservasN.Append(r);
            }
        }
        using StreamWriter sw = new StreamWriter(_archReservas, false);
        foreach(Reserva r in reservasN)
        {
            sw.WriteLine(r.ToStringParaTXT());
        }

    }

    public void ModificarReserva(Reserva NuevaReserva)
    {
        List<Reserva> reservas = ListarReserva();
        List<Reserva> reservasN = new List<Reserva> {};
        foreach(Reserva r in reservas)
        {
            if (r.Id == NuevaReserva.Id)
                reservasN.Append(r);
            else
                reservasN.Append(NuevaReserva);
        }
        using StreamWriter sw = new StreamWriter(_archReservas, false);
        foreach(Reserva r in reservasN)
        {
            sw.WriteLine(r.ToStringParaTXT());
        }
    }
    
    public List<Reserva> ListarReserva() {
        
        using var sr = new StreamReader(_archReservas);
        sr.ReadLine();
        Reserva r;
        List<Reserva> ListaReserva = new List<Reserva>{};
        while (!sr.EndOfStream) {
            // r = new Reserva();
            //r.Id = int.Parse(sr.ReadLine());
        }
        return new List<Reserva> ();
    }
}
