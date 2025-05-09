namespace CentroEventos.Aplicacion.EventoDeportivo;

public class ModificarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo)
{
    public void Ejecutar(int id)
    {
        repo.ModificarEventoDeportivo(id);
    }

}
