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
        sw.Write(persona.ToStringParaTXT(_idGetter.GetNuevoId(_archUltimaId)));
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
        using var sw = new StreamWriter(_archPersonas, true);
    }

    public void ModificarPersona(int id)
    {
        using var sr = new StreamReader(_archPersonas);
        bool encontre = false;
        while (!sr.EndOfStream && !encontre)
        {
            int personaId = int.Parse(sr.ReadLine() ?? "");
            if (personaId == id)
                encontre = true;
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    string aux = sr.ReadLine() ?? "";
                }
            }
        }
        if (encontre)
        {
            string personaDni;
            string personaNombre;
            string personaApellido;
            string personaEmail;
            string personaTelefono;
            AgregarPersona(PedirDatos(id));
        }
    }

    public Persona PedirDatos(int id)
    {
        Console.WriteLine("ingrese dni: ");
        string dni = Console.ReadLine();
        Console.WriteLine("ingrese nombre: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("ingrese apellido: ");
        string apellido = Console.ReadLine();
        Console.WriteLine("ingrese email: ");
        string email = Console.ReadLine();
        Console.WriteLine("ingrese telefono: ");
        string telefono = Console.ReadLine();
        Persona per = new Persona(id, dni, nombre, apellido, email, telefono);
        return per;
    }

    public bool PersonaExiste(int id)
    {
        foreach (Persona p in ListarPersonas())
            if (id == p.Id)
                return true;

        return false;
    }
}