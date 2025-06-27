using NUnit.Framework;
using PruebaColaPrioridad;

namespace PruebaColaPrioridad.Tests
{
    public class ColaPrioridadTests
    {
        private ColaPrioridad _cola;

        [SetUp]
        public void Setup()
        {
            _cola = new ColaPrioridad();
        }

        [Test]
        public void Encolar_AgregaElemento_ColaNoEstaVacia() // Verifica que al encolar un elemento, la cola ya no está vacía cubre Encolar y IsEmpty
        {
            _cola.Encolar("Tarea 1", 1);
            Assert.IsFalse(_cola.IsEmpty());
        }

        [Test]
        public void Desencolar_DevuelveElementoMayorPrioridad() // Verifica que se desencole el de mayor prioridad (menor número), cubre logica de comparación en Desencolar
        {
            _cola.Encolar("Tarea 1", 2);
            _cola.Encolar("Tarea 2", 1);

            string desencolado = _cola.Desencolar();

            Assert.AreEqual("Tarea 2", desencolado);
        }

        [Test]
        public void GetMayorPrioridad_DevuelveCorrectoSinEliminar() // cubre getMayorPrioridad, Verifica que se obtenga el de mayor prioridad y que el elemento no fue eliminado
        {
            _cola.Encolar("Tarea 1", 2);
            _cola.Encolar("Tarea 2", 1);

            string mayorPrioridad = _cola.getMayorPrioridad();

            Assert.AreEqual("Tarea 2", mayorPrioridad);
            Assert.IsFalse(_cola.IsEmpty());
        }

        [Test]
        public void IsEmpty_DevuelveTrueCuandoNoHayElementos() // cubre que IsEmpty este vacio
        {
            Assert.IsTrue(_cola.IsEmpty());
        }

        [Test]
        public void Desencolar_EliminaElementoDeMayorPrioridad() // Verifica que el elemento de mayor prioridad fue eliminado
        {
            _cola.Encolar("Tarea 1", 1);
            _cola.Encolar("Tarea 2", 2);

            _cola.Desencolar();
            string mayorPrioridad = _cola.getMayorPrioridad();

            Assert.AreEqual("Tarea 2", mayorPrioridad);
        }

        [Test]
        public void Desencolar_PrioridadIgual_RespetaOrdenDeLlegada() // Test de prioridad igual + orden de llegada
        {
            _cola.Encolar("Tarea 1", 1);
            _cola.Encolar("Tarea 2", 1);

            string primero = _cola.Desencolar();
            Assert.AreEqual("Tarea 1", primero);
        }

        [Test]
        public void Desencolar_ColaVacia_LanzaExcepcion() // Cubre el caso en que Desencolar se llama sin elementos
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _cola.Desencolar());
        }

        [Test]
        public void GetMayorPrioridad_ColaVacia_LanzaExcepcion() // Cubre el caso en que getMayorPrioridad se llama sin elementos
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _cola.getMayorPrioridad());
        }

    }
}
