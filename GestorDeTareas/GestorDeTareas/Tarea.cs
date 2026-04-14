using System;
using System.Collections.Generic;
using System.Text;

namespace GestorDeTareas
{
    internal abstract class Tarea
    {
        public enum PrioridadTarea { Baja, Media, Alta }
        public enum EstadoTarea { Pendiente, EnProgreso, Completada, Cancelada }
        public int Id { get; }
        public string Titulo { get; }
        public string Descripcion { get; }
        public string Responsable { get; }
        public DateTime FechaCreacion { get; }
        public DateTime? FechaFinTarea { get; set; }
        public PrioridadTarea Prioridad { get; set; }
        private EstadoTarea _estado;
        public string? MotivoCancelacion { get; }
        public List<TareaDto>? SubTareas { get; }
        public EstadoTarea Estado => _estado;
        private string _motivoCancelacion;
        

        protected Tarea(int id,string titulo, string descripcion,string responsable, DateTime FechaCreacion, PrioridadTarea prioridad, EstadoTarea estado, string? motivacionCancelacion)
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
            this._estado = EstadoTarea.Pendiente;
            this.MotivoCancelacion = motivacionCancelacion ?? string.Empty;
        }

        public bool Iniciar()
        {
            if (_estado != EstadoTarea.Pendiente) return false;
            _estado = EstadoTarea.EnProgreso;
            return true;
        }

        public bool Completar()
        {
            if (_estado == EstadoTarea.Completada || _estado == EstadoTarea.Cancelada) return false;
            _estado = EstadoTarea.Completada;
            FechaFinTarea = DateTime.Now;
            return true;
        }

        public bool Cancelar(string motivo)
        {
            if (_estado == EstadoTarea.Cancelada) return false;
            _estado = EstadoTarea.Cancelada;
            _motivoCancelacion = motivo ?? "Sin especificar";
            return true;
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

        public override string ToString()
        {
            return $"Tarea {Id.ToString()[..8]} | {Titulo} | | Prioridad: {Prioridad} | {_estado}";
        }
    }
}
