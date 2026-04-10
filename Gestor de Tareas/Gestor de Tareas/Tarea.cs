using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal abstract class Tarea
    {
        public enum PrioridadTarea { Baja, Media, Alta }
        public enum EstadoTarea { Pendiente, EnProgreso, Completada, Cancelada }
        public int Id { get; }
        public string Titulo { get; }
        public string Descripcion { get; }
        public DateTime FechaCreacion { get; }
        public DateTime FechaLimite { get; }
        public DateTime FechaFinTarea { get; }
        public PrioridadTarea Prioridad { get; set; }
        private EstadoTarea _estado;
        public EstadoTarea Estado => _estado;
        private string _motivoCancelacion;
        public string Responsable { get; }
        private readonly List<Tarea> _subTareas = new();

        protected Tarea(int id,string titulo, DateTime fechaLimite, PrioridadTarea prioridad, string descripcion)
        {
            if (string.IsNullOrWhiteSpace(titulo)) throw new ArgumentException("El título es obligatorio", nameof(titulo));
            if (fechaLimite.Date < DateTime.Today) throw new ArgumentException("La fecha límite no puede ser anterior a hoy");

            this.Id = id;
            this.Titulo = titulo.Trim();
            this.Descripcion = descripcion?.Trim() ?? string.Empty;
            this.FechaCreacion = DateTime.Now;
            this.FechaLimite  = fechaLimite.Date;
            this.Prioridad = prioridad;
            this._estado = EstadoTarea.Pendiente;
        }

        public int DiasRestantes => (FechaLimite - DateTime.Today).Days;

        public bool EstaVencida => _estado != EstadoTarea.Completada && _estado != EstadoTarea.Cancelada && DateTime.Today > FechaLimite;

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

        public void AgregarSubtarea(Tarea subtarea) => _subTareas.Add(subtarea);

        public int TotalSubtareas => _subTareas.Count;
        public int SubtareasCompletadas => _subTareas.Count(subTareas => subTareas.Estado == EstadoTarea.Completada);

        public abstract string ObtenerResumen();

        public override string ToString()
        {
            return $"Tarea {Id.ToString()[..8]} | {Titulo} | " + $"Limite: {FechaLimite:dd/MM/yy} | " + $"Prioridad: {Prioridad} | {_estado}" + (EstaVencida ? " [VENCIDA]" : "");
        }
    }
}
