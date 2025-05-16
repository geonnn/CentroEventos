namespace CentroEventos.Aplicacion.EventoDeportivo;

public class ListarEventoDeportivoUseCase(IRepositorioEventoDeportivo repositorioEvento)
{
    public void Ejecutar()
    {
        repositorioEvento.ListarEventoDeportivo();
    }
}
