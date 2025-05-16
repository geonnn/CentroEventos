namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.Persona;

public class RepositorioPersonaTXT : IRepositorioPersona
{
    readonly IIdGetter _idGetter;
    readonly IFileManager _fileManager;
    readonly string _archPersonas = "../../../../CentroEventos.Repositorios/txt_files/personas.txt";
    readonly string _archUltimaId = "../../../../CentroEventos.Repositorios/txt_files/ultima_id_personas.txt";

    public RepositorioPersonaTXT(IIdGetter idg, IFileManager fm)
    {
        _idGetter = idg;
        _fileManager = fm;
        _fileManager.InicializarArchivo(_archUltimaId);
    }

    public void AgregarPersona(Persona persona)
    {
        using StreamWriter sw = new StreamWriter(_archPersonas, true);
        sw.WriteLine(persona.ToStringParaTXT(_idGetter.GetNuevoId(_archUltimaId)));
    }

    public List<Persona> ListarPersonas()
    {
        var resultado = new List<Persona>();
        using var sr = new StreamReader(_archPersonas);

        while (!sr.EndOfStream)
        {

            int personaId = int.Parse(sr.ReadLine() ?? "");
            string personaDni = sr.ReadLine() ?? "";
            string personaNombre = sr.ReadLine() ?? "";
            string personaApellido = sr.ReadLine() ?? "";
            string personaEmail = sr.ReadLine() ?? "";
            string personaTelefono = sr.ReadLine() ?? "";
            var persona = new Persona(personaId, personaDni, personaNombre, personaApellido, personaEmail, personaTelefono);
            resultado.Add(persona);
        }
        return resultado;
    }

    public void EliminarPersona(int id)
    {
        List<Persona> personas = ListarPersonas();
        personas.RemoveAll(p => p.Id == id);
        using StreamWriter sw = new StreamWriter(_archPersonas, false);
        foreach (var p in personas)
        {
            sw.WriteLine(p.ToStringParaTXT(p.Id));
        }
    }

    public void ModificarPersona(Persona persona) //FALTA TERMINAR
    {   
        EliminarPersona(persona.Id);
        using StreamWriter sw = new StreamWriter(_archPersonas, true);
        sw.WriteLine(persona.ToStringParaTXT(persona.Id));
    }
    

    public bool PersonaExiste(int id)
    {
        foreach (Persona p in ListarPersonas())
            if (id == p.Id)
                return true;

        return false;
    }

    public bool DniExiste(String dni)
    {
        foreach (Persona p in ListarPersonas())
            if (dni == p.Dni)
                return true;

        return false;
    }

    public bool EmailExiste(String email)
    {
        foreach (Persona p in ListarPersonas())
            if (email == p.Email)
                return true;

        return false;
    }


}