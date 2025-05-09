namespace CentroEventos.Aplicacion.Persona;

public interface IRepositorioPersona
{
    void AgregarPersona(Persona persona);
    void EliminarPersona(int id);
    void ModificarPersona(int id);
    List<Persona> ListarPersona();
    Persona PedirDatos(int id);
}