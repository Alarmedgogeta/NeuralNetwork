using System;
using System.Collections.Generic;
using System.Text;

namespace RedesNeuronalesConsola
{
    abstract class CapaNeuronalAbstracta
    {
        protected NeuronaAbstracta[] neuronas;
        public NeuronaAbstracta[] getNeuronas()
        {
            return neuronas;
        }
        public void propagarResultado()
        {
            foreach (NeuronaAbstracta neurona in neuronas)
            {
                neurona.propagarResultado();
            }
        }
        public void actualizarErrores()
        {
            foreach (NeuronaAbstracta neurona in neuronas)
            {
                neurona.actualizarError();
            }
        }
        public void actualizarPesos()
        {
            foreach (NeuronaAbstracta neurona in neuronas)
            {
                neurona.actualizarPesos();
            }
        }

        public bool tieneError()
        {
            foreach (NeuronaAbstracta neurona in neuronas)
            {
                if (neurona.getError() != 0)
                {
                    return true;
                }
            }
            return false;
        }
        public void imprimir()
        {
            Console.WriteLine("===========================================================================");
            for (int i = 0; i < neuronas.Length; i++)
            {
                Console.WriteLine("||-----------------------------------------------------------------------||");
                Console.WriteLine("||Neurona: \t\t\t\t\t\t\t\t" + i + "||");
                neuronas[i].imprimir();
                Console.WriteLine("||-----------------------------------------------------------------------||");
            }
            Console.WriteLine("===========================================================================");
        }
        public void imprimirSalidas()
        {
            Console.WriteLine("Resultados: ");
            for (int i = 0; i < neuronas.Length; i++)
            {
                Console.WriteLine("Neurona " + i + ": " + neuronas[i].getSalida());
            }
        }
        public void imprimirPesos()
        {
            Console.WriteLine("Pesos: ");
            for (int i = 0; i < neuronas.Length; i++)
            {
                Console.WriteLine("Neurona " + i + ": ");
                neuronas[i].imprimir();
            }
        }
    }
}
