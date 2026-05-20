using System;
using System.Collections.Generic;
using System.Text;
using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Dominio.Entities
{
    public abstract class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Responsable { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaFinTarea { get; set; } = DateTime.Now;
        public PrioridadTarea Prioridad { get; set; }
        public string? MotivoCancelacion { get; set; } = string.Empty;
        public EstadoTarea Estado { get; set; }
        private string _motivoCancelacion;
        public int UsuarioId { get; set; } 

        public Tarea()
        {

        }

        public Tarea(int id,string titulo, string descripcion,string responsable, DateTime FechaCreacion, DateTime? FechaFinTarea, PrioridadTarea prioridad, string? motivacionCancelacion, EstadoTarea estado, int usuarioId)
        {
            if (string.IsNullOrWhiteSpace(titulo)) throw new ArgumentException("El título es obligatorio", nameof(titulo));
            this.Id = id;
            this.Titulo = titulo.Trim();
            this.Descripcion = descripcion?.Trim() ?? string.Empty;
            this.Responsable = responsable;
            this.FechaCreacion = DateTime.Now;
            this.FechaFinTarea = null;
            this.Prioridad = prioridad;
            this.Estado = EstadoTarea.Pendiente;
            this.MotivoCancelacion = motivacionCancelacion ?? string.Empty;
            this.UsuarioId = usuarioId;
        }

        public bool Iniciar()
        {
            if (Estado == EstadoTarea.Pendiente)
            {
                Estado = EstadoTarea.EnProgreso;
                return true;
            }
            return false;
        }

        public bool Completar()
        {
            if (Estado != EstadoTarea.Completada || Estado != EstadoTarea.Cancelada)
            {
                Estado = EstadoTarea.Completada;
                FechaFinTarea = DateTime.Now;
                return true;
            }
            return false;
        }

        public bool Cancelar(string motivo)
        {
            if (Estado != EstadoTarea.Cancelada)
            {
                Estado = EstadoTarea.Cancelada;
                _motivoCancelacion = motivo ?? "Sin especificar";
                return true;
            }
            return false;
        }

        public string ObtenerMotivoCancelacion()
        {
            return _motivoCancelacion;
        }

        public bool HacerTareaUrgente(string responsable)
        {
            if (string.IsNullOrEmpty(this.Responsable)) throw new ArgumentException("A la tarea le falta asignarle un responsable");
            if (Estado != EstadoTarea.Completada && Estado != EstadoTarea.Cancelada)
            {
                this.Prioridad = PrioridadTarea.Alta;
            }

            return false;
        }

        public abstract string ObtenerResumen();
    }
}
