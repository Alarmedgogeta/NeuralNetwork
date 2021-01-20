using System;
using System.Collections.Generic;
using System.Text;

namespace RedesNeuronalesConsola
{
    class NeuronaSalida : NeuronaAbstracta
    {
        private double salidaDeseada;
        public NeuronaSalida(NeuronaAbstracta[] neuronas, double salidaDeseada)
        {
            this.salidaDeseada = salidaDeseada;
            dendritas = new DendritaSalida[neuronas.Length];
            for (int i = 0; i < neuronas.Length; i++)
            {
                dendritas[i] = new DendritaSalida(this, neuronas[i].axon);
            }
            axon = new Axon(this);
            bia = new Bia(this);
        }
        public void setSalidaDeseada(double salidaDeseada)
        {
            this.salidaDeseada = salidaDeseada;
        }
        public new void actualizarError()
        {
            error = salidaDeseada - axon.getValor();
        }
        public void setEntradas(Neurona[] entradas)
        {
            dendritas = new DendritaSalida[entradas.Length];
            for (int i = 0; i < entradas.Length; i++)
            {
                dendritas[i] = new DendritaSalida(this, entradas[i].axon);
            }
        }
        private class DendritaSalida : DendritaAbstracta
        {
            public DendritaSalida(NeuronaAbstracta padre, Axon entrada)
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
