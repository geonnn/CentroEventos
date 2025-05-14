namespace CentroEventos.Repositorios;
using CentroEventos.Aplicacion.EventoDeportivo;

public class RepositorioEventoDeportivoTXT : IRepositorioEventoDeportivo
{
    readonly string _archEventos = "../../../../CentroEventos.Repositorios/txt_files/eventos_deportivos.txt";
    readonly string _archUltimaId = "../../../../CentroEventos.Repositorios/txt_files/ultima_id_eventos_deportivos.txt";

    public RepositorioEventoDeportivoTXT(){
        if(!File.Exists(_archUltimaId)) {
            using StreamWriter sw = new StreamWriter(_archUltimaId);
            sw.Write(0);
        }
    }

    public void AgregarEventoDeportivo(EventoDeportivo evento)
    {
        string e = evento.ToStringParaTXT(NuevoId());
        using StreamWriter sw = new StreamWriter(_archEventos, true);
        sw.WriteLine(e);
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

    private int NuevoId() {
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
