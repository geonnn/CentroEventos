using CentroEventos.Aplicacion.Interfaces;
namespace CentroEventos.Repositorios;

public class IdGetter : IIdGetter
{
    /// <inheritdoc/>
    public int GetNuevoId(string archivo)
    {
        using StreamReader sr = new StreamReader(archivo);
        if (!int.TryParse(sr.ReadLine(), out int id))
            throw new Exception("Error al recuperar la última ID.");

        id++;
        sr.Close();

        using StreamWriter sw = new StreamWriter(archivo);
        sw.WriteLine(id);
        return id;
    }
}
