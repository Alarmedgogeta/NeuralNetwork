using System;
using System.Collections.Generic;
using System.Text;

namespace RedesNeuronalesConsola
{
    class CapaNeuronalEntrada : CapaNeuronalAbstracta
    {
        private CapaNeuronal capaSiguiente;
        private double[] valoresIniciales;

        public CapaNeuronalEntrada(double[] valoresIniciales)
        {
            this.valoresIniciales = valoresIniciales;
            neuronas = new NeuronaEntrada[valoresIniciales.Length];
            for (int i = 0; i < valoresIniciales.Length; i++)
            {
                neuronas[i] = new NeuronaEntrada(valoresIniciales);
            }
        }
        public void setValores(double[] valoresIniciales)
        {
            this.valoresIniciales = valoresIniciales;
            foreach (NeuronaEntrada neurona in neuronas)
            {
                neurona.setValoresDeEntrada(valoresIniciales);
            }
        }
    }
}
