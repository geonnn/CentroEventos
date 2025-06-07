namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;


public class RepositorioPersona : IRepositorioPersona
{

    public RepositorioPersona() { }

    public void AltaPersona(Persona persona)
    {
        using var context = new CentroEventosContext();
        context.Add(persona);
        context.SaveChanges();
    }

    public void BajaPersona(Persona persona)
    {
        using var context = new CentroEventosContext();
        context.Personas.Remove(persona);
        context.SaveChanges();
    }

    public List<Persona> ListarPersonas()
    {
        var lista = new List<Persona>();

        using (var context = new CentroEventosContext())
        foreach (var p in context.Personas)
            lista.Add(p);
        return lista;
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