using System;

namespace PruebaColaPrioridad
{
    class Program
    {
        static void Main(string[] args)
        {
            ColaPrioridad cola = new ColaPrioridad();

            cola.Encolar("Tarea 1", 2);
            cola.Encolar("Tarea 2", 1);
            cola.Encolar("Tarea 3", 3);

            Console.WriteLine("Elemento de mayor prioridad: " + cola.getMayorPrioridad());

            while (!cola.IsEmpty())
            {
                Console.WriteLine("Desencolado: " + cola.Desencolar());
            }

            Console.WriteLine("Cola vacía: " + cola.IsEmpty());
        }
    }
}
