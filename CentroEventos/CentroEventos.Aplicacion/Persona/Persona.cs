namespace CentroEventos.Aplicacion.Persona;

public class Persona
{
    public int Id { get; private set; } // único
    public string Dni { get; private set; } // único
    public string Nombre { get; private set; }
    public string Apellido { get; private set; }
    public string Email { get; private set; } // único
    public string Telefono { get; private set; }

    // Constructor con todos los parámetros.
    public Persona(int id, string dni, string nom, string ap, string email, string tel)
    {
        this.Id = id;
        this.Dni = dni;
        this.Nombre = nom;
        this.Apellido = ap;
        this.Email = email;
        this.Telefono = tel;
    }

    // Constructor sin teléfono.
    public Persona(int id, string dni, string nom, string ap, string email)
        : this(id, dni, nom, ap, email, "")
    { }

    // Constructor sin ID.
    public Persona(string dni, string nom, string ap, string email, string tel)
        : this(0, dni, nom, ap, email, tel)
    { }

    // Constructor sin ID ni teléfono.
    public Persona(string dni, string nom, string ap, string email) 
        : this(0, dni, nom, ap, email, "")
    { }

    public override string ToString()
    {
        return $"Id: {Id}, Dni: {Dni}, Nombre: {Nombre}, Apellido: {Apellido}, Email: {Email}, Telefono: {Telefono}";
    }

    public string ToStringParaTXT()
    {
        return Id + "\n" +
               Dni + "\n" +
               Nombre + "\n" +
               Apellido + "\n" +
               Email + "\n" +
               Telefono;
    }

    public string ToStringParaTXT(int id)
    {
        return id + "\n" +
               Dni + "\n" +
               Nombre + "\n" +
               Apellido + "\n" +
               Email + "\n" +
               Telefono;
    }
}