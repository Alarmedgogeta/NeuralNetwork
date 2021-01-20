using System;
using System.Collections.Generic;
using System.Text;

namespace RedesNeuronalesConsola
{
    class Entrada
    {
        private double[] valores;
        private double[] salidaDeseada;
        public Entrada(double[] valores)
        {
            this.valores = valores;
        }
        public Entrada(double[] valores, double[] salidaDeseada)
        {
            this.valores = valores;
            this.salidaDeseada = salidaDeseada;
        }
        public double[] getValores()
        {
            return valores;
        }
        public double[] getSalidasDeseadas()
        {
            return salidaDeseada;
        }
        public void imprimir()
        {
            Console.Write("Valores ");
            foreach (double valor in valores)
            {
                Console.Write(valor + ", ");
            }
            Console.Write("\nSalidas deseadas ");
            foreach (double salida in salidaDeseada)
            {
                Console.Write(salida + ", ");
            }
            Console.Write("\n");
        }
        public static Entrada[] GetEntradas(Problemas problema)
        {
            Entrada[] entradas = new Entrada[4];
            switch (problema)
            {
                case Problemas.OR:
                    entradas[0] = new Entrada(new double[] { 0, 0 }, new double[] { 0 });
                    entradas[1] = new Entrada(new double[] { 1, 0 }, new double[] { 1 });
                    entradas[2] = new Entrada(new double[] { 0, 1 }, new double[] { 1 });
                    entradas[3] = new Entrada(new double[] { 1, 1 }, new double[] { 1 });
                    break;
                case Problemas.NOR:
                    entradas[0] = new Entrada(new double[] { 0, 0 }, new double[] { 1 });
                    entradas[1] = new Entrada(new double[] { 1, 0 }, new double[] { 0 });
                    entradas[2] = new Entrada(new double[] { 0, 1 }, new double[] { 0 });
                    entradas[3] = new Entrada(new double[] { 1, 1 }, new double[] { 0 });
                    break;
                case Problemas.AND:
                    entradas[0] = new Entrada(new double[] { 0, 0 }, new double[] { 0 });
                    entradas[1] = new Entrada(new double[] { 1, 0 }, new double[] { 0 });
                    entradas[2] = new Entrada(new double[] { 0, 1 }, new double[] { 0 });
                    entradas[3] = new Entrada(new double[] { 1, 1 }, new double[] { 1 });
                    break;
                case Problemas.NADN:
                    entradas[0] = new Entrada(new double[] { 0, 0 }, new double[] { 1 });
                    entradas[1] = new Entrada(new double[] { 1, 0 }, new double[] { 1 });
                    entradas[2] = new Entrada(new double[] { 0, 1 }, new double[] { 1 });
                    entradas[3] = new Entrada(new double[] { 1, 1 }, new double[] { 0 });
                    break;
                case Problemas.XOR:
                    entradas[0] = new Entrada(new double[] { 0, 0 }, new double[] { 0 });
                    entradas[1] = new Entrada(new double[] { 1, 0 }, new double[] { 1 });
                    entradas[2] = new Entrada(new double[] { 0, 1 }, new double[] { 1 });
                    entradas[3] = new Entrada(new double[] { 1, 1 }, new double[] { 0 });
                    break;
                case Problemas.NXOR:
                    entradas[0] = new Entrada(new double[] { 0, 0 }, new double[] { 1 });
                    entradas[1] = new Entrada(new double[] { 1, 0 }, new double[] { 0 });
                    entradas[2] = new Entrada(new double[] { 0, 1 }, new double[] { 0 });
                    entradas[3] = new Entrada(new double[] { 1, 1 }, new double[] { 1 });
                    break;
                default:
                    entradas = new Entrada[0];
                    Console.WriteLine("Problemas no reconocido o no especificado");
                    break;
            }
            return entradas;
        }
    }
}
