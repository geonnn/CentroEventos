using CentroEventos.Aplicacion;
namespace CentroEventos.Repositorios;

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
}
