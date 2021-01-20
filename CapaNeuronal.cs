using System;
using System.Collections.Generic;
using System.Text;

namespace RedesNeuronalesConsola
{
    class CapaNeuronal : CapaNeuronalAbstracta
    {
        private CapaNeuronalAbstracta capaSiguiente;
        private CapaNeuronalAbstracta capaAntarior;

        public CapaNeuronal(int cantidad, CapaNeuronalAbstracta entrada)
        {
            neuronas = new Neurona[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                neuronas[i] = new Neurona(entrada.getNeuronas());
            }
        }
    }
}
