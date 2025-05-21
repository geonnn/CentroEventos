namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;


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
        _fileManager.InicializarRepo(_archPersonas);
    }

    public void AgregarPersona(Persona persona)
    {
        using StreamWriter sw = new StreamWriter(_archPersonas, true);
        sw.WriteLine(persona.ToStringParaTXT(_idGetter.GetNuevoId(_archUltimaId)));
    }

    public void EliminarPersona(int id)
    {
        List<Persona> personas = ListarPersonas();
        personas.RemoveAt(personas.FindIndex(p => p.Id == id));
        using StreamWriter sw = new StreamWriter(_archPersonas, false);
        personas.ForEach(p => sw.WriteLine(p.ToStringParaTXT()));
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

    public void ModificarPersona(Persona nuevaPersona)
    {
        List<Persona> personas = ListarPersonas();

        int index = personas.FindIndex(p => p.Id == nuevaPersona.Id);
        personas[index] = nuevaPersona;

        using StreamWriter sw = new StreamWriter(_archPersonas, false);
        personas.ForEach(p => sw.WriteLine(p.ToStringParaTXT()));
    }

    // int.TryParse() usa algo como esto para evitar la null warning:
    private bool TryGetPersona(int id, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Persona? p)
    {
        p = ListarPersonas().Find(p => p.Id == id);
        return p is not null;
    }

    // Generalmente siempre que se use ConsultaPersona la persona debería existir, considerar esto una última capa de seguridad por si se utiliza con algún id de persona no válido.
    public Persona ConsultaPersona(int id)
    {
        if (TryGetPersona(id, out Persona? p))
            return p;

        throw new EntidadNotFoundException($"La persona ID {id} no existe.");
    }

    public bool PersonaExiste(int id)
        => ListarPersonas().Exists(p => p.Id == id);

    public bool DniExiste(string dni)
        => ListarPersonas().Exists(p => p.Dni == dni);

    public bool EmailExiste(string email)
        => ListarPersonas().Exists(p => p.Email == email);
}