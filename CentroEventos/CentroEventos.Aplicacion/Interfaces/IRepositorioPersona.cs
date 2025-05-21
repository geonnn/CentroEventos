namespace CentroEventos.Aplicacion.Interfaces;
using Entidades;

public interface IRepositorioPersona
{
    void AgregarPersona(Persona persona);
    void EliminarPersona(int id);
    void ModificarPersona(Persona persona);
    List<Persona> ListarPersonas();
    bool PersonaExiste(int id);
    public bool DniExiste(string dni);
    public bool EmailExiste(string email);
    public Persona ConsultaPersona(int id);
}