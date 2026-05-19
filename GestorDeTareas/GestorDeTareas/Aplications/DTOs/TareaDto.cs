using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Aplications.DTOs
{
    public class TareaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Responsable { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaFinTarea { get; set; }
        public PrioridadTarea Prioridad { get; set; }
        public EstadoTarea Estado { get; set; }
        public string? MotivoCancelacion { get; set; }
        public  string? SubTareasId { get; set; }
        public int UsuarioId { get; set; }

        public TareaDto() { }

        public TareaDto(int id, string titulo, string descripcion, string responsable, DateTime fechaCreacion, DateTime? fechaFinTarea, PrioridadTarea prioridad, EstadoTarea estado, string? motivacionCancelacion, string? subTareasId, int usuarioId)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Descripcion = descripcion;
            this.Responsable = responsable;
            this.FechaCreacion = fechaCreacion;
            this.FechaFinTarea = fechaFinTarea;
            this.Prioridad = prioridad;
            this.MotivoCancelacion = motivacionCancelacion;
            this.SubTareasId = subTareasId;
            this.Estado = estado;
            this.UsuarioId = usuarioId;
        }

        public TareaDto(string titulo, string descripcion, string responsable, DateTime fechaCreacion, PrioridadTarea prioridad, EstadoTarea estado, int usuarioId)
        {
            this.Titulo = titulo;
            this.Descripcion = descripcion;
            this.Responsable = responsable;
            this.FechaCreacion = fechaCreacion;
            this.Prioridad = prioridad;
            this.Estado = estado;
            this.UsuarioId = usuarioId;
        }

        public TareaDto(int id, string titulo, string descripcion, string responsable, DateTime fechaCreacion, DateTime? fechaFinTarea, PrioridadTarea prioridad, EstadoTarea estado, string? motivoCancelacion, int usuarioId)
        {
            Id = id;
            Titulo = titulo;
            Descripcion = descripcion;
            Responsable = responsable;
            FechaCreacion = fechaCreacion;
            FechaFinTarea = fechaFinTarea;
            Prioridad = prioridad;
            Estado = estado;
            MotivoCancelacion = motivoCancelacion;
            UsuarioId = usuarioId;
        }
    }
}
