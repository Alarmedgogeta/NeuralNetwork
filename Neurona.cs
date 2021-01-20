using System;
using System.Collections.Generic;
using System.Text;

namespace RedesNeuronalesConsola
{
    class Neurona : NeuronaAbstracta
    {
        public Neurona(NeuronaAbstracta[] neuronas)
        {
            dendritas = new Dendrita[neuronas.Length];
            for (int i = 0; i < neuronas.Length; i++)
            {
                dendritas[i] = new Dendrita(this, neuronas[i].axon);
            }
            axon = new Axon(this);
            bia = new Bia(this);
        }
        private class Dendrita : DendritaAbstracta
        {
            public Dendrita(NeuronaAbstracta padre, Axon entrada)
            {
                this.padre = padre;
                this.entrada = entrada;
                entrada.agregarDendrita(this);
            }
            public override double getValorDeActivacion()
            {
                valor = entrada.getValor();
                return valor * peso;
            }
        }
        
    }
}
