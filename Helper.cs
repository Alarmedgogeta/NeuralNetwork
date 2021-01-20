using System;
using System.Collections.Generic;
using System.Text;

namespace RedesNeuronalesConsola
{
    class Helper
    {
        private const int NUMERO_MAXIMO_ALEATORIO = 100;
        private const int NUMERO_MINIMO_ALEATORIO = 1;
        private static Random rnd = new Random();
        private static Helper instancia;

        public static Helper getInstancia()
        {
            if(instancia == null)
            {
                instancia = new Helper();
            }
            return instancia;
        }

        private Helper()
        {

        }
        public static int leerNumeroDelUsuario()
        {
            int numeroDelUsuario;
            while(!int.TryParse(Console.ReadLine(), out numeroDelUsuario))
            {
                Console.WriteLine("Por favor, ingrese un numero entero");
            }
            Console.WriteLine("\n");
            return numeroDelUsuario;
        }
        public static double leerNumeroDoubleDelUsuario()
        {
            double numeroDelUsuario; 
            while (!double.TryParse(Console.ReadLine(), out numeroDelUsuario))
            {
                Console.WriteLine("Por favor, ingrese un numero entero");
            }
            Console.WriteLine("\n");
            return numeroDelUsuario;
        }
        public static int getNumeroAleatorio()
        {
            return rnd.Next(NUMERO_MINIMO_ALEATORIO, NUMERO_MAXIMO_ALEATORIO + 1);
        }
        public static decimal getNumeroDecimalAleatorio()
        {
            return rnd.Next(NUMERO_MAXIMO_ALEATORIO + 1) / 10m;
        }
        public static double getNumeroDoubleAleatorio()
        {
            //return Math.Round(rnd.NextDouble(), 2);
            return rnd.NextDouble();
        }
        public static double aplicarFuncionDeAprendizaje(double valorDeActivacion)
        {
            return Math.Round(Math.Tanh(valorDeActivacion), 2);
            //return Math.Tanh(valorDeActivacion);
        }
        public static double derivarFuncionDeAprendizaje(double valorDeActivacion)
        {
            return Math.Round(1 - Math.Pow(aplicarFuncionDeAprendizaje(valorDeActivacion), 2), 2);
            //return 1 - Math.Pow(aplicarFuncionDeAprendizaje(valorDeActivacion), 2);
        }
        public static void imprimirMenuPrincipal()
        {
            Console.WriteLine("MENÚ PRINCIPAL");
            Console.WriteLine("===========================================================");
            Console.WriteLine("||Escoger un problema:\t\t\t\t\t1||");
            Console.WriteLine("||Entrenar:\t\t\t\t\t\t2||");
            Console.WriteLine("||Resolver:\t\t\t\t\t\t3||");
            Console.WriteLine("||-------------------------------------------------------||");
            Console.WriteLine("||Salir:\t\t\t\t\t\t0||");
            Console.WriteLine("===========================================================");
        }
        public static void imprimirMenuProblemas()
        {
            Console.WriteLine("¿Que problema desea resolver?");
            Console.WriteLine("===========================================================");
            Console.WriteLine("||OR:\t\t\t\t\t\t\t1||");
            Console.WriteLine("||NOR:\t\t\t\t\t\t\t2||");
            Console.WriteLine("||AND:\t\t\t\t\t\t\t3||");
            Console.WriteLine("||NAND:\t\t\t\t\t\t\t4||");
            Console.WriteLine("||XOR:\t\t\t\t\t\t\t5||");
            //Console.WriteLine("||OTRO:\t\t\t\t\t\t\t6||");
            Console.WriteLine("||NXOR:\t\t\t\t\t\t\t6||");
            Console.WriteLine("||-------------------------------------------------------||");
            Console.WriteLine("||Regresar:\t\t\t\t\t\t0||");
            Console.WriteLine("===========================================================");
        }
        public static void imprimirMenuEntrenamiento()
        {
            Console.WriteLine("¿Que nivel de entrenamiento desea?");
            Console.WriteLine("===========================================================");
            Console.WriteLine("||BAJO:\t\t\t\t\t\t\t1||");
            Console.WriteLine("||MEDIO:\t\t\t\t\t\t2||");
            Console.WriteLine("||ALTO:\t\t\t\t\t\t\t3||");
            Console.WriteLine("||EXTREMO:\t\t\t\t\t\t4||");
            Console.WriteLine("||-------------------------------------------------------||");
            Console.WriteLine("||Regresar:\t\t\t\t\t\t0||");
            Console.WriteLine("===========================================================");
        }
        public static Entrada getEntradaDelUsuario()
        {
            double primeraEntrada, segundaEntrada;
            Console.WriteLine("Entradas");
            Console.WriteLine("===========================================================");
            //Console.Write("¿Cuantas entradas tiene?: ");
            Console.Write("Ingrese la primera entrada: ");
            primeraEntrada = leerNumeroDoubleDelUsuario();
            Console.Write("Ingrese la segunda entrada: ");
            segundaEntrada = leerNumeroDoubleDelUsuario();
            Console.WriteLine("===========================================================");
            Entrada entrada = new Entrada(new double[] { primeraEntrada, segundaEntrada });
            return entrada;
        }
    }
}
