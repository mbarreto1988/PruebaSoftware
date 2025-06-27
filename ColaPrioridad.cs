using System;
using System.Collections.Generic;

namespace PruebaColaPrioridad
{
    public class ColaPrioridad
    {
        private List<(string Item, int Priority)> _cola;

        public ColaPrioridad()
        {
            _cola = new List<(string, int)>();
        }

        public void Encolar(string item, int priority)
        {
            _cola.Add((item, priority));
        }

        public string Desencolar()
        {
            int highPriorityIndex = 0;
            for (int i = 1; i < _cola.Count; i++)
            {
                if (_cola[i].Priority < _cola[highPriorityIndex].Priority)
                {
                    highPriorityIndex = i;
                }
            }

            var highPriorityItem = _cola[highPriorityIndex].Item;
            _cola.RemoveAt(highPriorityIndex);

            return highPriorityItem;
        }

        public string getMayorPrioridad()
        {
            int highPriorityIndex = 0;
            for (int i = 1; i < _cola.Count; i++)
            {
                if (_cola[i].Priority < _cola[highPriorityIndex].Priority)
                {
                    highPriorityIndex = i;
                }
            }

            return _cola[highPriorityIndex].Item;
        }

        public bool IsEmpty()
        {
            return _cola.Count == 0;
        }
    }
}
