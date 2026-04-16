using GestorDeTareas.Clases_Tareas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace GestorDeTareas.Tareas_Json
{
    internal class TareasJson
    {
        const string ruta = "Tareas.json";
        public static void GuardarDatosJson(List<Tarea> tareas)
        {
            string json = JsonSerializer.Serialize(tareas);
            File.WriteAllText("Tareas.json", json);
        }
         public static List<TareaAction> RecuperarDatos()
        {
            var opciones = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                IncludeFields = true
            };
            string json = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<List<TareaAction>>(json, opciones) ?? new();
        }
    }
}
