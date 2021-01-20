using System;
using System.Collections.Generic;
using System.Text;

namespace RedesNeuronalesConsola
{
    abstract class NeuronaAbstracta
    {
        protected const double FACTOR_DE_APRENDIZAJE = 0.5d;
        protected double valorDeActivacion;
        protected double error;
        protected DendritaAbstracta[] dendritas;
        protected Bia bia;
        public Axon axon;
        public void propagarResultado()
        {
            valorDeActivacion = 0;
            foreach (DendritaAbstracta dentrita in dendritas)
            {
                valorDeActivacion += dentrita.getValorDeActivacion();
            }
            valorDeActivacion += bia.getValorDeActivacion();
            axon.setValorDeSalida(valorDeActivacion);
        }
        public double getFactorDeAprendizaje()
        {
            return FACTOR_DE_APRENDIZAJE;
        }
        protected Axon getAxon()
        {
            return axon;
        }
        public double getSalida()
        {
            return axon.getValor();
        }
        public double getError()
        {
            return error;
        }
        public double getValorDeActivacion()
        {
            return valorDeActivacion;
        }
        public void actualizarError()
        {
            error = axon.getErrorPropagado();
        }
        public void actualizarPesos()
        {
            foreach (DendritaAbstracta dendrita in dendritas)
            {
                dendrita.actualizarPeso();
            }
            //bia.actualizarPeso();
        }
        public void imprimir()
        {
            Console.WriteLine("||Error: : \t\t\t\t\t\t\t\t" + error + "||");
            Console.WriteLine("||Pesos : \t\t\t\t\t\t\t\t ||");
            for (int i = 0; i < dendritas.Length; i++)
            {
                Console.WriteLine("||Peso " + i + ": : \t\t\t\t\t" + dendritas[i].getPeso() + "\t ||");
            }
            Console.WriteLine("||Peso bias: : \t\t\t\t\t" + bia.getPeso() + "\t ||");
        }
        public abstract class DendritaAbstracta
        {
            protected double valor;
            protected double peso = Helper.getNumeroDoubleAleatorio();
            protected Axon entrada;
            protected NeuronaAbstracta padre;
            public void setValor(double valor)
            {
                this.valor = valor;
            }
            public abstract double getValorDeActivacion();
            public double getValor()
            {
                return valor;
            }
            public double getPeso()
            {
                return peso;
            }
            public double getError()
            {
                return padre.getError();
            }
            public void actualizarPeso()
            {
                peso += padre.getFactorDeAprendizaje() * valor * Helper.derivarFuncionDeAprendizaje(padre.getValorDeActivacion()) * padre.getError();
            }
        }
        protected class Bia : DendritaAbstracta
        {
            public Bia(NeuronaAbstracta padre)
            {
                this.padre = padre;
                this.peso = 0.5d;
                this.valor = 1;
            }
            public override double getValorDeActivacion()
            {
                return valor * peso;
            }
            public new void actualizarPeso()
            {
                peso += padre.getFactorDeAprendizaje() * Helper.derivarFuncionDeAprendizaje(padre.getValorDeActivacion()) * padre.getError();
            }
        }
        public class Axon
        {
            private double valor;
            private DendritaAbstracta[] dendritas;
            private NeuronaAbstracta padre;
            public Axon(NeuronaAbstracta padre)
            {
                this.padre = padre;
            }
            public double getValor()
            {
                return valor;
            }
            public void setValorDeSalida(double valorDeActivacion)
            {
                valor = Helper.aplicarFuncionDeAprendizaje(valorDeActivacion);
            }
            public void agregarDendrita(DendritaAbstracta nuevaDendrita)
            {
                int cantidadDendritas = dendritas == null ? 1 : dendritas.Length + 1;
                DendritaAbstracta[] nuevasReceptoras = new DendritaAbstracta[cantidadDendritas];
                for (int i = 0; i < nuevasReceptoras.Length - 1; i++)
                {
                    nuevasReceptoras[i] = dendritas[i];
                }
                nuevasReceptoras[cantidadDendritas - 1] = nuevaDendrita;
                dendritas = nuevasReceptoras;
            }
            public double getErrorPropagado()
            {
                double errorPropagado = 0;
                foreach (DendritaAbstracta receptora in dendritas)
                {
                    errorPropagado += receptora.getPeso() * receptora.getError();
                }
                return errorPropagado;
            }
        }
    }
}
