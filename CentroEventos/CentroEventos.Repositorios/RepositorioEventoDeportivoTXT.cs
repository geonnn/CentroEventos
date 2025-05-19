namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.EventoDeportivo;

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
        List<EventoDeportivo> lista = ListarEventoDeportivo();
        lista.RemoveAt(lista.FindIndex(e => e.Id == id));
        using StreamWriter sw = new StreamWriter(_archEventos, false);
        lista.ForEach(e => sw.WriteLine(e.ToStringParaTXT()));
    }

    public void ModificarEventoDeportivo(EventoDeportivo NuevoEventoDeportivo)
    {
        List<EventoDeportivo> eventoDeportivos = ListarEventoDeportivo();
        List<EventoDeportivo> eventoDeportivosN = new List<EventoDeportivo> { };
        foreach (EventoDeportivo e in eventoDeportivos)
        {
            if (e.Id == NuevoEventoDeportivo.Id)
                eventoDeportivosN.Add(e);
            else
                eventoDeportivosN.Add(NuevoEventoDeportivo);
        }
        using StreamWriter sw = new StreamWriter(_archEventos, false);
        foreach (EventoDeportivo e in eventoDeportivosN)
        {
            sw.WriteLine(e.ToStringParaTXT());
        }
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

    /// <summary>
    /// Devuelve una lista de eventos deportivos cuya fecha de inicio es igual o posterior a la fecha recibidia como parámetro.
    /// </summary>
    /// <param name="fecha">Fecha desde la cual se consideran los eventos como futuros.</param>
    /// <returns>Lista de eventos deportivos con fecha de inicio igual o posterior a la fecha especificada.</returns>
    public List<EventoDeportivo> ListarEventoDeportivoFuturo(DateTime fecha)
    {
        List<EventoDeportivo> eventos = ListarEventoDeportivo();
        eventos.RemoveAll(e => e.FechaHoraInicio < fecha);
        return eventos;
    }

    /// <summary>
    /// Devuelve una lista de eventos deportivos cuya fecha de inicio es anterior a la fecha recibida como parámetro.
    /// </summary>
    /// <param name="fecha">Fecha hasta la cual se consideran los eventos como pasados.</param>
    /// <returns>Lista de eventos deportivos con fecha de inicio anterior a la fecha especificada.</returns>
    public List<EventoDeportivo> ListarEventoDeportivoPasado(DateTime fecha)
    {
        List<EventoDeportivo> eventos = ListarEventoDeportivo();
        eventos.RemoveAll(e => e.FechaHoraInicio >= fecha);
        return eventos;
    }

    public bool EventoExiste(int id)
        => ListarEventoDeportivo().Exists(e => e.Id == id);

    // int.TryParse() usa algo como esto para evitar la null warning:
    private bool TryGetEvento(int id, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out EventoDeportivo? ev)
    {
        ev = ListarEventoDeportivo().Find(e => e.Id == id);
        return ev is not null;
    }

    public bool Finalizo(int id)
    {
        if (TryGetEvento(id, out EventoDeportivo? e))
            return e.FechaHoraInicio < DateTime.Now;

        return false;
    }

    public bool PersonaEsResponsable(int id)
        => ListarEventoDeportivo().Exists(e => e.ResponsableId == id);
}

