# Sistema de Gestión del Centro Deportivo Universitario

> Proyecto desarrollado para el Seminario de Lenguajes opción .NET – 1º Semestre 2025

---

## 📂 Estructura del Proyecto

Este proyecto se desarrolla bajo los principios de **Arquitectura Limpia**, separado en tres proyectos dentro de la solución `CentroEventos`:

- `CentroEventos.Aplicacion`: contiene lógica de negocio, entidades, validadores, casos de uso e interfaces.
- `CentroEventos.Repositorios`: contiene implementaciones de persistencia con archivos planos.
- `CentroEventos.Consola`: aplicación de consola para probar los casos de uso.

---

## ⚙️ Cómo Ejecutar y Probar el Proyecto

A continuación se muestra un ejemplo de cómo probar las funcionalidades desarrolladas desde `Program.cs`.

### 🔹 Crear una Persona

```csharp
var personaUseCase = new PersonaAltaUseCase(repositorioPersona, servicioAutorizacion);
var persona = new Persona
{
    DNI = "12345678",
    Nombre = "Juan",
    Apellido = "Pérez",
    Email = "juan.perez@ejemplo.com",
    Telefono = "123456789"
};
personaUseCase.Ejecutar(persona, 1); // Usuario 1 tiene todos los permisos
Console.WriteLine("Persona creada exitosamente");
```

### 🔹 Crear un Evento Deportivo

```csharp
var eventoUseCase = new EventoDeportivoAltaUseCase(repositorioEvento, repositorioPersona, servicioAutorizacion);
var evento = new EventoDeportivo
{
    Nombre = "Clase de Spinning Avanzado",
    Descripcion = "Entrenamiento de alto rendimiento",
    FechaHoraInicio = DateTime.Now.AddDays(1),
    DuracionHoras = 1.5,
    CupoMaximo = 10,
    ResponsableId = 1
};
eventoUseCase.Ejecutar(evento, 1);
Console.WriteLine("Evento creado correctamente");
```

### 🔹 Hacer una Reserva

```csharp
var reservaUseCase = new ReservaAltaUseCase(repositorioReserva, repositorioEvento, repositorioPersona, servicioAutorizacion);
var reserva = new Reserva
{
    PersonaId = 1,
    EventoDeportivoId = 1
};
reservaUseCase.Ejecutar(reserva, 1);
Console.WriteLine("Reserva realizada correctamente");
```

### 🔹 Listar Eventos con Cupo Disponible

```csharp
var listarUseCase = new ListarEventosConCupoDisponibleUseCase(repositorioEvento, repositorioReserva);
var eventosDisponibles = listarUseCase.Ejecutar();
foreach (var ev in eventosDisponibles)
{
    Console.WriteLine(ev);
}
```

---

## 🧪 Casos de Uso Implementados

- Alta, baja, modificación y listado de:
  - Persona
  - EventoDeportivo
  - Reserva
- Listar eventos con cupo disponible
- Listar asistencia a evento

---

## 🔐 Servicio de Autorización

Se utiliza `ServicioAutorizacionProvisorio`, que responde de la siguiente manera:

- Si `IdUsuario == 1`, permite todas las operaciones.
- Para cualquier otro `IdUsuario`, no permite ninguna operación.

---

## 💾 Repositorios

Los datos se almacenan en archivos de texto plano. Cada entidad tiene su propio archivo para la permanencia de datos y gestión de IDs, que se autogeneran de manera incremental y no reutilizable.

---

## 🧱 Validaciones Aplicadas

### Persona
- DNI y Email únicos.
- Nombre, Apellido, DNI, Email no vacíos.

### EventoDeportivo
- Fecha de inicio futura.
- Nombre y descripción no vacíos.
- Cupo y duración mayor que cero.
- ResponsableId válido.

### Reserva
- No se permite reservar más de una vez el mismo evento.
- Verificación de existencia de persona y evento.
- Validación de cupo disponible.

---

## ❗ Excepciones Personalizadas

Se definen las siguientes clases de excepción:

- `ValidacionException`
- `EntidadNotFoundException`
- `CupoExcedidoException`
- `DuplicadoException`
- `OperacionInvalidaException`
- `FalloAutorizacionException`

---

## 👥 Autores

- Gil, Gonzalo
- Hassan, Ignacio
- Lara, Gabriel

---