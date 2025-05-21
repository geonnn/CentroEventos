namespace CentroEventos.Aplicacion.Interfaces;

public interface IIdGetter
{
    /// <summary>
    /// Lee el último ID desde un archivo, lo incrementa y actualiza el archivo.
    /// </summary>
    /// <param name="archivo">Ruta del archivo que contiene el último ID registrado.</param>
    /// <returns>El nuevo ID generado.</returns>
    /// <exception cref="Exception">Se lanza si no se puede leer un ID válido o si no se puede escribir el nuevo ID.</exception>
    int GetNuevoId(string archUltimaId);
}
