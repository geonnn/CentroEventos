namespace CentroEventos.Repositorios;

using Microsoft.EntityFrameworkCore;

public class CentroEventosSqlite
{
    public static void Inicializar()
    {
        using var context = new CentroEventosContext();
        
        context.Database.EnsureCreated();

        var connection = context.Database.GetDbConnection();
        connection.Open();
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "PRAGMA journal_mode=DELETE;";
            command.ExecuteNonQuery();
        }
    }
}
