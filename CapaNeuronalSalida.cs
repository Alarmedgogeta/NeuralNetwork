using System;
using System.Collections.Generic;
using System.Text;

namespace RedesNeuronalesConsola
{
    class CapaNeuronalSalida : CapaNeuronalAbstracta
    {
        private CapaNeuronal capaAntarior;
        private double[] valoresDeseados;

        public CapaNeuronalSalida(double[] valoresDeseados, CapaNeuronal entrada)
        {
            this.valoresDeseados = valoresDeseados;
            neuronas = new NeuronaSalida[valoresDeseados.Length];
            for (int i = 0; i < valoresDeseados.Length; i++)
            {
                neuronas[i] = new NeuronaSalida(entrada.getNeuronas(), valoresDeseados[i]);
            }
        }
        public void setValoresDeseados(double[] valoresDeseados)
        {
            this.valoresDeseados = valoresDeseados;
            int indice = 0;
            foreach (NeuronaSalida neurona in neuronas)
            {
                neurona.setSalidaDeseada(valoresDeseados[indice]);
                indice++;
            }
        }
        public new void actualizarErrores()
        {
            foreach (NeuronaSalida neurona in neuronas)
            {
                neurona.actualizarError();
            }
        }
    }
}
