namespace CentroEventos.Aplicacion.Entidades;

public class Persona
{
    public int Id { get; private set; } // único
    public string Dni { get; private set; } // único
    public string Nombre { get; private set; }
    public string Apellido { get; private set; }
    public string Email { get; private set; } // único
    public string? Telefono { get; private set; }
    public List<Reserva>? Reservas { get; private set; } // nav con entity framework

    // Constructor vacío para Entity Framework
    #nullable disable
    protected Persona() { }
    #nullable enable

    public Persona(string dni, string nom, string ap, string email, string? tel = "")
    {
        this.Dni = dni;
        this.Nombre = nom;
        this.Apellido = ap;
        this.Email = email;
        this.Telefono = tel;
        // this.Reservas = new();
    }

    public void Actualizar(Persona p)
    {
        this.Dni = p.Dni;
        this.Nombre = p.Nombre;
        this.Apellido = p.Apellido;
        this.Email = p.Email;
        this.Telefono = p.Telefono;
    }

    public override string ToString()
    {
        return $"Persona [Id: {Id}, Dni: {Dni}, Nombre: {Nombre}, Apellido: {Apellido}, Email: {Email}, Telefono: {Telefono}]";
    }
}