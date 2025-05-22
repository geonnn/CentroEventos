# Sistema de gestión del Centro Deportivo Universitario

> Proyecto desarrollado para el Seminario de Lenguajes opción .NET – 1º Semestre 2025

---

## ⚙️ Cómo ejecutar y probar el proyecto

A continuación se muestra un ejemplo de cómo probar las funcionalidades desarrolladas desde `Program.cs`.

###  Inicializaciones

#### 🔹 Sistema de gestión de IDs y archivos

```csharp
IIdGetter idgetter = new IdGetter();
IFileManager filemanager = new FileManager();
```

#### 🔹 Servicio de autorización

```csharp
// Servicio de autorizacion (provisorio)
IServicioAutorizacion autorizador = new ServicioAutorizacion();
int Admin = 1;
int Usuario = 0;
```

#### 🔹 Repositorios

```csharp
IRepositorioPersona repoPersona = new RepositorioPersonaTXT(idgetter, filemanager);
IRepositorioEventoDeportivo repoEventoDeportivo = new RepositorioEventoDeportivoTXT(idgetter, filemanager);
IRepositorioReserva repoReserva = new RepositorioReservaTXT(idgetter, filemanager);
```

#### 🔹 Validadores

```csharp
PersonaValidador validadorPersona = new PersonaValidador(repoPersona, repoEventoDeportivo, repoReserva);
EventoDeportivoValidador validadorEvento = new EventoDeportivoValidador(repoPersona, repoReserva);
ReservaValidador validadorReserva = new ReservaValidador(repoPersona, repoEventoDeportivo, repoReserva);
```

#### 🔹 Casos de uso para entidad Persona

```csharp
var agregarPersona = new AgregarPersonaUseCase(repositorioPersona, servicioAutorizacion);
var eliminarPersona = new EliminarPersonaUseCase(repoPersona, validadorPersona, servicioAutorizacion);
var modificarPersona = new ModificarPersonaUseCase(repoPersona, validadorPersona, servicioAutorizacion);
var listarPersonas = new ListarPersonaUseCase(repoPersona);
```

#### 🔹 Casos de uso para entidad EventoDeportivo

```csharp
var agregarEventoDeportivo = new AgregarEventoDeportivoUseCase(repositorioEventoDeportivo, servicioAutorizacion);
var eliminarEventoDeportivo = new EliminarEventoDeportivoUseCase(repoEventoDeportivo, validadorEventoDeportivo, servicioAutorizacion);
var modificarEventoDeportivo = new ModificarEventoDeportivoUseCase(repoEventoDeportivo, validadorEventoDeportivo, servicioAutorizacion);
var listarEventosDeportivos = new ListarEventoDeportivoUseCase(repoEventoDeportivo);
var listarEventosConCupoDisponible = new ListarEventosConCupoDisponibleUseCase(repositorioEventoDeportivo, repositorioReserva);
var listarAsistenciaAEvento = new ListarAsistenciaAEventoUseCase(repoEventoDeportivo, repositorioReserva, repositorioPersona);
```

#### 🔹 Casos de uso para entidad Reserva

```csharp
var agregarReserva = new AgregarReservaUseCase(repositorioReserva, servicioAutorizacion);
var eliminarReserva = new EliminarReservaUseCase(repoReserva, validadorReserva, servicioAutorizacion);
var modificarReserva = new ModificarReservaUseCase(repoReserva, validadorReserva, servicioAutorizacion);
var listarReservas = new ListarReservaUseCase(repoReserva);
```

---

### ▶️ Ejecución de los casos de uso

Para ejecutar los casos de uso estos deben estar dentro de un bloque **try**, seguido de un bloque **catch** para manejar las posibles excepciones:

- `ValidacionException`
- `EntidadNotFoundException`
- `CupoExcedidoException`
- `DuplicadoException`
- `OperacionInvalidaException`
- `FalloAutorizacionException`

---

```csharp
try
{
    // Ejecución de casos de uso

    // Persona

    agregarPersona.Ejecutar(new Persona("DNI", "Nombre", "Apellido", "email@gmail.com", "teléfono"), Autorizacion);
    // También se pueden crear personas sin teléfono:
    agregarPersona.Ejecutar(new Persona("DNI", "Nombre", "Apellido", "email@gmail.com"), Autorizacion); 

    eliminarPersona.Ejecutar(int idPersona, Autorizacion);

    modificarPersona.Ejecutar(new Persona(int idPersonaAModificar, "DNI", "Nombre", "Apellido", "email@gmail.com", "teléfono"), Autorizacion); // también se puede modificar sin teléfono.

    listarPersona.Ejecutar(); // No requiere autorización.
    // Fin Persona ------------------------------------------------

    // Evento Deportivo

    agregarEventoDeportivo.Ejecutar(new EventoDeportivo("Nombre", "Descripción", DateTime fechaInicio, double duracion, int cupoMáximo, int responsableId), Autorizacion);

    eliminarEventoDeportivo.Ejecutar(idEventoDeportivo, Autorizacion);

    modificarEventoDeportivo.Ejecutar(new EventoDeportivo(int idEventoAModificar, "Nombre", "Descripción", DateTime fechaInicio, double duracion, int cupoMáximo, int responsableId), Autorizacion); // también se puede modificar sin teléfono.

    listarEventoDeportivo.Ejecutar(); // No requiere autorización.

    listarEventosConCupoDisponible.Ejecutar();

    listarAsistenciaAEvento.Ejecutar(int idEventoAConsultar);
    // Fin Evento Deportivo ------------------------------------------------

    // Reserva

    agregarReserva.Ejecutar(new Reserva(int idPersona, int idEventoDeportivo, DateTime fechaAltaReserva, EstadoAsistencia estado), Autorizacion);

    eliminarReserva.Ejecutar(int idReserva, Autorizacion);

    modificarReserva.Ejecutar(new Reserva(int idReservaAModificar, int personaId, int eventoDeportivoId, DateTime fechaAltaReserva, EstadoAsistencia estado)); // también se puede modificar sin teléfono.

    listarReserva.Ejecutar(); // No requiere autorización.
    // Fin Reserva ------------------------------------------------

}
catch (Exception e)
{
    Console.WriteLine($"Excepción {e}:" + e.Message);
}

// Las excepciones también pueden manejarse individualmente con bloques catch específicos.
```
---

## 💾 Repositorios

Los datos se almacenan en archivos de texto plano. Cada entidad tiene su propio archivo para la permanencia de datos y gestión de IDs, que se autogeneran de manera incremental y no reutilizable.

La ruta de los archivos se guarda en una variable de instancia en su respectivo repositorio.
Los archivos de texto actualmente se almacenan en CentroEventos\CentroEventos.Repositorios\txt_files. Los mismos se generan automáticamente durante la ejecución del programa.

---

## 👥 Autores

`👨‍💻 Gil, Gonzalo` **-** `👨‍💻 Hassan, Ignacio` **-** `👨‍💻 Lara, Gabriel`

---
