namespace CentroEventos.Aplicacion.Persona;

public class Persona
{
    public int Id {get; } // único
    public string Dni {get; } // único
    public string Nombre {get;}
    public string Apellido {get;}
    public string Email {get;} // único
    public string Telefono {get;}

    public Persona(int id, string dni, string nom, string ap, string email, string tel)
    {
        this.Id = id;
        this.Dni = dni;
        this.Nombre = nom;
        this.Apellido = ap;
        this.Email = email;
        this.Telefono = tel;
    }    

    public override string ToString() {
        return $"Id: {Id}, Dni: {Dni}, Nombre: {Nombre}, Apellido: {Apellido}, Email: {Email}, Telefono: {Telefono}";
    }

}