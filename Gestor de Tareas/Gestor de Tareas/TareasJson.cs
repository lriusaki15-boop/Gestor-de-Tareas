using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Gestor_de_Tareas
{
    internal class TareasJson
    {
        const string ruta = "Tareas.json";
        public void GuardarDatosJson(TareaDto tareas)
        {
            string json = JsonSerializer.Serialize(tareas);
            File.WriteAllText("Tareas.json", json);
        }
         public List<TareaDto> RecuperarDatos()
        {
            var opciones = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            };
            string json = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<List<TareaDto>>(json, opciones) ?? new();
        }
    }
}
