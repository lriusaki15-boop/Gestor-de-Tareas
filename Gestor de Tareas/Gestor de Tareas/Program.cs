using Gestor_de_Tareas;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using static Gestor_de_Tareas.Tarea;

/*Ejercicio 1
 * try
{
    var tarea = new Tarea(
    titulo: "Implementar login",
    fechaLimite: DateTime.Today.AddDays(7),
    prioridad: PrioridadTarea.Alta,
    descripcion: "Formulario con validación de credenciales"
    );

    Console.WriteLine("Tarea creada:");
    Console.WriteLine(tarea);
    Console.WriteLine($"Días restantes: {tarea.DiasRestantes}");

    bool iniciada = tarea.Iniciar();
    Console.WriteLine($"Iniciada: {iniciada}");
    Console.WriteLine($"Estado: {tarea.Estado}");

    // Intentar iniciar de nuevo
    bool reintento = tarea.Iniciar(); // → false
    Console.WriteLine($"Reintento: {reintento}");

    tarea.Completar();
    Console.WriteLine($"Estado final: {tarea.Estado}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error de negocio: {ex.Message}");
}*/

/*Ejercicio 2
 * Empleado datosEmpleado = new Empleado("Miguel", "Desarrollo", 1500m);
EmpleadoPorHoras datosEmpleadoPorHoras = new EmpleadoPorHoras("Miguel", "Desarrollo", 1500m, 6, 100m);
Console.WriteLine(datosEmpleado.ObtenerSalario() + " " + datosEmpleadoPorHoras.ObtenerSalario());*/

/* Ejercico 3
var empleados = new List<Empleado> { new Empleado("Miguel", "Recursos Humanos", 1500m),
    new Comercial("Alberto", "Comercial", 1500m, 8),
    new Desarrollador("Maria", "Desarrollo", 1500m,5)
};

foreach (var empleado in empleados)
    Console.WriteLine($"{empleado.Nombre} - {empleado.Departamento}: {empleado.CalcularBonificacion():C}");
*/
/* Ejercicio 4
var archivos = new List<Generador_Reporte> { new ReportePDF("Programacion para Tontos"), new ReporteExcell("Excell para TONTOS") };

foreach (var archivo in archivos)
    Console.WriteLine($"PDF generado:{archivo.Generar(8)}---- Excell Generado:{archivo.Generar(5)}");
*/

/*Ejercicio 5
MotorNotificacion notificaciones = new MotorNotificacion();
var listaNotificaciones = new List<INotificable> { new NotificadorEmail("server.com"), new NotificadorSMS("546484684", "+34") };
notificaciones.EnviarATodos(listaNotificaciones, "Mensaje estandar", "Esto es un mensaj de tu fencomputadora");*/

/* Ejercicio 6
HistorialDeNavegacion historia = new HistorialDeNavegacion();
historia.Navegar("Estoy en la parte de atras");
Console.WriteLine($"Esto es adelante: {historia.Adelante()}\nEsto es para atras: {historia.Atras()}");
historia.Navegar("Estoy en la parte de alant");
Console.WriteLine($"Esto es adelante: {historia.Adelante()}\nEsto es para atras: {historia.Atras()}");
historia.Navegar("Estoy en la parte de atrasante");
Console.WriteLine($"Esto es adelante: {historia.Adelante()}\nEsto es para atras: {historia.Atras()}");
historia.Navegar("Estoy en la parte de alante");
Console.WriteLine($"Esto es para atras: {historia.Atras()} \nEsto es adelante: {historia.Adelante()}");*/


/*Ejercicio 7 (Funciona)
var libroNuevo = new Libro(1,"Las Mil y una Maravillas de la Noche", "Desconocido",365,true);
var serializer = new XmlSerializer(typeof(Libro));

using var writer = new StreamWriter("C:\\Users\\Oceano\\Desktop\\Proyecto\\Gestor de Tareas\\Gestor de Tareas\\libro.xml");
serializer.Serialize(writer, libroNuevo);
writer.Close();
Console.WriteLine("Libro guardado en libro.xml");
Console.WriteLine("Se va a leer los datos de libro.xml");

var reader = new StreamReader("C:\\Users\\Oceano\\Desktop\\Proyecto\\Gestor de Tareas\\Gestor de Tareas\\libro.xml");
var libroDeserializado = (Libro)serializer.Deserialize(reader);
reader.Close();

Console.WriteLine($" Id del libro: {libroDeserializado.Id}/n Titulo del LIbro {libroDeserializado.Titulo} /n" +
    $"Nombre del Autor: {libroDeserializado.Autor}/n Numero Total de paginas: {libroDeserializado.Paginas} /n" +
    $"Disponible: {libroDeserializado.Disponible}");*/


//Ejercicio 8 y 9 que seria ignorar uno de los campos para que no salga y se meta en el JSON
var persona = new List<Persona> { new Persona("Miguel", 28, "patatasasadas23@gmail.com"),
new Persona("Alberto",31,"hermanomediano56@gmail.com"), new Persona("Maria",33,"lamayormola98@gmail.com")};
string json = JsonSerializer.Serialize(persona);
Console.WriteLine(json);

File.WriteAllText("persona.json", json);
var opciones = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true
};

json = File.ReadAllText("persona.json");

var personaJson = JsonSerializer.Deserialize<List<Persona>>(json, opciones);

foreach (var personas in personaJson)
{
    Console.WriteLine($"Nombre: {personas.Nombre}");
    Console.WriteLine($"Edad: {personas.Edad}");
    Console.WriteLine($"Email: {personas.Email}");
}