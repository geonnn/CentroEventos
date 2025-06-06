﻿namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

public class RepositorioReservaTXT : IRepositorioReserva
{
    readonly IIdGetter _idGetter;
    readonly IFileManager _fileManager;
    readonly string _archReservas = "../../../../CentroEventos.Repositorios/txt_files/reservas.txt";
    readonly string _archUltimaId = "../../../../CentroEventos.Repositorios/txt_files/ultima_id_reservas.txt";

    public RepositorioReservaTXT(IIdGetter idg, IFileManager fm)
    {
        _idGetter = idg;
        _fileManager = fm;
        _fileManager.InicializarArchivo(_archUltimaId);
        _fileManager.InicializarRepo(_archReservas);
        
    }

    public void AgregarReserva(Reserva reserva)
    {
        using StreamWriter sw = new StreamWriter(_archReservas, true);
        sw.WriteLine(reserva.ToStringParaTXT(_idGetter.GetNuevoId(_archUltimaId)));
    }

    public void EliminarReserva(int id)
    {
        List<Reserva> reservas = ListarReservas();
        reservas.RemoveAt(reservas.FindIndex(p => p.Id == id));
        using StreamWriter sw = new StreamWriter(_archReservas, false);
        reservas.ForEach(r => sw.WriteLine(r.ToStringParaTXT()));
    }

    public void ModificarReserva(Reserva nuevaReserva)
    {
        List<Reserva> reservas = ListarReservas();

        int index = reservas.FindIndex(r => r.Id == nuevaReserva.Id);
        reservas[index] = nuevaReserva;

        using StreamWriter sw = new StreamWriter(_archReservas, false);
        reservas.ForEach(r => sw.WriteLine(r.ToStringParaTXT()));
    }

    public List<Reserva> ListarReservas()
    {
        using var sr = new StreamReader(_archReservas);
        Reserva r;
        List<Reserva> listaReserva = new List<Reserva> { };
        while (!sr.EndOfStream)
        {
            int Id = int.Parse(sr.ReadLine() ?? "");
            int PersonaId = int.Parse(sr.ReadLine() ?? "");
            int EventoDeportivoId = int.Parse(sr.ReadLine() ?? "");
            DateTime FechaAltaReserva = DateTime.Parse(sr.ReadLine() ?? "");
            EstadoAsistencia Estado = Enum.Parse<EstadoAsistencia>(sr.ReadLine() ?? "");
            r = new Reserva(Id, PersonaId, EventoDeportivoId, FechaAltaReserva, Estado);
            listaReserva.Add(r);
        }
        return listaReserva;
    }

    public bool PersonaTieneReserva(int id)
        => ListarReservas().Exists(r => r.PersonaId == id);

    public bool EventoTieneReserva(int id)
        => ListarReservas().Exists(r => r.EventoDeportivoId == id);

    public bool PersonaReservoEvento(int pId, int eId)
        => ListarReservas().Exists(r => r.PersonaId == pId && r.EventoDeportivoId == eId);

    public bool EventoTieneCupo(int eId, int cupoMax)
        => ListarReservas().FindAll(e => e.Id == eId).Count < cupoMax;

    public bool ReservaExiste(int id)
        => ListarReservas().Exists(r => r.Id == id);
}
