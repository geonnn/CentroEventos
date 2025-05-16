namespace CentroEventos.Aplicacion.Persona;

public interface IRepositorioPersona
{
    void AgregarPersona(Persona persona);
    void EliminarPersona(int id);
    void ModificarPersona(Persona persona);
    List<Persona> ListarPersonas();
    bool PersonaExiste(int id);
    public bool DniExiste(String dni);
    public bool EmailExiste(String email);
}