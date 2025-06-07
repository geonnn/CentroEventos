using Microsoft.EntityFrameworkCore;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Repositorios;

public class CentroEventosContext : DbContext
{
    public DbSet<Persona> Personas { get; set; }
    public DbSet<EventoDeportivo> EventosDeportivos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=../CentroEventos.Repositorios/CentroEventos.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Persona>().HasIndex(d => d.Dni).IsUnique();
        modelBuilder.Entity<Persona>().HasIndex(e => e.Email).IsUnique();
        modelBuilder.Entity<Usuario>().HasIndex(e => e.Email).IsUnique();
    }
}
