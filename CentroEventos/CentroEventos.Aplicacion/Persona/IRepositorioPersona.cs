namespace CentroEventos.Aplicacion.Persona;

public interface IRepositorioPersona
{
    void AgregarPersona(Persona persona);
    void EliminarPersona(int id);
    void ModificarPersona(int id);
    List<Persona> ListarPersonas();
    Persona PedirDatos(int id);
    bool PersonaExiste(int id);
}