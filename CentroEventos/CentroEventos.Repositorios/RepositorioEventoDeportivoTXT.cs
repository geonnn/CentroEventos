namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.EventoDeportivo;
using CentroEventos.Aplicacion.Persona;
using CentroEventos.Aplicacion.Reserva;

public class RepositorioEventoDeportivoTXT : IRepositorioEventoDeportivo
{
    readonly IIdGetter _idgetter;
    readonly IFileManager _fileManager;
    readonly string _archEventos = "../../../../CentroEventos.Repositorios/txt_files/eventos_deportivos.txt";
    readonly string _archUltimaId = "../../../../CentroEventos.Repositorios/txt_files/ultima_id_eventos_deportivos.txt";

    public RepositorioEventoDeportivoTXT(IIdGetter idg, IFileManager fm)
    {
        _idgetter = idg;
        _fileManager = fm;
        _fileManager.InicializarArchivo(_archUltimaId);
    }

    public void AgregarEventoDeportivo(EventoDeportivo evento)
    {
        using StreamWriter sw = new StreamWriter(_archEventos, true);
        sw.WriteLine(evento.ToStringParaTXT(_idgetter.GetNuevoId(_archUltimaId)));
    }

    public void EliminarEventoDeportivo(int id)
    {

    }

    public void ModificarEventoDeportivo(int id)
    {

    }

    public List<EventoDeportivo> ListarEventoDeportivo()
    {
        var resultado = new List<EventoDeportivo>();
        using var sr = new StreamReader(_archEventos);

        while (!sr.EndOfStream)
        {

            int eventoId = int.Parse(sr.ReadLine() ?? "");
            string eventoNombre = sr.ReadLine() ?? "";
            string personaDescripcion = sr.ReadLine() ?? "";
            DateTime eventoHoraInicio = DateTime.Parse(sr.ReadLine() ?? "");
            double eventoDuracion = double.Parse(sr.ReadLine() ?? "");
            int eventoCupoMaximo = int.Parse(sr.ReadLine() ?? "");
            int eventoResponsableId = int.Parse(sr.ReadLine() ?? "");
            var evento = new EventoDeportivo(eventoId, eventoNombre, personaDescripcion, eventoHoraInicio, eventoDuracion, eventoCupoMaximo, eventoResponsableId);
            resultado.Add(evento);
        }
        return resultado;
    }

    public List<EventoDeportivo> ListarEventoDeportivo(DateTime fecha)
    {
        List<EventoDeportivo> eventos = ListarEventoDeportivo();
        eventos.RemoveAll(e => e.FechaHoraInicio < fecha);
        return eventos;
    }

    public bool EventoExiste(int id)
    {
        foreach (EventoDeportivo e in ListarEventoDeportivo())
            if (id == e.Id)
                return true;

        return false;
    }

    public bool Finalizo(int id)
    {
        foreach (EventoDeportivo evento in ListarEventoDeportivo())
        {
            if (evento.Id == id)
                return evento.FechaHoraInicio < DateTime.Now;
        }
        return false;
    }

    public List<EventoDeportivo> ListarEventosConCupoDisponible(IRepositorioReserva repoReserva)
    {
        List<EventoDeportivo> EventosFuturos = ListarEventoDeportivo(DateTime.Now);
        List<Reserva> reservas = repoReserva.ListarReserva();
        foreach (EventoDeportivo e in EventosFuturos)
        {
            
            int contador = 0;
            foreach (Reserva r in reservas)
            {
                if (r.EventoDeportivoId == e.Id)
                    contador++;
            }
            if (contador < e.CupoMaximo)
                EventosFuturos.Append(e);
        }

        return EventosFuturos;
    }

}

