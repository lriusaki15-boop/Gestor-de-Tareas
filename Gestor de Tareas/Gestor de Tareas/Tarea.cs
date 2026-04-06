using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal class Tarea
    {
        public enum PrioridadTarea
        {
            Baja,
            Media,
            Alta
        }

        public enum EstadoTarea
        {
            Pendiente,
            EnProgreso,
            Completada,
            Cancelada
        }

        public Guid Id { get; }
        public string Titulo { get; }
        public string Descripcion { get; }
        public DateTime FechaCreacion { get; }
        public DateTime FechaLimite { get; }
        public PrioridadTarea Prioridad { get; }
        private EstadoTarea _estado;
        public EstadoTarea Estado => _estado;
        private string _motivoCancelacion;

        public Tarea (string titulo ,DateTime fechaLimite, PrioridadTarea prioridad, string descripcion)
        {
            if (string.IsNullOrWhiteSpace(titulo))throw new ArgumentException("El título es obligatorio", nameof(titulo));
            if (fechaLimite.Date<DateTime.Today) throw new ArgumentException("La fecha límite no puede ser anterior a hoy");

            Id = Guid.NewGuid();
            Titulo = titulo.Trim();
            Descripcion = descripcion?.Trim() ?? string.Empty;
            FechaCreacion = DateTime.Now;
            FechaLimite = fechaLimite.Date;
            Prioridad = prioridad;
            _estado = EstadoTarea.Pendiente;
        }

        public int DiasRestantes => (FechaLimite - DateTime.Today).Days;

        public bool EstaVencida =>
        _estado != EstadoTarea.Completada &&
        _estado != EstadoTarea.Cancelada &&
        DateTime.Today > FechaLimite;

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

        public override string ToString()
        {
           return $"Tarea {Id.ToString()[..8]} | {Titulo} | " + $"Limite: {FechaLimite:dd/MM/yy} | " + $"Prioridad: {Prioridad} | {_estado}" + (EstaVencida ? " [VENCIDA]" : "");
        }
    }
}
