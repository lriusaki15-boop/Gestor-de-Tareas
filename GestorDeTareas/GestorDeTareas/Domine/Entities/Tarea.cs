using System;
using System.Collections.Generic;
using System.Text;
using static GestorDeTareas.Domine.Enums.Enumerados;

namespace GestorDeTareas.Domine.Entities
{
    public abstract class Tarea
    {
   
        public int Id { get; }
        public string Titulo { get; }
        public string Descripcion { get; }
        public string Responsable { get; }
        public DateTime FechaCreacion { get; }
        public DateTime? FechaFinTarea { get; private set; }
        public PrioridadTarea Prioridad { get; private set; }
        public string? MotivoCancelacion { get; }
        public EstadoTarea Estado { get; private set; }
        private string _motivoCancelacion;
        

        public Tarea(int id,string titulo, string descripcion,string responsable, DateTime FechaCreacion, DateTime? FechaFinTarea, PrioridadTarea prioridad, string? motivacionCancelacion, EstadoTarea estado)
        {
            if (string.IsNullOrWhiteSpace(titulo)) throw new ArgumentException("El título es obligatorio", nameof(titulo));
            //Añadir comprobacion de que la fecha fin no sea menor que la fecha de creacion o igual y que podamos controlar si esta finalizada
            //entonces con eso podremos saber si tiene fecha fin o no
            this.Id = id;
            this.Titulo = titulo.Trim();
            this.Descripcion = descripcion?.Trim() ?? string.Empty;
            this.Responsable = responsable;
            this.FechaCreacion = DateTime.Now;
            this.FechaFinTarea = null;
            this.Prioridad = prioridad;
            this.Estado = EstadoTarea.Pendiente;
            this.MotivoCancelacion = motivacionCancelacion ?? string.Empty;
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
