namespace CentroEventos.Aplicacion.UseCases;
using Interfaces;


public class ListarEventoDeportivoUseCase(IRepositorioEventoDeportivo repositorioEvento)
{
    public void Ejecutar()
    {
        repositorioEvento.ListarEventoDeportivo();
    }
}
