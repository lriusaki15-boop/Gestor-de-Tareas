using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal class HistorialDeNavegacion
    {
        private readonly Stack<string> _atras = new();
        private readonly Stack<string> _adelante = new();
        private string _actual = string.Empty;

        public string PaginaActual => _actual;

        public void Navegar(string url)
        {
            if (!string.IsNullOrEmpty(_actual))
                _atras.Push(_actual);
            _actual = url;
            _adelante.Clear();
            Console.WriteLine("Pagina Actual:" + _actual);
            //Console.WriteLine("Pagina Anteriro:" +string.Join(_atras.ToString())); esta mal el join pero deberia funcionar
            Console.WriteLine("Pagina Posterior:" + _adelante.ToString());
        }

        public bool Atras()
        { 
            if(_atras.Count == 0 && !string.IsNullOrEmpty(_actual)) return false;
            _adelante.Push(_actual);
            _actual = _atras.Pop();
            return true;
        }
        public bool Adelante()
        {
            if (_adelante.Count == 0 && !string.IsNullOrEmpty(_actual)) return false;
            _atras.Push(_actual);
            _actual = _adelante.Pop();
            return true;
        }
    }
}
