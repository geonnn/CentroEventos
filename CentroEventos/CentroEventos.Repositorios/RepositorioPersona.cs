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

    public void BajaPersona(int id)
    {
        using var context = new CentroEventosContext();
        // context.Personas.Remove(persona);
        context.Personas.Remove(context.Personas.Where(p => p.Id == id).Single());
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
        using var context = new CentroEventosContext();
        context.Personas.Update(nuevaPersona);
        context.SaveChanges();
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

    public bool PersonaExiste(int id){
        using var context = new CentroEventosContext();
        return context.Personas.Any(p => p.Id == id);
    }

    public bool DniExiste(string dni){
        using var context = new CentroEventosContext();
        return context.Personas.Any(p => p.Dni == dni);
    }

    public bool EmailExiste(string email)
    {
        using var context = new CentroEventosContext();
        return context.Personas.Any(p => p.Email == email);
    }
}