namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.EventoDeportivo;
using CentroEventos.Aplicacion.Persona;

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
        List<EventoDeportivo> lista = new(); 
        
        return lista;
    }
}
