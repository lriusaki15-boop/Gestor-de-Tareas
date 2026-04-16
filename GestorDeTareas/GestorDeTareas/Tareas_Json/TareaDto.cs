using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GestorDeTareas.Tareas_Json
{
    public class TareaDto
    {
        public enum PrioridadTarea { Baja, Media, Alta }
        public enum EstadoTarea { Pendiente, EnProgreso, Completada, Cancelada }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Responsable { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaFinTarea { get; set; }
        public PrioridadTarea Prioridad { get; set; }
        public EstadoTarea Estado { get; set; }
        public string? MotivoCancelacion { get; set; }
        public  List<TareaDto>? SubTareas { get; set; }

        public TareaDto(int id, string titulo, string descripcion,string responsable, DateTime fechaCreacion, DateTime? fechaFinTarea, PrioridadTarea prioridad, EstadoTarea estado, string? motivacionCancelacion, List<TareaDto>? subTareas)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Descripcion = descripcion;
            this.Responsable = responsable;
            this.FechaCreacion = fechaCreacion;
            this.FechaFinTarea = fechaFinTarea;
            this.Prioridad = prioridad;
            this.MotivoCancelacion = motivacionCancelacion;
            this.SubTareas = subTareas;
            this.Estado = estado;
        }

        //public bool Guardar(List<TareaDto> tareaNueva)
        //{
        //    string json = JsonSerializer.Serialize(tareaNueva);
        //    Console.WriteLine(json);

        //    File.WriteAllText("Tarea.json", json);
        //    return true;
        //}
    }
}
