namespace CentroEventos.Aplicacion.Excepciones;
public class ValidacionException : Exception {

    public ValidacionException() { }

    public ValidacionException(string message): base(message) { }

    public ValidacionException(string message,Exception inner): base(message, inner) { }
}
