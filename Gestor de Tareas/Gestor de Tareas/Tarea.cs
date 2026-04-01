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

        // Fecha límite con validación
        public DateTime FechaLimite { get; }

        // Prioridad protegida
        public PrioridadTarea Prioridad { get; }

        // Estado controlado
        private EstadoTarea _estado;
        public EstadoTarea Estado => _estado;

        // Detalle interno de cancelación
        private string _motivoCancelacion;

        public Tarea (string titulo ,DateTime fechaLimite, PrioridadTarea prioridad, string descripcion = null)
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

        // Días restantes: propiedad calculada
        public int DiasRestantes => (FechaLimite - DateTime.Today).Days;

        // ¿Ha superado la fecha límite sin completarse?
        public bool EstaVencida =>
        _estado != EstadoTarea.Completada &&
        _estado != EstadoTarea.Cancelada &&
        DateTime.Today > FechaLimite;

        // Iniciar la tarea
        public bool Iniciar()
        {
            if (_estado != EstadoTarea.Pendiente) return false;
            _estado = EstadoTarea.EnProgreso;
            return true;
        }

        // Completar la tarea
        public bool Completar()
        {
            if (_estado == EstadoTarea.Completada ||
            _estado == EstadoTarea.Cancelada) return false;
            _estado = EstadoTarea.Completada;
            return true;
        }

        // Cancelar con motivo
        public bool Cancelar(string motivo)
        {
            if (_estado == EstadoTarea.Cancelada) return false;
            _estado = EstadoTarea.Cancelada;
            _motivoCancelacion = motivo ?? "Sin especificar";
            return true;
        }

        public override string ToString()
        => $"Tarea {Id.ToString()[..8]} | {Titulo} | " +
        $"Limite: {FechaLimite:dd/MM/yy} | " +
        $"Prioridad: {Prioridad} | {_estado}" +
        (EstaVencida ? " [VENCIDA]" : "");
    }
}
