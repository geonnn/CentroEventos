namespace CentroEventos.Aplicacion.EventoDeportivo;

public class EliminarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo)
{
    public void Ejecutar(int id)
    {
        repo.EliminarEventoDeportivo(id);
    }
}
