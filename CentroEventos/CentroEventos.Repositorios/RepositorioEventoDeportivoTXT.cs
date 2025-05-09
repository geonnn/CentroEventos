namespace CentroEventos.Repositorios;
using CentroEventos.Aplicacion.EventoDeportivo;

public class RepositorioEventoDeportivoTXT : IRepositorioEventoDeportivo
{
    readonly string _nombreArch = "eventos_deportivos.txt";

    public void AgregarEventoDeportivo(EventoDeportivo evento)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(evento.ToStringParaTXT(NuevoId()));
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
        using var sr = new StreamReader(_nombreArch);
        using var sw = new StreamWriter(_nombreArch, false);
        int id = int.Parse(sr.ReadLine()) + 1;
        sw.Write(id);
        return id;
    }

}
