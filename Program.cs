using System;

namespace RedesNeuronalesConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            RedNeuronal redNeuronal = new RedNeuronal();
            int eleccionDelUsuario;
            Entrada[] entradasDeEntrenamiento = new Entrada[0];
            Entrada entrada;
            int epocas;
            do
            {
                Helper.imprimirMenuPrincipal();
                eleccionDelUsuario = Helper.leerNumeroDelUsuario();
                switch (eleccionDelUsuario)
                {
                    case 1:
                        Helper.imprimirMenuProblemas();
                        entradasDeEntrenamiento = Entrada.GetEntradas((Problemas) Helper.leerNumeroDelUsuario() - 1);
                        break;
                    case 2:
                        if(entradasDeEntrenamiento.Length == 0)
                        {
                            Console.WriteLine("No ha definido un problema a resolver, seleccione uno primero\n");
                        }
                        else
                        {
                            Helper.imprimirMenuEntrenamiento();
                            epocas = Helper.leerNumeroDelUsuario();
                            epocas *= epocas;
                            epocas *= 1000000;
                            redNeuronal.entrenar(entradasDeEntrenamiento, epocas);
                            Console.Write("Advertencia: los resultados obtenidos pueden no ser exactos a los resultados deseados, ");
                            Console.WriteLine("si no está satisfecho con los resultados, le recomendamos volver a entrenar la neurona ;)\n");
                        }
                        break;
                    case 3:
                        if (entradasDeEntrenamiento.Length == 0)
                        {
                            Console.WriteLine("No ha definido un problema a resolver, seleccione uno primero\n");
                        }
                        else
                        {
                            entrada = Helper.getEntradaDelUsuario();
                            redNeuronal.resolver(entrada);
                        }
                        break;
                    default:
                        break;
                }
            } while (eleccionDelUsuario != 0);
            Console.WriteLine("Hasta la proxima");
        }
    }
}
