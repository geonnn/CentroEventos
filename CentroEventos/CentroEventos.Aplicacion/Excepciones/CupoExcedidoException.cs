namespace CentroEventos.Aplicacion.Excepciones;
public class CupoExcedidoException : Exception
{

    public CupoExcedidoException() { }

    public CupoExcedidoException(string message) : base(message) { }

    public CupoExcedidoException(string message, Exception inner) : base(message, inner) { }
}
