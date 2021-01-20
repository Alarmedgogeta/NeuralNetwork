using System;
using System.Collections.Generic;
using System.Text;

namespace RedesNeuronalesConsola
{
    class RedNeuronal
    {
        private const int CANTIDAD_MAXIMA_DE_EPOCAS = 1000000;
        private CapaNeuronalEntrada capaEntrada;
        private List<CapaNeuronal> capasIntermedias;
        private CapaNeuronalSalida capaSalida;
        private void inicializarRedNeuronal(Entrada entrada)
        {
            capaEntrada = new CapaNeuronalEntrada(entrada.getValores());
            capasIntermedias = new List<CapaNeuronal>();
            CapaNeuronal capaIntermedia = new CapaNeuronal(3, capaEntrada);
            capasIntermedias.Add(capaIntermedia);
            capaSalida = new CapaNeuronalSalida(entrada.getSalidasDeseadas(), capaIntermedia);
        }
        public void entrenar(Entrada[] entradas)
        {
            inicializarRedNeuronal(entradas[0]);
            bool problemaResuelto;
            for (int i = 0; i < CANTIDAD_MAXIMA_DE_EPOCAS; i++)
            {
                if (i % 100000 == 0)
                {
                    Console.Write("Entrenando");
                    //imprimirPesos();
                }
                if ((i % 100000) - 25000 == 0)
                {
                    Console.Write(".");
                }
                if ((i % 100000) - 50000 == 0)
                {
                    Console.Write(".");
                }
                if ((i % 100000) - 75000 == 0)
                {
                    Console.WriteLine(".");
                }
                problemaResuelto = true;
                foreach(Entrada entrada in entradas)
                {
                    resolver(entrada, true);
                    actualizarErrores(entrada.getSalidasDeseadas());
                    if (capaSalida.tieneError())
                    {
                        problemaResuelto = false;
                        actualizarPesos();
                    }
                }
                if (problemaResuelto)
                {
                    //Console.WriteLine("Problema resuelto gg");
                    //imprimirPesos();
                    break;
                }
            }
            Console.WriteLine();
        }
        public void entrenar(Entrada[] entradas, int epocas)
        {
            inicializarRedNeuronal(entradas[0]);
            bool problemaResuelto;
            for (int i = 0; i < epocas; i++)
            {
                if (i % 100000 == 0)
                {
                    Console.Write("Entrenando");
                }
                if ((i % 100000) - 25000 == 0)
                {
                    Console.Write(".");
                }
                if ((i % 100000) - 50000 == 0)
                {
                    Console.Write(".");
                }
                if ((i % 100000) - 75000 == 0)
                {
                    Console.WriteLine(".");
                }
                problemaResuelto = true;
                foreach (Entrada entrada in entradas)
                {
                    resolver(entrada, true);
                    actualizarErrores(entrada.getSalidasDeseadas());
                    if (capaSalida.tieneError())
                    {
                        problemaResuelto = false;
                        actualizarPesos();
                    }
                }
                if (problemaResuelto)
                {
                    Console.WriteLine("Problema resuelto gg");
                    //imprimirPesos();
                    break;
                }
            }
            Console.WriteLine();
        }
        public void resolver(Entrada entrada)
        {
            capaEntrada.setValores(entrada.getValores());
            capaEntrada.propagarResultado();
            foreach (CapaNeuronal capa in capasIntermedias)
            {
                capa.propagarResultado();
            }
            capaSalida.propagarResultado();
            capaSalida.imprimirSalidas();
        }
        public void resolver(Entrada entrada, bool esEntrenamiento)
        {
            capaEntrada.setValores(entrada.getValores());
            capaEntrada.propagarResultado();
            foreach (CapaNeuronal capa in capasIntermedias)
            {
                capa.propagarResultado();
            }
            capaSalida.propagarResultado();
            if (!esEntrenamiento)
            {
                capaSalida.imprimirSalidas();
            }
        }
        private void actualizarErrores(double[] salidasDeseadas)
        {
            capaSalida.setValoresDeseados(salidasDeseadas);
            capaSalida.actualizarErrores();
            for (int i = capasIntermedias.Count - 1; i >= 0; i--)
            {
                capasIntermedias[i].actualizarErrores();
            }
            capaEntrada.actualizarErrores();
        }
        private void actualizarPesos()
        {
            capaSalida.actualizarPesos();
            for (int i = capasIntermedias.Count - 1; i >= 0; i--)
            {
                capasIntermedias[i].actualizarPesos();
            }
            capaEntrada.actualizarPesos();
        }
        private void imprimirPesos()
        {
            Console.WriteLine("CAPA DE ENTRADA");
            capaEntrada.imprimirPesos();
            foreach(CapaNeuronalAbstracta capa in capasIntermedias)
            {
                Console.WriteLine("CAPA INTERMEDIA");
                capa.imprimirPesos();
            }
            Console.WriteLine("CAPA DE SALIDA");
            capaSalida.imprimirPesos();
            Console.WriteLine("\n\n");
        }
        public void imprimirSalidas()
        {
            capaSalida.imprimirSalidas();
        }
        
    }
}
