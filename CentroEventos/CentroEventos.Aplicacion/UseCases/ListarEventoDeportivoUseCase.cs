namespace CentroEventos.Aplicacion.UseCases;

using CentroEventos.Aplicacion.Entidades;
using Interfaces;


public class ListarEventoDeportivoUseCase(IRepositorioEventoDeportivo repositorioEvento)
{
    public List<EventoDeportivo> Ejecutar()
    {
        return repositorioEvento.ListarEventoDeportivo();
    }
}
