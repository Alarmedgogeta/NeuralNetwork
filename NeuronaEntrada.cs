using System;
using System.Collections.Generic;
using System.Text;

namespace RedesNeuronalesConsola
{
    class NeuronaEntrada : NeuronaAbstracta
    {
        public NeuronaEntrada(double[] valoresDeEntrada)
        {
            dendritas = new DendritaEntrada[valoresDeEntrada.Length];
            for (int i = 0; i < valoresDeEntrada.Length; i++)
            {
                dendritas[i] = new DendritaEntrada(this, valoresDeEntrada[i]);
            }
            axon = new Axon(this);
            bia = new Bia(this);
        }
        public void setValoresDeEntrada(double[] valoresDeEntrada)
        {
            for (int i = 0; i < valoresDeEntrada.Length; i++)
            {
                dendritas[i].setValor(valoresDeEntrada[i]);
            }
        }
        private class DendritaEntrada : DendritaAbstracta
        {
            public DendritaEntrada(NeuronaAbstracta padre, double valor)
            {
                this.padre = padre;
                this.valor = valor;
            }
            public override double getValorDeActivacion()
            {
                return valor * peso;
            }
        }
    }
}
