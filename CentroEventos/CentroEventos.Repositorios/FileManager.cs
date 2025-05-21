namespace CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Interfaces;

public class FileManager : IFileManager
{
    public void InicializarArchivo(string archivo)
    {
        if (!File.Exists(archivo))
        {
            using StreamWriter sw = new StreamWriter(archivo);
            sw.Write(0);
        }
    }

    public void InicializarRepo(string archivo)
    {
        if (!File.Exists(archivo))
        {
            using StreamWriter sw = new StreamWriter(archivo);
        }
    }
}
