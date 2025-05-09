namespace CentroEventos.Aplicacion.EventoDeportivo;

public class AgregarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo)
{
    public void Ejecutar(EventoDeportivo evento)
    {
        repo.AgregarEventoDeportivo(evento);
    }
}